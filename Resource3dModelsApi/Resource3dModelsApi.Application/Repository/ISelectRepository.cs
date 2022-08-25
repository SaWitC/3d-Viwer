using Resource3dModelsApi.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Application.Repository
{
    public interface ISelectRepository
    {
        IQueryable<T> Select<T>(int page =0,int size=5)where T:class,IEntity;

        IQueryable<T> SelectPageByAvtor<T>(string AvtorId, int page) where T : class, IHasAvtor;

        IQueryable<TRes> SelectPageWithUseAutomapper<TRes, TBaseEntity>(string SearchString, string CategoryId, int page = 0, int size = 5) where TRes : class, IEntity where TBaseEntity : class, IEntity;

        
    }
}
