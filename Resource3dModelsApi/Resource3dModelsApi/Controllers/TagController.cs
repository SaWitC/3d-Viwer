using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resource3dModelsApi.Infrastructure._Queries.TagQuery.GetTagsHints;

namespace Resource3dModelsApi.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    public class TagController:ControllerBase
    {
        private readonly IMediator _mediator;
        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/[controller]/{substr}")]
        public async Task<IActionResult> GetTagsHints(string substr)
        {
            var query =new GetTagsHintsQuery();
            query.substring = substr;
            var res =await _mediator.Send(query);
            return Ok(res);
        }
    }
}
