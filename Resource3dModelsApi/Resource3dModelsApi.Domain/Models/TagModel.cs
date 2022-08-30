using Microsoft.EntityFrameworkCore;
using Resource3dModelsApi.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Domain.Models
{
    [Index("Title",IsUnique =true,Name ="TagTitle_index")]
    public class TagModel:IEntity, IEntityWithTitle
    {
        public string Id { get; set; }
        public string Title { get; set; }

    }
}
