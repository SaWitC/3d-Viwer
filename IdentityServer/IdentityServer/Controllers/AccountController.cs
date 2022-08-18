using Application.Repositories;
using DataAcces.Models;
using DataAcces.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityServer.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        public Guid Id => Guid.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        //private ILogger<AccountController> _logger;
        private readonly IAccountRepository _accountRepository;
        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            //ILogger<AccountController> logger,
            IAccountRepository accountRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_logger = logger;
            _accountRepository = accountRepository;
        }

        [HttpPost]
        [Route("api/[controller]/Register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User() { UserName = model.UserName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var res = await _userManager.AddToRoleAsync(user, "user");
                    if (res.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);

                        return Ok();
                    }
                    //var createduser = _userManager.FindByNameAsync(user.UserName);
                }
                //_logger.LogWarning("incorrect values ");
                return BadRequest(result.Errors);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("api/[controller]/login")]

        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.Password))
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        var token = await _accountRepository.GenerateJwtToken(user);
                        //_logger.LogInformation($"Loged {JsonSerializer.Serialize(user)}");

                        return Ok(new { Token = token });
                        //return Ok(res);
                    }
                    if (result.IsNotAllowed)
                    {

                    }
                }

                return Unauthorized();
            }
            return Unauthorized();
        }
        [Authorize(AuthenticationSchemes = "Bearer")]

        [HttpGet("[action]")]
        public async Task<IActionResult> GetInfoAbutUser()
        {
            //return Ok(await _accountRepository.GetInfoAboutUserByIdAsync(this.Id.ToString()));
            return Ok(await _userManager.FindByIdAsync(this.Id.ToString()));

        }

        [HttpGet("[action]")]
        [Authorize]
        public IActionResult wt()
        {
            return Ok(/*Id.ToString()*/);
        }
    }
}
