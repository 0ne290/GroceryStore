using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.NullObjects;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class CountryDao
{
    public CountryDao(IGroceryStoreContext dbContext) => _dbContext = dbContext;

    public void Create(Country country) => _dbContext.Countries.Add(country);

    public IEnumerable<Country> GetAll() => _dbContext.Countries.AsNoTracking();

    public ICountry GetByKey(int key)
    {
        var country = _dbContext.Countries.Find(key);
        
        if (country is null)
            return new NullCountry();

        return country;
    }

    public void Update(Country country) => _dbContext.Countries.Update(country);

    public void Remove(Country country) => _dbContext.Countries.Remove(country);

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