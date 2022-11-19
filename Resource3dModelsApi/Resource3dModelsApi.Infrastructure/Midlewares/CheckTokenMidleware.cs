using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Resource3dModelsApi.Infrastructure.CustomHttpClients;
using Resource3dModelsApi.Infrastructure.CustomHttpClients.AuthorizationClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource3dModelsApi.Domain.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Resource3dModelsApi.Infrastructure.Midlewares
{
    public class CheckTokenMidleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuthorizationClient _authorizationClient;

        public CheckTokenMidleware(RequestDelegate next, IServiceProvider serviceProvider, IAuthorizationClient authorizationClient)
        {
            _next = next;
            _serviceProvider = serviceProvider;
            _authorizationClient = authorizationClient;
        }

        public async Task InvokeAsync(Microsoft.AspNetCore.Http.HttpContext httpContent)
        {
            try
            {
                var headers = httpContent.Request.Headers;

                //var token = "";
                //foreach (var item in headers)
                //{
                //    if (item.Key == "Authorization")
                //    {
                //        token = item.Value.ToString().Split()[1];
                //        break;
                //    }
                //}
                

                var user = await _authorizationClient.CheckToken(headers);
                if (user != null)
                {

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                        //new Claim(ClaimTypes.Locality, person.City),
                        //new Claim("company", person.Company)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");

                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await httpContent.SignInAsync(claimsPrincipal);
                }
                

                //User UserData =JsonSerializer.Deserialize<User>(resp.);


                if (user==null)
                {
                    throw new UnauthorizedAccessException();
                }

            }
            catch
            {

            }
            await _next.Invoke(httpContent);
        }
    }
}
