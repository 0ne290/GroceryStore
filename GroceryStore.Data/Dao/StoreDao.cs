using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.NullObjects;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class StoreDao : BaseDao
{
    public StoreDao(GroceryStoreContext dbContext) : base(dbContext) { }

    public void Create(Store store) => DbContext.Stores.Add(store);

    public IEnumerable<Store> GetAll() => DbContext.Stores.AsNoTracking();

    public IStore GetByKey(int key)
    {
        var store = DbContext.Stores.Find(key);
        
        if (store is null)
            return new NullStore();

        return store;
    }

    public void Update(Store store) => DbContext.Stores.Update(store);

    public void Remove(Store store) => DbContext.Stores.Remove(store);
}