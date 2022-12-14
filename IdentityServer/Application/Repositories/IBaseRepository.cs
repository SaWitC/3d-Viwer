using DataAcces.Models.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IBaseRepository
    {
        Task SaveChangesAsync();
        Task<EntityEntry<T>> Create<T>(T model) where T : class, IEntity;
        Task<bool> Update<T>(T model, string Id) where T : class, IEntity;


        Task<bool> Delete<T>(string Id) where T: class, IEntity;

        Task<IEnumerable<T>> GetAll<T>() where T : class, IEntity;

        Task<T> GetById<T>(string Id) where T : class, IEntity;
    }
}
