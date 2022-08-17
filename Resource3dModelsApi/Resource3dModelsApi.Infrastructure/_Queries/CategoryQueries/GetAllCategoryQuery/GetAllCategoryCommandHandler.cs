using MediatR;
using Resource3dModelsApi.Application.Repository;
using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Queries.CategoryQueries.GetAllCategoryQuery
{
    public class GetAllCategoryCommandHandler : IRequestHandler<GetAllCategoryCommand,IEnumerable<Category>>
    {
        private IBaseRepository _baseRepository;

        public GetAllCategoryCommandHandler(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IEnumerable<Category>> Handle(GetAllCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _baseRepository.GetAllAsync<Category>();
        }
    }
}
