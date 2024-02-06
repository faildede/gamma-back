using todogamma.Repositories;
using todogamma.Models;
using Microsoft.EntityFrameworkCore;


public class DeviceRepository : GenericRepository<DeviceContext, Device> 
{
    public DeviceRepository(DeviceContext dbContext)
    : base(dbContext)
    {

    }
    protected override DbSet<Device> DbSet => _dbContext.Devices;
}