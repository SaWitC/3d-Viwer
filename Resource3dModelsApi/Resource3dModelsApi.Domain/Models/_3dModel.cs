using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Resource3dModelsApi.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Domain.Models
{
    [Index("Title",IsUnique =true,Name ="Title_index")]
    public class _3dModel:IEntity, IEntityWithTitle, IHasAvtor
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Category category { get; set; }
        public string AvtorId { get; set; }
        public bool IsFileUploaded { get; set; } = false;
        public string FileTitleWithoutExtension { get; set; } = "";
    }
}
