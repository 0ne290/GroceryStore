using System.Linq.Expressions;
using GroceryStore.Core.Application.Dto;
using GroceryStore.Infrastructure.Console.Interfaces;

namespace GroceryStore.Infrastructure.Console;

public class Controller<TEntity, TDto> : IController where TDto : IDto where TEntity : IEntity
{
    public static void ExecuteCommand(string[] command, IUnitOfWork unitOfWork, Parser parser, Printer printer)
    {
        var controller = CreateController(command, unitOfWork, parser, printer);

        controller.ExecuteCommand();
    }

    private static IController CreateController(string[] command, IUnitOfWork unitOfWork, Parser parser,
        Printer printer) =>
        command[0] switch
        {
            "City" => new Controller<City, CityDto>(command[1..], unitOfWork, parser, printer),
            "Country" => new Controller<Country, CountryDto>(command[1..], unitOfWork, parser, printer),
            "Employee" => new Controller<Employee, EmployeeDto>(command[1..], unitOfWork, parser, printer),
            "Manufacturer" => new Controller<Manufacturer, ManufacturerDto>(command[1..], unitOfWork, parser, printer),
            "Position" => new Controller<Position, PositionDto>(command[1..], unitOfWork, parser, printer),
            "Product" => new Controller<Product, ProductDto>(command[1..], unitOfWork, parser, printer),
            "ProductInStore" => new Controller<ProductInStore, ProductInStoreDto>(command[1..], unitOfWork, parser, printer),
            "ProductInWarehouse" => new Controller<ProductInWarehouse, ProductInWarehouseDto>(command[1..], unitOfWork, parser, printer),
            "Region" => new Controller<Region, RegionDto>(command[1..], unitOfWork, parser, printer),
            "RegularCustomer" => new Controller<RegularCustomer, RegularCustomerDto>(command[1..], unitOfWork, parser, printer),
            "Sale" => new Controller<Sale, SaleDto>(command[1..], unitOfWork, parser, printer),
            "Store" => new Controller<Store, StoreDto>(command[1..], unitOfWork, parser, printer),
            "Street" => new Controller<Street, StreetDto>(command[1..], unitOfWork, parser, printer),
            "Warehouse" => new Controller<Warehouse, WarehouseDto>(command[1..], unitOfWork, parser, printer),
            _ => throw new Exception("Unable to select database entity. Invalid value entered")
        };
    
    private Controller(string[] command, IUnitOfWork unitOfWork, Parser parser, Printer printer)
    {
        _command = command;
        _unitOfWork = unitOfWork;
        _parser = parser;
        _parser.Lexemes = _command[1..];
        _printer = printer;
    }

    public bool ExecuteCommand() => _command[0] switch
    {
        "Add" => Add(),
        "GetByCriterion" => GetByCriterion(),
        "GetAll" => GetAll(),
        "GetByKey" => GetByKey(),
        "Update" => Update(),
        "Remove" => Remove(),
        _ => Default()
    };

    private bool GetByCriterion()
    {
        var filter = (Expression<Func<TEntity, bool>>)_parser.ParseFilter(typeof(TDto));
        //var orderBy = _parser.ParseSorting(typeof(TDto));

        var dtos = _unitOfWork.Get<TEntity, TDto>(filter);

        foreach (var dto in dtos)
            _printer.Print(new[] { dto });

        return true;
    }

    private bool Add()
    {
        var dto = (TDto)_parser.Parse(typeof(TDto));
        var ret = _unitOfWork.Add<TEntity, TDto>(dto);
        ret = ret && _unitOfWork.SaveChanges<TEntity, TDto>();
                
        System.Console.WriteLine(ret);

        return ret;
    }

    private bool GetAll()
    {
        var dtos = _unitOfWork.GetAll<TEntity, TDto>();

        _printer.Print(dtos);

        return true;
    }
    
    private bool GetByKey()
    {
        var key = _parser.ParseKey(typeof(TDto));
        var dto = _unitOfWork.GetByKey<TEntity, TDto>(key);
        var ret = !dto.IsEmpty();

        if (ret)
            _printer.Print(new[] { dto });

        return ret;
    }

    private bool Update()
    {
        var dto = (TDto)_parser.Parse(typeof(TDto));
        var ret = _unitOfWork.Update<TEntity, TDto>(dto);
        ret = ret && _unitOfWork.SaveChanges<TEntity, TDto>();
                
        System.Console.WriteLine(ret);

        return ret;
    }
    
    private bool Remove()
    {
        var dto = (TDto)_parser.Parse(typeof(TDto));
        var ret = _unitOfWork.Remove<TEntity, TDto>(dto);
        ret = ret && _unitOfWork.SaveChanges<TEntity, TDto>();
                
        System.Console.WriteLine(ret);

        return ret;
    }

    private bool Default()
    {
        System.Console.WriteLine(false);

        return false;
    }

    private readonly string[] _command;

    private readonly Parser _parser;

    private readonly Printer _printer;

    private readonly IUnitOfWork _unitOfWork;
}
