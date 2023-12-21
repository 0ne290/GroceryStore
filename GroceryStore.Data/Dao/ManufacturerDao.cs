using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.NullObjects;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class ManufacturerDao
{
    public ManufacturerDao(GroceryStoreContext dbContext) => _dbContext = dbContext;

    public void Create(Manufacturer manufacturer) => _dbContext.Manufacturers.Add(manufacturer);

    public IEnumerable<Manufacturer> GetAll() => _dbContext.Manufacturers.AsNoTracking();

    public IManufacturer GetByKey(int key)
    {
        var manufacturer = _dbContext.Manufacturers.Find(key);
        
        if (manufacturer is null)
            return new NullManufacturer();

        return manufacturer;
    }

    public void Update(Manufacturer manufacturer) => _dbContext.Manufacturers.Update(manufacturer);

    public void Remove(Manufacturer manufacturer) => _dbContext.Manufacturers.Remove(manufacturer);

    public bool SaveChanges()
    {
        try
        {
            _dbContext.SaveChanges();
        }
        catch
        {
            return false;
        }

        return true;
    }

    private readonly GroceryStoreContext _dbContext;
}
