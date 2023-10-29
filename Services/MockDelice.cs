
using todogamma.Models;

public class MockDevice : IDevice
{

    private List<Device> _device;
    public MockDevice()
    {

        _device = new List<Device> 
        {
  
            new Device { Title = "сварочный аппарат", Price=400, Img="https://www.kron.spb.ru/assets/image-cache/kron-03.85486864.png", Manufacturer="Flextec 350X", Description="nvdsivnisdnv",CategoryID=1,   },
            new Device { Title = "сварочный аппарат", Price=400, Img="https://www.kron.spb.ru/assets/image-cache/kron-03.85486864.png", Manufacturer="Flextec 350X",Description="nvdsivnisdnv" , CategoryID=2 },
            new Device { Title = "сварочный аппарат", Price=400, Img="https://www.kron.spb.ru/assets/image-cache/kron-03.85486864.png", Manufacturer="Flextec 350X",Description="nvdsivnisdnv" , CategoryID=3 },

        };
    }
    public IEnumerable<Device> GetAll()
    {
        return _device;
    }
    public Device Get(int id)
    {
        return _device.FirstOrDefault(x => x.Id.Equals(id)) ?? new Device()
                                                                    {Id = -1};
    }
    public int Add(Device newDevice)
    {
        newDevice.Id = _device.Max(p => p.Id) + 1;
        _device.Add(newDevice);
        return newDevice.Id;
    }
    public void Save(Device device)
    {
        _device.Where(p => p.Id == device.Id).ToList().ForEach(x => 
                                                {x.Title = device.Title; x.Price = device.Price;});
    }
    public void Delete(Device device)
    {
        _device.Remove(device);
    }
}