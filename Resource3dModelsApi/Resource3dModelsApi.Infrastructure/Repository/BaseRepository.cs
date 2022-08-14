using Microsoft.EntityFrameworkCore;
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
            =>await _context.Set<T>().AddAsync(model);

        public async Task<bool> DeleteAsync<T>(string Id) where T : class, IEntity
        {
            var model = await _context.Set<T>().FirstOrDefaultAsync(x=>x.Id==Id);
            if (model != null)
            {
                _context.Set<T>().Remove(model);
                return true;
            }
            return false;
        }

        public async Task<T> GetByIdAsync<T>(string Id) where T : class, IEntity
            =>await _context.Set<T>().FirstOrDefaultAsync(o=>o.Id==Id);


        public async Task<EntityEntry<T>> UpdateAsync<T>(T model, string Id) where T : class, IEntity
{
            var oldModel = _context.Set<T>().FirstOrDefaultAsync(o => o.Id == Id);
            if (oldModel != null)
            {
                model.Id = Id;
                return _context.Set<T>().Update(model);
            }
            return null;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class, IEntity
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
