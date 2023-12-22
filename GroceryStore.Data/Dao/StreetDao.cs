using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.NullObjects;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class StreetDao : BaseDao
{
    public StreetDao(GroceryStoreContext dbContext) : base(dbContext) { }

    public void Create(Street street) => DbContext.Streets.Add(street);

    public IEnumerable<Street> GetAll() => DbContext.Streets.AsNoTracking();

    public IStreet GetByKey(int key)
    {
        var street = DbContext.Streets.Find(key);
        
        if (street is null)
            return new NullStreet();

        return street;
    }

    public void Update(Street street) => DbContext.Streets.Update(street);

    public void Remove(Street street) => DbContext.Streets.Remove(street);
}