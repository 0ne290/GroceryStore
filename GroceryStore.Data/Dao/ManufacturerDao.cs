using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.NullObjects;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class ManufacturerDao : BaseDao
{
    public ManufacturerDao(GroceryStoreContext dbContext) : base(dbContext) { }

    public void Create(Manufacturer manufacturer) => DbContext.Manufacturers.Add(manufacturer);

    public IEnumerable<Manufacturer> GetAll() => DbContext.Manufacturers.AsNoTracking();

    public IManufacturer GetByKey(int key)
    {
        var manufacturer = DbContext.Manufacturers.Find(key);
        
        if (manufacturer is null)
            return new NullManufacturer();

        return manufacturer;
    }

    public void Update(Manufacturer manufacturer) => DbContext.Manufacturers.Update(manufacturer);

    public void Remove(Manufacturer manufacturer) => DbContext.Manufacturers.Remove(manufacturer);
}
