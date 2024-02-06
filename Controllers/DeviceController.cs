using Microsoft.AspNetCore.Mvc;
using todogamma.Interface;
using todogamma.Models;

namespace todogamma.Controllers;
[ApiController]
[Route("/[controller]")]
public class DeviceController : GenericApiController<Device>
{
    public DeviceController(IRepository<Device> repository) : base(repository)
    {
        
    }
}