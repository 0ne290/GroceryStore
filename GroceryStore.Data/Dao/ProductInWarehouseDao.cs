using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.NullObjects;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class ProductInWarehouseDao : BaseDao
{
    public ProductInWarehouseDao(GroceryStoreContext dbContext) : base(dbContext) { }

    public void Create(ProductInWarehouse productInWarehouse) => DbContext.ProductsInWarehouses.Add(productInWarehouse);

    public IEnumerable<ProductInWarehouse> GetAll() => DbContext.ProductsInWarehouses.AsNoTracking();

    public IProductInWarehouse GetByKey(int warehouseKey, int productKey)
    {
        var productInWarehouse = DbContext.ProductsInWarehouses.Find(new[] { warehouseKey, productKey });
        
        if (productInWarehouse is null)
            return new NullProductInWarehouse();

        return productInWarehouse;
    }

    public void Update(ProductInWarehouse productInWarehouse) => DbContext.ProductsInWarehouses.Update(productInWarehouse);

    public void Remove(ProductInWarehouse productInWarehouse) => DbContext.ProductsInWarehouses.Remove(productInWarehouse);
}