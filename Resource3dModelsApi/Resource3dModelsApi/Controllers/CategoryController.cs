using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resource3dModelsApi.Infrastructure._Queries.CategoryQueries.GetAllCategoryQuery;
using System.Security.Claims;
using System.Text.Json;

namespace Resource3dModelsApi.Controllers
{  
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public Guid Id => Guid.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        private readonly IMediator _mediator;
        public CategoryController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetAll()
        {
            GetAllCategoryCommand getAllCategoryCommand = new GetAllCategoryCommand();
            var res = await _mediator.Send(getAllCategoryCommand);
            //return Ok(JsonSerializer.Serialize(res));
            return Ok(res);
        }
    }
}
