using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.NullObjects;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class SaleDao : BaseDao
{
    public SaleDao(GroceryStoreContext dbContext) : base(dbContext) { }

    public void Create(Sale sale) => DbContext.Sales.Add(sale);

    public IEnumerable<Sale> GetAll() => DbContext.Sales.AsNoTracking();

    public ISale GetByKey(int key)
    {
        var sale = DbContext.Sales.Find(key);
        
        if (sale is null)
            return new NullSale();

        return sale;
    }

    public void Update(Sale sale) => DbContext.Sales.Update(sale);

    public void Remove(Sale sale) => DbContext.Sales.Remove(sale);
}