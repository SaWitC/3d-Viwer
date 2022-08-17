using MediatR;
using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Queries.CategoryQueries.GetAllCategoryQuery
{
    public class GetAllCategoryCommand:IRequest<IEnumerable<Category>>
    {
    }
}
