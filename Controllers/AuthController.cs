using Azure;
using BookingServiceAPI.Models.DTOs.Identity;
using BookingServiceAPI.Services.Interfaces;
using BookingServiceAPI.Utilities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace BookingServiceAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authenticationService;
        public AuthController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            try
            {
                await _authenticationService.RegisterUserAsync(model);
                return Ok("User created successfully!");
            }
            catch (UserRegistrationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var token = await _authenticationService.LoginAsync(model.Username, model.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
    }
}
