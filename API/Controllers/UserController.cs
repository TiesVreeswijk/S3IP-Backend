using System.Security.Claims;
using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var result = _userService.GetAllUsers();
        return Ok(result);
    }
    
    [Authorize]
    [HttpGet]
    [Route("exceptcurrent")]
    public IActionResult GetAllUsersExceptCurrentUser()
    {
        var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                                      throw new Exception("Could not find current user id in token"));
        
        var result = _userService.GetAllUsersExceptCurrentUser(currentUserId);
        return Ok(result);
    }
    
    
    
}