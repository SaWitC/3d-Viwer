using Resource3dModelsApi.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Domain.Models
{
    public class Category:IEntity
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 

    }
}
