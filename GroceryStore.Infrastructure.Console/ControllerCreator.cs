using GroceryStore.Core.Application.Dto;
using GroceryStore.Core.Application.Interfaces;
using GroceryStore.Core.Domain.Entities;
using GroceryStore.Infrastructure.Console.Interfaces;

namespace GroceryStore.Infrastructure.Console;

public class ControllerCreator
{
    public IController FactoryMethod(string[] command, IEntityService entityService, Parser parser, Printer printer) =>
        command[0] switch
        {
            "City" => new Controller<City, CityDto>(command[1..], entityService, parser, printer),
            "Country" => new Controller<Country, CountryDto>(command[1..], entityService, parser, printer),
            "Employee" => new Controller<Employee, EmployeeDto>(command[1..], entityService, parser, printer),
            "Manufacturer" => new Controller<Manufacturer, ManufacturerDto>(command[1..], entityService, parser, printer),
            "Position" => new Controller<Position, PositionDto>(command[1..], entityService, parser, printer),
            "Product" => new Controller<Product, ProductDto>(command[1..], entityService, parser, printer),
            "ProductInStore" => new Controller<ProductInStore, ProductInStoreDto>(command[1..], entityService, parser, printer),
            "ProductInWarehouse" => new Controller<ProductInWarehouse, ProductInWarehouseDto>(command[1..], entityService, parser, printer),
            "Region" => new Controller<Region, RegionDto>(command[1..], entityService, parser, printer),
            "RegularCustomer" => new Controller<RegularCustomer, RegularCustomerDto>(command[1..], entityService, parser, printer),
            "Sale" => new Controller<Sale, SaleDto>(command[1..], entityService, parser, printer),
            "Store" => new Controller<Store, StoreDto>(command[1..], entityService, parser, printer),
            "Street" => new Controller<Street, StreetDto>(command[1..], entityService, parser, printer),
            "Warehouse" => new Controller<Warehouse, WarehouseDto>(command[1..], entityService, parser, printer),
            _ => throw new Exception("Unable to select database entity. Invalid value entered")
        };
}