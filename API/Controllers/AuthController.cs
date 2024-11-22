using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Business.Dtos.RequestDtos;
using Business.Exceptions;
using Business.Interfaces;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace API
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IUserService userService, ITokenService tokenService) : ControllerBase
    {
        
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginReq request)
        {
            try {
                var token = userService.LoginUserReturnToken(request); // This method should return a token
                return Ok(new { token });
            }
            catch (ResourceNotFoundException e) { return BadRequest(e.Message); }
            catch (UnauthorizedException e) { return Unauthorized(e.Message); }
            catch (Exception e) { return StatusCode(500, e.Message); }
        }
    
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterReq registerReq)
        {
            try
            {
                var user = userService.RegisterUser(registerReq); 
                return Ok (new {user});
            }
            catch (RegistrationException e) { return BadRequest(e.Message); }
            catch (Exception e) { return StatusCode(500, e.Message); }
        }
    
    }
}