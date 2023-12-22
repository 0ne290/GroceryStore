using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.NullObjects;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class EmployeeDao : BaseDao
{
    public EmployeeDao(GroceryStoreContext dbContext) : base(dbContext) { }

    public void Create(Employee employee) => DbContext.StoreStaff.Add(employee);

    public IEnumerable<Employee> GetAll() => DbContext.StoreStaff.AsNoTracking();

    public IEmployee GetByKey(int key)
    {
        var employee = DbContext.StoreStaff.Find(key);
        
        if (employee is null)
            return new NullEmployee();

        return employee;
    }

    public void Update(Employee employee) => DbContext.StoreStaff.Update(employee);

    public void Remove(Employee employee) => DbContext.StoreStaff.Remove(employee);
}
