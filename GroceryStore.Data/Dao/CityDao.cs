using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.NullObjects;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class CityDao : BaseDao
{
    public CityDao(GroceryStoreContext dbContext) : base(dbContext) { }

    public void Create(City city) => DbContext.Cities.Add(city);

    public IEnumerable<City> GetAll() => DbContext.Cities.AsNoTracking();

    public ICity GetByKey(int key)
    {
        var city = DbContext.Cities.Find(key);
        
        if (city is null)
            return new NullCity();

        return city;
    }

    public void Update(City city) => DbContext.Cities.Update(city);

    public void Remove(City city) => DbContext.Cities.Remove(city);
}