using todogamma.Models;

public interface IDevice 
{
    IEnumerable<Device> GetAll();
    public Device Get(int id);
    int Add(Device newDevice);
    void Save(Device device);
    void Delete(Device device);
}