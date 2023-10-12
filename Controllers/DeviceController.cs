using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using todogamma.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


[Route("api/[controller]")]
public class DeviceController : Controller 
{
    private readonly IDevice _device;
    public DeviceController(IDevice device)
    {
        _device = device;
    }
    [HttpGet]
    public IEnumerable<Device> Get()
    {
        return _device.GetAll();
    }
    [HttpGet("{id}")]
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