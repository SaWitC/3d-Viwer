using Microsoft.AspNetCore.Http;
using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure.CustomHttpClients.AuthorizationClient
{
    public class AuthorizationClient: IAuthorizationClient
    {
        private readonly HttpClient _httpClient;
        public AuthorizationClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7074");
            _httpClient.Timeout = new TimeSpan(0, 1, 5);
            _httpClient.DefaultRequestHeaders.Clear();
        }

        public async Task<User> CheckToken(IHeaderDictionary headers)
        {
             //var headers =_httpClient.req
           
            //var request = new HttpRequestMessage(HttpMethod.Get, "api/Account/login");
            var request = new HttpRequestMessage(HttpMethod.Get, "isTokinValid");

            var listOfHeaders = headers.ToList();
            foreach (var item in listOfHeaders)
            {
                if (item.Key == "Authorization")
                {
                    try
                    {
                        _httpClient.DefaultRequestHeaders.Add(item.Key.ToString(), item.Value.ToString());
                        break;
                    }
                    catch
                    {

                    }
                }
            }

            //request.Headers.UserAgent.Add(new );
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip,deflate,br"));
            request.Headers.Connection.Add("keep-alive");
            //request.RequestUri = new Uri("https://localhost:7074/api/Account/isTokinValid");

            using (var response = await _httpClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<User>();
                else
                    return null;
                //response.EnsureSuccessStatusCode();

                //var content =response.
            }
            return null;
        }
    }
}
