using ECommerce.Application.Interfaces.Security;
using ECommerce.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerLoginController : ControllerBase
    {
        private readonly IJwtAuthenticationService jwtAuthenticationService;

        public CustomerLoginController(IJwtAuthenticationService jwtAuthenticationService)
        {
            this.jwtAuthenticationService = jwtAuthenticationService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await jwtAuthenticationService.Authenticate(model.Email, model.Password);
                if (token != null) 
                {
                    return Ok(new {Token = token});
                }
                else
                {
                    return Unauthorized(new { Message = "Invalid credentials" });
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterVM userRegisterVM)
        {
            if (ModelState.IsValid)
            {
                var registirationStatus = await jwtAuthenticationService.Register(userRegisterVM);

                if (registirationStatus)
                {
                    return Ok(new { Message = "Registration successful" });
                }
                else
                {
                    return BadRequest(new {Message = "Registration failed" });
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
