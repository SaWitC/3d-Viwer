using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Domain.ViewModel._3dModelVM
{
    public class DetailsModel3D
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Category category { get; set; }
        public string AvtorId { get; set; }
        public bool IsFileUploaded { get; set; }
        public string FileTitleWithoutExtension { get; set; }

        public string ModelURL { get; set; }
    }
}
