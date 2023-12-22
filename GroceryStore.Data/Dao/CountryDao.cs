using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.NullObjects;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class CountryDao : BaseDao
{
    public CountryDao(GroceryStoreContext dbContext) : base(dbContext) { }

    public void Create(Country country) => DbContext.Countries.Add(country);

    public IEnumerable<Country> GetAll() => DbContext.Countries.AsNoTracking();

    public ICountry GetByKey(int key)
    {
        var country = DbContext.Countries.Find(key);
        
        if (country is null)
            return new NullCountry();

        return country;
    }

    public void Update(Country country) => DbContext.Countries.Update(country);

    public void Remove(Country country) => DbContext.Countries.Remove(country);
}