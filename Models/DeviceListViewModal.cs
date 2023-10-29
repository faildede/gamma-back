using Microsoft.AspNetCore.Mvc.Rendering;

namespace  todogamma.Models;
public class DeviceListViewModal 
{
    public IEnumerable<Device> Devices {get; set;}
    public SelectList Category {get; set; }
}