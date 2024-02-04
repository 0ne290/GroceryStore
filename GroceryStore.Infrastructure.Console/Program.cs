using GroceryStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace GroceryStore.Infrastructure.Console;

internal static class Program
{
    private static void Main(string[] args)
    {
        if (args.Length < 3)
            throw new Exception("Minimum number of arguments 3");
        
        var connectionString = args[0];
        
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

        Services.AddDao(new Dao<>(new GroceryStoreContext(options), mapper));

        Services.AddDao(new Dao<>(new GroceryStoreContext(options), mapper));
        
        Services.AddDao(new Dao<>(new GroceryStoreContext(options), mapper));
        
        Services.AddDao(new Dao<>(new GroceryStoreContext(options), mapper));

        Services.AddDao(new Dao<>(new GroceryStoreContext(options), mapper));
        
        Services.AddDao(new Dao<>(new GroceryStoreContext(options), mapper));
        
        Services.AddDao(new Dao<>(new GroceryStoreContext(options), mapper));

        Services.AddDao(new Dao<>(new GroceryStoreContext(options), mapper));
        
        Services.AddDao(new Dao<>(new GroceryStoreContext(options), mapper));
        
        Services.AddDao(new Dao<>(new GroceryStoreContext(options), mapper));

        Services.AddDao(new Dao<>(new GroceryStoreContext(options), mapper));
        
        Services.AddDao(new Dao<>(new GroceryStoreContext(options), mapper));
        
        Services.AddDao(new Dao<>(new GroceryStoreContext(options), mapper));

        Services.AddDao(new Dao<>(new GroceryStoreContext(options), mapper));
    }

    private static readonly UnitOfWork Services = new UnitOfWork();
}