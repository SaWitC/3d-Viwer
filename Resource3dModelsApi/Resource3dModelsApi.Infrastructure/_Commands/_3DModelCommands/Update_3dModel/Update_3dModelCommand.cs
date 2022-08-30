using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.Update_3dModel
{
    public class Update_3dModelCommand:IRequest<EntityEntry<_3dModel>>
    {
        public _3dModel model { get; set; }
        public string OldModelId { get; set; }
        public string AvtorId { get; set; }
        public string TagsString { get; set; }

    }
}
