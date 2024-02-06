using Microsoft.EntityFrameworkCore;

using todogamma.Models;

namespace todogamma.Repositories;
public class CategoryRepository : GenericRepository<DeviceContext, Category>
{
    public CategoryRepository(DeviceContext dbContext) 
    : base(dbContext)
    {
    }
    protected override DbSet<Category> DbSet => _dbContext.Categories;
}