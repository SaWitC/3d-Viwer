using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resource3dModelsApi.Domain.ConfigurationModels;
using Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.Create_3dModel;
using Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.Update_3dModel;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Resource3dModelsApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class _3dModelController : ControllerBase
    {
        public Guid Id => Guid.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        private readonly IConfiguration _configuration;
        private readonly IMediator mediator;
        public _3dModelController(IMediator mediator, IConfiguration configuration)
        {
            this.mediator = mediator;
            _configuration = configuration;
        }


        // GET: api/<_3dModelController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<_3dModelController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            return Ok(Id.ToString());
        }

        // POST api/<_3dModelController>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] Create_3dModelCommand create_3DModelCommand)
        {
            var data = _configuration.GetSection("FileServiceConfiguration").Get<FileServiceConfiguration>();
            //create_3DModelCommand.Token = data.Token;
            create_3DModelCommand.AvtorId = Id.ToString();

            var res =await mediator.Send(create_3DModelCommand);
            return Ok(res.Entity);
        }

        // PUT api/<_3dModelController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult > Put(int id, [FromBody] Update_3dModelCommand update_3DModelCommand)
        {
            var res = await mediator.Send(update_3DModelCommand);
            return Ok(res.Entity);
        }

        // DELETE api/<_3dModelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
