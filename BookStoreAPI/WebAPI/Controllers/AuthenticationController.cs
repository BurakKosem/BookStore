using Business.Auth;
using Entities.DTOs;
using Entities.Identities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authentication;

        public AuthenticationController(IAuthenticationService auth)
        {
            _authentication = auth;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UserForRegistration userForRegistration)
        {
            var result = await _authentication.RegisterUser(userForRegistration);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate(UserForAuthenticationDto user)
        {
            if(!await _authentication.ValidateUser(user))
                return Unauthorized();

            var tokenDto = await _authentication.CreateToken(populateExpire: true);

            return Ok(tokenDto);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _authentication.RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }
    }
}
