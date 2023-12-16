using GroceryStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data;

public interface IGroceryStoreContext
{
    DbSet<Country> Countries { get; set; }
    
    DbSet<Region> Regions { get; set; }

    DbSet<City> Cities { get; set; }
    
    DbSet<Street> Streets { get; set; }
    
    DbSet<Store> Stores { get; set; }
    
    DbSet<Warehouse> Warehouses { get; set; }
    
    DbSet<Product> Products { get; set; }
    
    DbSet<ProductInStore> ProductsInStores { get; set; }
    
    DbSet<ProductInWarehouse> ProductsInWarehouses { get; set; }

    DbSet<Position> Positions { get; set; }

    DbSet<Employee> StoreStaff { get; set; }

    DbSet<RegularCustomer> RegularCustomers { get; set; }

    DbSet<Sale> Sales { get; set; }

    DbSet<Manufacturer> Manufacturers { get; set; }
}