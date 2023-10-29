using todogamma.Models;

namespace todogamma.Service;

public interface IAuthServices 
{

    Task<bool> Login(LoginUser user);
    Task<bool> RegisterUser(LoginUser user);
}