using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.NullObjects;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class ProductDao : BaseDao
{
    public ProductDao(GroceryStoreContext dbContext) : base(dbContext) { }

    public void Create(Product product) => DbContext.Products.Add(product);

    public IEnumerable<Product> GetAll() => DbContext.Products.AsNoTracking();

    public IProduct GetByKey(int key)
    {
        var product = DbContext.Products.Find(key);
        
        if (product is null)
            return new NullProduct();

        return product;
    }

    public void Update(Product product) => DbContext.Products.Update(product);

    public void Remove(Product product) => DbContext.Products.Remove(product);
}