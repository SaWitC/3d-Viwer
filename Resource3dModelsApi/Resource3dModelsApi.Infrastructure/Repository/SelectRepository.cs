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
    public class SelectRepository : ISelectRepository
    {
        private readonly AppDbContext appDbContext;

        public SelectRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Task<IQueryable<T>> Select<T>(int page, int size) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> SelectPageByAvtor<T>(string AvtorId, int page) where T : class, IHasAvtor
        {
            return appDbContext.Set<T>().Skip(page * 5).Take(5).Where(o => o.AvtorId == AvtorId);
        }
    }
}
