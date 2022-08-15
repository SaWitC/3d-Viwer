using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure.Data
{
    public class SampleData
    {
        public static async Task Initialize(AppDbContext _context)
        {
            if (!_context.Categories.Any())
            {
                await _context.AddRangeAsync(new List<Category>
                {
                    new Category{Title="Animal",Description="different animals"},
                    new Category{Title="car", Description="different cars"},
                    new Category{Title="art", Description="different arts"},
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
