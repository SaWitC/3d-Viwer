using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.Create_3dModel
{
    public class Create_3dModelCommand:IRequest<EntityEntry<_3dModel>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string category { get; set; }

        public string AvtorId { get; set; }

        public string TagsString { get; set; }
    }
}
