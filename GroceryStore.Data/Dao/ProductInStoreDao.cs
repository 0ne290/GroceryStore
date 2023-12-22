using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.NullObjects;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class ProductInStoreDao : BaseDao
{
    public ProductInStoreDao(GroceryStoreContext dbContext) : base(dbContext) { }
    
    public void Create(ProductInStore productInStore) => DbContext.ProductsInStores.Add(productInStore);

    public IEnumerable<ProductInStore> GetAll() => DbContext.ProductsInStores.AsNoTracking();

    public IProductInStore GetByKey(int storeKey, int productKey)
    {
        var productInStore = DbContext.ProductsInStores.Find(new[] { storeKey, productKey });
        
        if (productInStore is null)
            return new NullProductInStore();

        return productInStore;
    }

    public void Update(ProductInStore productInStore) => DbContext.ProductsInStores.Update(productInStore);

    public void Remove(ProductInStore productInStore) => DbContext.ProductsInStores.Remove(productInStore);
}