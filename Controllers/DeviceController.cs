using Microsoft.AspNetCore.Mvc;
using todogamma.Models;
using Microsoft.AspNetCore.Cors;

[ApiController]
[EnableCors("MyPolicy")] 
[Route("[controller]")]

public class DeviceController : Controller 
{
    private readonly IDevice _device;
    public DeviceController(IDevice device)
    {
        _device = device;
    }

  
    [EnableCors("MyPolicy")]
    [HttpGet]
    public IEnumerable<Device> Get()
    {
        return _device.GetAll();
    }
    [HttpGet("{id}")]
    [EnableCors("MyPolicy")]
    public Device Get(int id)
    {
        return _device.Get(id);

    }
    [HttpPost]
    public int Post([FromBody] Device device)
    {
        return _device.Add(device);
    }
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Device model)
    {
        var device = _device.Get(id);
        device.Title = model.Title; device.Price = model.Price;
        _device.Save(device);
    }
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var device = _device.Get(id);
        _device.Delete(device);
    }
}