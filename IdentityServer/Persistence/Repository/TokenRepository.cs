using Application.Repositories;
using DataAcces.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly AppDbContext appDbContext;

        public TokenRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<EntityEntry> CreateAsync(string token)
        {
            var model = new JwtModel();
            model.jwtTokenId = token;
            return await appDbContext.AddAsync(model);
        }

        public async Task<JwtModel> GetByTokenAsync(string token)
        {
            return await appDbContext.jwtModels.FirstOrDefaultAsync(o=>o.jwtTokenId==token);
        }
    }
}
