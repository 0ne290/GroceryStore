using GroceryStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Interfaces;

public abstract class IGroceryStoreContext : DbContext
{
    public DbSet<Country> Countries { get; set; }
    
    public DbSet<Region> Regions { get; set; }
    
    public DbSet<City> Cities { get; set; }
    
    public DbSet<Street> Streets { get; set; }
    
    public DbSet<Store> Stores { get; set; }
    
    public DbSet<Warehouse> Warehouses { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<ProductInStore> ProductsInStores { get; set; }
    
    public DbSet<ProductInWarehouse> ProductsInWarehouses { get; set; }
    
    public DbSet<Position> Positions { get; set; }
    
    public DbSet<Employee> StoreStaff { get; set; }
    
    public DbSet<RegularCustomer> RegularCustomers { get; set; }
    
    public DbSet<Sale> Sales { get; set; }
    
    public DbSet<Manufacturer> Manufacturers { get; set; }
}