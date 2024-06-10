using ExternalLogin.Models;
using ExternalLogin.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExternalLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepo;

        public AccountController(IAccountRepository repository) {
            accountRepo = repository;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            var res = await accountRepo.SignUpAsync(model);
            if (res.Succeeded)
            {
                return Ok(res.Succeeded);
            }

            return Unauthorized(res.Errors);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {
            var res = await accountRepo.SignInAsync(signInModel);

            if (string.IsNullOrEmpty(res))
            {
                return Unauthorized();
            }
            else
            {
                return Ok(res);
            }
        }
    }
}
