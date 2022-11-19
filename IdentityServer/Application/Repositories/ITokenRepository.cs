using DataAcces.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ITokenRepository
    {
        Task<EntityEntry> CreateAsync(string token);

        Task<JwtModel> GetByTokenAsync(string token);
    }
}
