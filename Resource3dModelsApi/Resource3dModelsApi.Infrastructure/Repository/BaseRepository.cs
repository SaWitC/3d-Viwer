using Microsoft.EntityFrameworkCore.ChangeTracking;
using Resource3dModelsApi.Application.Repository;
using Resource3dModelsApi.Domain.Models.Interfaces;
using Resource3dModelsApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<EntityEntry<T>> CreateAsync<T>(T model) where T : class, IEntity
        {
            var res =await _context.Set<T>().AddAsync(model);
            return res;
        }

        public async Task<bool> DeleteAsync<T>(string Id) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync<T>(string Id) where T : class, IEntity
{
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetByIdAsync<T>() where T : class, IEntity
{
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync<T>(T model, string Id) where T : class, IEntity
{
            throw new NotImplementedException();
        }
    }
}
