using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.Create_3dModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Resource3dModelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _3dModelController : ControllerBase
    {

        private readonly IMediator mediator;
        public _3dModelController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        // GET: api/<_3dModelController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<_3dModelController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<_3dModelController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Create_3dModelCommand create_3DModelCommand)
        {
            var res =await mediator.Send(create_3DModelCommand);
            return Ok(res.Entity);
        }

        // PUT api/<_3dModelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<_3dModelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
