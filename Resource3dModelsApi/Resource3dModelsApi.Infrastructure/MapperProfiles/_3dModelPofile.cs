using AutoMapper;
using Resource3dModelsApi.Domain.Models;
using Resource3dModelsApi.Domain.ViewModel._3dModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure.MapperProfiles
{
    public class _3dModelPofile:Profile
    {
        public _3dModelPofile()
        {
            CreateMap<_3dModel, DetailsModel3D>();
            CreateMap<_3dModel, MainModel3D>();
        }
    }
}
