using Microsoft.AspNetCore.Identity;
using todogamma.Models;

namespace todogamma.Service;

public class AuthService : IAuthServices
{
    private readonly UserManager<IdentityUser> _userManager;
    public AuthService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
   
    public async Task<bool> RegisterUser(LoginUser user)
    {
        var identityUser = new IdentityUser {
            UserName = user.UserName,
            Email = user.UserName,
        };

       var result = await _userManager.CreateAsync(identityUser, user.Password);
         return  result.Succeeded;
    }
     public async Task<bool> Login(LoginUser user)
    {
        var identityUser = await _userManager.FindByEmailAsync(user.UserName);
        if(identityUser is null)
        {
            return false;
        }
       return await _userManager.CheckPasswordAsync(identityUser, user.Password);
   }
}
