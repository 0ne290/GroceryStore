using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.NullObjects;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class WarehouseDao : BaseDao
{
    public WarehouseDao(GroceryStoreContext dbContext) : base(dbContext) { }

    public void Create(Warehouse warehouse) => DbContext.Warehouses.Add(warehouse);

    public IEnumerable<Warehouse> GetAll() => DbContext.Warehouses.AsNoTracking();

    public IWarehouse GetByKey(int key)
    {
        var warehouse = DbContext.Warehouses.Find(key);
        
        if (warehouse is null)
            return new NullWarehouse();

        return warehouse;
    }

    public void Update(Warehouse warehouse) => DbContext.Warehouses.Update(warehouse);

    public void Remove(Warehouse warehouse) => DbContext.Warehouses.Remove(warehouse);
}