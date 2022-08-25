using Resource3dModelsApi.Domain.Models;
using Resource3dModelsApi.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Domain.ViewModel._3dModelVM
{
    public class MainModel3D:IEntity
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public Category category { get; set; }
        public string FileTitleWithoutExtension { get; set; }

        public string ModelURL { get; set; }
    }
}
