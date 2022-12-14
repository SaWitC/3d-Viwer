using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Resource3dModelsApi.Domain.Models;
using Resource3dModelsApi.Domain.ViewModel._3dModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Queries._3DModelQueries.Get_3dModelById
{
    public class Get_3dModelByIdQuery:IRequest<DetailsModel3D>
    {
        public string Id;
    }
}
