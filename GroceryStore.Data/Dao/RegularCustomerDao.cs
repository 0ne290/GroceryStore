using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.NullObjects;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class RegularCustomerDao : BaseDao
{
    public RegularCustomerDao(GroceryStoreContext dbContext) : base(dbContext) { }

    public void Create(RegularCustomer regularCustomer) => DbContext.RegularCustomers.Add(regularCustomer);

    public IEnumerable<RegularCustomer> GetAll() => DbContext.RegularCustomers.AsNoTracking();

    public IRegularCustomer GetByKey(int key)
    {
        var regularCustomer = DbContext.RegularCustomers.Find(key);
        
        if (regularCustomer is null)
            return new NullRegularCustomer();

        return regularCustomer;
    }

    public void Update(RegularCustomer regularCustomer) => DbContext.RegularCustomers.Update(regularCustomer);

    public void Remove(RegularCustomer regularCustomer) => DbContext.RegularCustomers.Remove(regularCustomer);
}