using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Resource3dModelsApi.Infrastructure._Commands.HomeCommands.GetHome3dModels;

namespace Resource3dModelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMediator mediator;
        private readonly IMemoryCache _memoryCache;
        public HomeController(IMediator mediator,IMemoryCache memoryCache )
        {
            this.mediator = mediator;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        [ResponseCache(Duration =1000,Location =ResponseCacheLocation.Any)]
        public async Task<IActionResult> GetBaseFiles()
        {

            var CacheRes = _memoryCache.Get("LinksOfFiles");
            if (CacheRes != null)
                return Ok(CacheRes);
            else
            {
                GetHome3dModelsCommand getHome3DModelsCommand = new GetHome3dModelsCommand();
                var res = await mediator.Send(getHome3DModelsCommand);
                if (res != null)
                    _memoryCache.Set("LinksOfFiles", res);

                return Ok(res);
            }
           
        }
    }
}
