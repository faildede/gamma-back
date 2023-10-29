using Microsoft.AspNetCore.Mvc;
using todogamma.Models;
using Microsoft.AspNetCore.Cors;
using todogamma.Service;

namespace todogamma.Controllers;

[Route("[controller]")]
[ApiController]
[EnableCors("MyPolicy")] 

public class AuthController : ControllerBase 
{
    private readonly IAuthServices _authServices;
    public AuthController(IAuthServices authServices)
    {
        _authServices = authServices;
    }
    [HttpPost("Register")]
    public async Task<IActionResult> RegisterUser(LoginUser user)
    {
        if(await _authServices.RegisterUser(user))
        {
            return Ok("SuccesFully Done");
        }
      return BadRequest("Something went wrong");
    }

    [HttpGet("Login")]
    public async Task<IActionResult> Login(LoginUser user)
    {
        if(ModelState.IsValid)
        {
            return BadRequest();
        }
        if(await _authServices.Login(user))
        {
            return Ok("Done");
        }
        return BadRequest();
    }

}