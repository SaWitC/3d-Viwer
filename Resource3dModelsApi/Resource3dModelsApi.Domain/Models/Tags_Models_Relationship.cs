using Resource3dModelsApi.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Domain.Models
{
    public class Tags_Models_Relationship:IEntity
    {
        public string Id { get; set; }
        public string _3dModelId { get; set; }
        public string TagId { get; set; }
    }
}
