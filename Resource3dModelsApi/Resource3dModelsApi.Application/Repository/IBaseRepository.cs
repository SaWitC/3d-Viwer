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
        Task<bool> DeleteAsync<T>(T model) where T : class, IEntity;
        Task<bool> UpdateAsync<T>(T model) where T : class, IEntity;
        Task SaveChangesAsync();
        Task<T> GetByIdAsync<T>(string Id) where T : class, IEntity;
        Task<IEnumerable<T>> GetByIdAsync<T>() where T : class, IEntity;


    }
}
