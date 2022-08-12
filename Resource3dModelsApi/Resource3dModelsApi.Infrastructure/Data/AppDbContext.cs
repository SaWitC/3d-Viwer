using Microsoft.EntityFrameworkCore;
using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<_3dModel> _3DModels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TagModel> Tags { get; set; }
        public DbSet<Tags_Models_Relationship> tags_Models_Relationships { get; set; }
    }
}
