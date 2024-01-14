using GroceryStore.Data;
using GroceryStore.Logic;
using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Entities;
using GroceryStore.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace GroceryStore.Console;

internal static class Program
{
    private static void Main(string[] args)
    {
        foreach (var arg in args)
            System.Console.WriteLine(arg);
        
        var connectionString = args.Length > 0
            ? args[0]
            : "server=localhost;user=root;password=!EdCbA21435=;database=GroceryStore";
        
        CompositionRoot(connectionString);
        
        Controller<IEntity, IDto>.ExecuteCommand(args[1..], Services, new Parser(), new Printer());

        System.Console.Write("Нажмите любую клавишу...");
        System.Console.ReadKey();
    }

    private static void CompositionRoot(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GroceryStoreContext>();
 
        var options = optionsBuilder
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .Options;

        var mapper = new Mapper();

        Services.AddDao(new Dao<City, CityDto>(new GroceryStoreContext(options), mapper));

        Services.AddDao(new Dao<Country, CountryDto>(new GroceryStoreContext(options), mapper));
        
        Services.AddDao(new Dao<Employee, EmployeeDto>(new GroceryStoreContext(options), mapper));
        
        Services.AddDao(new Dao<Manufacturer, ManufacturerDto>(new GroceryStoreContext(options), mapper));

        Services.AddDao(new Dao<Position, PositionDto>(new GroceryStoreContext(options), mapper));
        
        Services.AddDao(new Dao<Product, ProductDto>(new GroceryStoreContext(options), mapper));
        
        Services.AddDao(new Dao<ProductInStore, ProductInStoreDto>(new GroceryStoreContext(options), mapper));

        Services.AddDao(new Dao<ProductInWarehouse, ProductInWarehouseDto>(new GroceryStoreContext(options), mapper));
        
        Services.AddDao(new Dao<Region, RegionDto>(new GroceryStoreContext(options), mapper));
        
        Services.AddDao(new Dao<RegularCustomer, RegularCustomerDto>(new GroceryStoreContext(options), mapper));

        Services.AddDao(new Dao<Sale, SaleDto>(new GroceryStoreContext(options), mapper));
        
        Services.AddDao(new Dao<Store, StoreDto>(new GroceryStoreContext(options), mapper));
        
        Services.AddDao(new Dao<Street, StreetDto>(new GroceryStoreContext(options), mapper));

        Services.AddDao(new Dao<Warehouse, WarehouseDto>(new GroceryStoreContext(options), mapper));
    }

    private static readonly UnitOfWork Services = new UnitOfWork();
}