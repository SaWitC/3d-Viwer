using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resource3dModelsApi.Domain.ConfigurationModels;
using Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.Create_3dModel;
using Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.Delete_3dModel;
using Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.Update_3dModel;
using Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.UploadFile;
using Resource3dModelsApi.Infrastructure._Queries._3DModelQueries.Get_3dModelById;
using Resource3dModelsApi.Infrastructure._Queries._3DModelQueries.GetModelsQuery;
using Resource3dModelsApi.Infrastructure._Queries._3DModelQueries.GetMy_3dModels;
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
        [HttpGet("Get/{page}")]
        public async Task<IActionResult> Get(int page)
        {
            GetModelsQuery getModelsQuery = new GetModelsQuery();
            if (page > 0)
                getModelsQuery.page = page;

            var links = await mediator.Send(getModelsQuery);
            return Ok(links);
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                Get_3dModelByIdQuery get_3DModelByIdQuery = new Get_3dModelByIdQuery();
                get_3DModelByIdQuery.Id = id;
                var res = await mediator.Send(get_3DModelByIdQuery);
                if (res != null)
                {
                    return Ok(res);
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                //logs
                return StatusCode(500, ex.Message);
            }
        }


        // POST api/<_3dModelController>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] Create_3dModelCommand create_3DModelCommand)
        {
            var data = _configuration.GetSection("FileServiceConfiguration").Get<FileServiceConfiguration>();
            //create_3DModelCommand.Token = data.Token;

            create_3DModelCommand.AvtorId = Id.ToString();
            //create_3DModelCommand.AvtorId = Guid.NewGuid().ToString();

            var res =await mediator.Send(create_3DModelCommand);
            return Ok(res.Entity);
        }
        // DELETE api/<_3dModelController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete (string id)
        {
            try
            {
                Delete_3dModelCommand delete_3DModelCommand = new Delete_3dModelCommand();
                delete_3DModelCommand.Id = id;
                delete_3DModelCommand.AvtorId = Id.ToString();
                await mediator.Send(delete_3DModelCommand);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { Error = $"Server delete exception {ex}"});
            }
        }
        [Authorize]
        [HttpPost("Upload/{id}")]
        //[RequestSizeLimit(1000)]
        public async Task<IActionResult> Upload_3dModel(string id)
        {
            try
            {
                var file = Request.Form.Files[0];
               

                if (file.FileName.Count(o => o == '.') == 1&&(Path.GetExtension(file.FileName)== ".gltf"|| Path.GetExtension(file.FileName) == ".glb"))
                {
                    UploadFileCommand uploadFileCommand = new UploadFileCommand();
                    uploadFileCommand.file = file;
                    uploadFileCommand.id = id;
                    var res = await mediator.Send(uploadFileCommand);

                    if (res)
                        return Ok();
                    else
                        return StatusCode(500, $"server exception");
                }
                //return BadRequest();
                return BadRequest(new { err = "Incorrect file name or extension" });
                    
            }
            catch(Exception ex)
            {
                return StatusCode(500,$"server exception {ex.Message}");
            }
        }
        [Authorize]
        [HttpGet("GetMyModels/{page}")]
        public async Task<IActionResult> GetMy_3dModels(int page)
        {
            GetMy_3dModelsQuery getMy_3DModelQuery = new GetMy_3dModelsQuery();
            getMy_3DModelQuery.AvtorId = Id.ToString();
            var res = await mediator.Send(getMy_3DModelQuery);

            return Ok();
        }

        [HttpPatch]
        //[Authorize]
        public async Task<IActionResult> Update(Update_3dModelCommand model)
        {
            try
            {
                await mediator.Send(model);
                return Ok();
            }
            catch (Exception ex) {
                return StatusCode(500, new { Error = $"Update error {ex}"  });
            }
        }
    }
}
