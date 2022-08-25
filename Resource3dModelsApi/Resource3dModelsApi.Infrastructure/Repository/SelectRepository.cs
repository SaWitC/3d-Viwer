using AutoMapper;
using AutoMapper.QueryableExtensions;
using Resource3dModelsApi.Application.Repository;
using Resource3dModelsApi.Domain.Models.Interfaces;
using Resource3dModelsApi.Infrastructure.Data;
using Resource3dModelsApi.Infrastructure.MapperProfiles;
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
        private readonly IMapper _mapper;
        public SelectRepository(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this._mapper = mapper;
        }
        public IQueryable<T> Select<T>(int page, int size) where T : class, IEntity
        {
            return appDbContext.Set<T>().Skip(0 * size).Take(size);
        }
        public IQueryable<T> SelectPageByAvtor<T>(string AvtorId, int page) where T : class, IHasAvtor
        {
            return appDbContext.Set<T>().Skip(page * 5).Take(5).Where(o => o.AvtorId == AvtorId);
        }
        IQueryable<TRes> ISelectRepository.SelectPageWithUseAutomapper<TRes, TBaseEntity>(string SearchString, string CategoryId, int page, int size)
        {
            //without elastic search
            return appDbContext.Set<TBaseEntity>().Skip(page * size).Take(size).ProjectTo<TRes>(_mapper.ConfigurationProvider);
        }
    }
}
