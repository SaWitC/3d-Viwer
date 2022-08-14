using Microsoft.EntityFrameworkCore.ChangeTracking;
using Resource3dModelsApi.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Application.Repository
{
    public interface IBaseRepository
    {
        Task<EntityEntry<T>> CreateAsync<T>(T model) where T : class, IEntity;
        Task<bool> DeleteAsync<T>(string Id) where T : class, IEntity;
        Task<EntityEntry<T>> UpdateAsync<T>(T model,string Id) where T : class, IEntity;
        Task SaveChangesAsync();
        Task<T> GetByIdAsync<T>(string Id) where T : class, IEntity;
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class, IEntity;
    }
}
