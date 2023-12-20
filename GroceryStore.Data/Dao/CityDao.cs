using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.NullObjects;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class CityDao
{
    public CityDao(IGroceryStoreContext dbContext) => _dbContext = dbContext;

    public void Create(City city) => _dbContext.Cities.Add(city);

    public IEnumerable<City> GetAll() => _dbContext.Cities.AsNoTracking();

    public ICity GetByKey(int key)
    {
        var city = _dbContext.Cities.Find(key);
        
        if (city is null)
            return new NullCity();

        return city;
    }

    public void Update(City city) => _dbContext.Cities.Update(city);

    public void Remove(City city) => _dbContext.Cities.Remove(city);

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

    private readonly IGroceryStoreContext _dbContext;
}