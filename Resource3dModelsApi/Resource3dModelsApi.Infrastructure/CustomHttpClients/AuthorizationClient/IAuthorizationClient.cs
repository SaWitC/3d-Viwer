using Microsoft.AspNetCore.Http;
using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure.CustomHttpClients.AuthorizationClient
{ 
    public interface IAuthorizationClient
    {
        Task<User> CheckToken(IHeaderDictionary headers);
    }
}
