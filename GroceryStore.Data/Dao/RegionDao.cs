using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.NullObjects;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class RegionDao
{
    public RegionDao(IGroceryStoreContext dbContext) => _dbContext = dbContext;

    public void Create(Region region) => _dbContext.Regions.Add(region);

    public IEnumerable<Region> GetAll() => _dbContext.Regions.AsNoTracking();

    public IRegion GetByKey(int key)
    {
        var region = _dbContext.Regions.Find(key);
        
        if (region is null)
            return new NullRegion();

        return region;
    }

    public void Update(Region region) => _dbContext.Regions.Update(region);

    public void Remove(Region region) => _dbContext.Regions.Remove(region);

    public void SaveChanges() => _dbContext.SaveChanges();

    private readonly IGroceryStoreContext _dbContext;
}