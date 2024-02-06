using GroceryStore.Core.Application;
using GroceryStore.Core.Domain.Entities;
using GroceryStore.Infrastructure.Console.Interfaces;
using GroceryStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace GroceryStore.Infrastructure.Console;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        if (args.Length < 3)
            throw new Exception("Minimum number of arguments 3");
        
        var connectionString = args[0];
        
        CompositionRoot(connectionString, args[1..]);
        
        var task = Task.Run(() => _controller.ExecuteCommand());
        
        System.Console.WriteLine("Ждем 5 секунд");
        Thread.Sleep(5000);
        System.Console.WriteLine("Закончили ждать 5 секунд");

        await task;
        
        System.Console.Write("Нажмите любую клавишу...");
        System.Console.ReadKey();
    }

    private static void CompositionRoot(string connectionString, string[] command)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GroceryStoreContext>();
 
        var options = optionsBuilder
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .Options;

        var unitOfWork = new UnitOfWork();

        unitOfWork.AddDao(new Dao<City>(new GroceryStoreContext(options)));
        unitOfWork.AddDao(new Dao<Country>(new GroceryStoreContext(options)));
        unitOfWork.AddDao(new Dao<Employee>(new GroceryStoreContext(options)));
        unitOfWork.AddDao(new Dao<Manufacturer>(new GroceryStoreContext(options)));
        unitOfWork.AddDao(new Dao<Position>(new GroceryStoreContext(options)));
        unitOfWork.AddDao(new Dao<Product>(new GroceryStoreContext(options)));
        unitOfWork.AddDao(new Dao<ProductInStore>(new GroceryStoreContext(options)));
        unitOfWork.AddDao(new Dao<ProductInWarehouse>(new GroceryStoreContext(options)));
        unitOfWork.AddDao(new Dao<Region>(new GroceryStoreContext(options)));
        unitOfWork.AddDao(new Dao<RegularCustomer>(new GroceryStoreContext(options)));
        unitOfWork.AddDao(new Dao<Sale>(new GroceryStoreContext(options)));
        unitOfWork.AddDao(new Dao<Store>(new GroceryStoreContext(options)));
        unitOfWork.AddDao(new Dao<Street>(new GroceryStoreContext(options)));
        unitOfWork.AddDao(new Dao<Warehouse>(new GroceryStoreContext(options)));
        
        var controllerCreator = new ControllerCreator();
        
        _controller = controllerCreator.FactoryMethod(command, new EntityService(unitOfWork, new Mapper()), new Parser(), new Printer());
    }

    private static IController _controller;
}