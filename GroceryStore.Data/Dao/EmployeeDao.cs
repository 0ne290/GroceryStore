using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.NullObjects;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class EmployeeDao
{
    public EmployeeDao(IGroceryStoreContext dbContext) => _dbContext = dbContext;

    public void Create(Employee employee) => _dbContext.Staff.Add(employee);

    public IEnumerable<Employee> GetAll() => _dbContext.Staff.AsNoTracking();

    public IEmployee GetByKey(int key)
    {
        var employee = _dbContext.Staff.Find(key);
        
        if (employee is null)
            return new NullEmployee();

        return employee;
    }

    public void Update(Employee employee) => _dbContext.Staff.Update(employee);

    public void Remove(Employee employee) => _dbContext.Staff.Remove(employee);

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
