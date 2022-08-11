using Application.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces.Models.Interfaces;
using System.Data.Entity;

namespace Persistence.Repository
{
    public class Repository : IBaseRepository
    {
        private readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<EntityEntry<T>> Create<T>(T model) where T : class, IEntity
        {
            var entity = await _appDbContext.Set<T>().AddAsync(model);
            return entity;
        }

        public async Task<bool> Delete<T>(string Id) where T : class, IEntity    
        {
            if(!string.IsNullOrEmpty(Id)){
                var oldModel =await _appDbContext.Set<T>().FirstOrDefaultAsync(o => o.Id == Id);
                if (oldModel != null)
                {
                    _appDbContext.Set<T>().Remove(oldModel);
                    return true;
                }
            }
            return false;
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : class, IEntity
        {
            return await _appDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById<T>(string Id) where T : class, IEntity
        {
            return await _appDbContext.Set<T>().FirstOrDefaultAsync(o=>o.Id==Id);
        }

        public async Task<bool> Update<T>(T model,string Id) where T : class, IEntity    
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var oldmodel = _appDbContext.Set<T>().FirstOrDefaultAsync(o => o.Id == Id);
                if (oldmodel != null)
                {
                    model.Id = Id;
                    _appDbContext.Set<T>().Update(model);
                    return true;
                }
            }  
            return false;
        }
    }
}
