using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.NullObjects;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class RegionDao : BaseDao
{
    public RegionDao(GroceryStoreContext dbContext) : base(dbContext) { }

    public void Create(Region region) => DbContext.Regions.Add(region);

    public IEnumerable<Region> GetAll() => DbContext.Regions.AsNoTracking();

    public IRegion GetByKey(int key)
    {
        var region = DbContext.Regions.Find(key);
        
        if (region is null)
            return new NullRegion();

        return region;
    }

    public void Update(Region region) => DbContext.Regions.Update(region);

    public void Remove(Region region) => DbContext.Regions.Remove(region);
}