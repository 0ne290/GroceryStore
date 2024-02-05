using System.Linq.Expressions;
using GroceryStore.Core.Application.Dto;
using GroceryStore.Core.Application.Interfaces;
using GroceryStore.Core.Domain.Entities;
using GroceryStore.Core.Domain.Interfaces;

namespace GroceryStore.Infrastructure.Console;

public class Parser
{
    public object ParseFilter(Type type)
    {
        if (type == typeof(EmployeeDto))
            return ParseFilterEmployee();
        if (type == typeof(SaleDto))
            return ParseFilterProduct();
        
        throw new ArgumentException($"Type {type} is not yet supported for parsing filter");
    }
    
    private Expression<Func<Employee, bool>> ParseFilterEmployee()
    {
        var before = DateTime.Now.AddDays(-Convert.ToInt32(Lexemes[0]));

        Expression<Func<Employee, bool>> ret = Lexemes.Length < 1 ? _ => false : employee => employee.EmploymentDate >= before;

        return ret;
    }
    
    private Expression<Func<Product, bool>> ParseFilterProduct() => Lexemes.Length < 1 ? _ => false : product => product.DegreeOfProcessing == Lexemes[0];
    
    //public object[] ParseSorting(Type type)
    //{
    //    if (!typeof(IDto).IsAssignableFrom(type))
    //        throw new ArgumentException("Parsing key can only be performed for the IDto type");
//
    //    if (type == typeof(ProductInStoreDto))
    //        return ParseIntKey(2);
    //    if (type == typeof(ProductInWarehouseDto))
    //        return ParseIntKey(2);
    //    if (type == typeof(SaleDto))
    //        return ParseKeySaleDto();
    //    
    //    throw new ArgumentException($"Type {type} is not yet supported for parsing key");
    //}
    
    public object[] ParseKey(Type type)
    {
        if (!typeof(IDto).IsAssignableFrom(type))
            throw new ArgumentException("Parsing key can only be performed for the IDto type");

        if (type == typeof(ProductInStoreDto))
            return ParseIntKey(2);
        if (type == typeof(ProductInWarehouseDto))
            return ParseIntKey(2);
        if (type == typeof(SaleDto))
            return ParseKeySale();
        
        return ParseIntKey(1);
    }
    
    private object[] ParseKeySale()
    {
        if (Lexemes.Length < 3)
            return Array.Empty<object>();

        var ret = new object[3];
        for (var i = 0; i < 2; i++)
            ret[i] = Convert.ToInt32(Lexemes[i]);
        ret[2] = DateTime.Parse(Lexemes[2]);

        return ret;
    }

    private object[] ParseIntKey(int length)
    {
        if (Lexemes.Length < length)
            return Array.Empty<object>();

        var ret = new object[length];
        for (var i = 0; i < length; i++)
            ret[i] = Convert.ToInt32(Lexemes[i]);

        return ret;
    }
    
    public IEntity Parse(Type type)
    {
        if (type == typeof(City))
            return ParseCity();
        if (type == typeof(Country))
            return ParseCountry();
        if (type == typeof(Employee))
            return ParseEmployee();
        if (type == typeof(Manufacturer))
            return ParseManufacturer();
        if (type == typeof(Position))
            return ParsePosition();
        if (type == typeof(Product))
            return ParseProduct();
        if (type == typeof(ProductInStore))
            return ParseProductInStore();
        if (type == typeof(ProductInWarehouse))
            return ParseProductInWarehouse();
        if (type == typeof(Region))
            return ParseRegion();
        if (type == typeof(RegularCustomer))
            return ParseRegularCustomer();
        if (type == typeof(Sale))
            return ParseSale();
        if (type == typeof(Store))
            return ParseStore();
        if (type == typeof(Street))
            return ParseStreet();
        if (type == typeof(Warehouse))
            return ParseWarehouse();
        
        throw new ArgumentException($"Type {type} is not yet supported for parsing");
    }

    private City ParseCity() => Lexemes.Length < 3 ? new City() : new City
    {
        Key = Convert.ToInt32(Lexemes[0]), Name = Lexemes[1], RegionKey = Convert.ToInt32(Lexemes[2])
    };
    
    private Country ParseCountry() => Lexemes.Length < 2 ? new Country() : new Country
    {
        Key = Convert.ToInt32(Lexemes[0]), Name = Lexemes[1]
    };
    
    private Employee ParseEmployee() => Lexemes.Length < 7 ? new Employee() : new Employee
    {
        Key = Convert.ToInt32(Lexemes[0]), Surname = Lexemes[1], Name = Lexemes[2], Patronymic = Lexemes[3],
        StoreKey = Convert.ToInt32(Lexemes[4]), PositionKey = Convert.ToInt32(Lexemes[5]),
        EmploymentDate = DateTime.Parse(Lexemes[6])
    };
    
    private Manufacturer ParseManufacturer() => Lexemes.Length < 10 ? new Manufacturer() : new Manufacturer
    {
        Key = Convert.ToInt32(Lexemes[0]), Name = Lexemes[1], Contact = Lexemes[2],
        CountryKey = Convert.ToInt32(Lexemes[3]), RegionKey = Convert.ToInt32(Lexemes[4]),
        CityKey = Convert.ToInt32(Lexemes[5]), StreetKey = Convert.ToInt32(Lexemes[6]),
        Postcode = Convert.ToInt32(Lexemes[7]), HouseNumber = Convert.ToInt32(Lexemes[8]), HouseLetter = Lexemes[9]
    };
    
    private Position ParsePosition() => Lexemes.Length < 2 ? new Position() : new Position
    {
        Key = Convert.ToInt32(Lexemes[0]), Name = Lexemes[1]
    };
    
    private Product ParseProduct() => Lexemes.Length < 5 ? new Product() : new Product
    {
        Key = Convert.ToInt32(Lexemes[0]), Name = Lexemes[1], DegreeOfProcessing = Lexemes[2],
        ManufacturerKey = Convert.ToInt32(Lexemes[3]), BestBefore = Convert.ToInt32(Lexemes[4])
    };
    
    private ProductInStore ParseProductInStore() => Lexemes.Length < 4 ? new ProductInStore() : new ProductInStore
    {
        StoreKey = Convert.ToInt32(Lexemes[0]), ProductKey = Convert.ToInt32(Lexemes[1]),
        Quantity = Convert.ToInt32(Lexemes[2]), WarehouseKey = Convert.ToInt32(Lexemes[3])
    };
    
    private ProductInWarehouse ParseProductInWarehouse() => Lexemes.Length < 4 ? new ProductInWarehouse()
        : new ProductInWarehouse
    {
        WarehouseKey = Convert.ToInt32(Lexemes[0]), ProductKey = Convert.ToInt32(Lexemes[1]),
        Quantity = Convert.ToInt32(Lexemes[2]), DateOfManufacture = DateTime.Parse(Lexemes[3])
    };
    
    private Region ParseRegion() => Lexemes.Length < 3 ? new Region() : new Region
    {
        Key = Convert.ToInt32(Lexemes[0]), Name = Lexemes[1], CountryKey = Convert.ToInt32(Lexemes[2])
    };
    
    private RegularCustomer ParseRegularCustomer() => Lexemes.Length < 4 ? new RegularCustomer() : new RegularCustomer
    {
        Key = Convert.ToInt32(Lexemes[0]), Name = Lexemes[1], Address = Lexemes[2], PhoneNumber = Lexemes[3]
    };
    
    private Sale ParseSale() => Lexemes.Length < 4 ? new Sale() : new Sale
    {
        ProductKey = Convert.ToInt32(Lexemes[0]), CustomerKey = Convert.ToInt32(Lexemes[1]),
        Date = DateTime.Parse(Lexemes[2]), Quantity = Convert.ToInt32(Lexemes[3])
    };
    
    private Store ParseStore() => Lexemes.Length < 9 ? new Store() : new Store
    {
        Key = Convert.ToInt32(Lexemes[0]), EndOfLease = DateTime.Parse(Lexemes[1]), Contact = Lexemes[2],
        RegionKey = Convert.ToInt32(Lexemes[3]), CityKey = Convert.ToInt32(Lexemes[4]),
        StreetKey = Convert.ToInt32(Lexemes[5]), Postcode = Convert.ToInt32(Lexemes[6]),
        HouseNumber = Convert.ToInt32(Lexemes[7]), HouseLetter = Lexemes[8]
    };
    
    private Street ParseStreet() => Lexemes.Length < 3 ? new Street() : new Street
    {
        Key = Convert.ToInt32(Lexemes[0]), Name = Lexemes[1], CityKey = Convert.ToInt32(Lexemes[2])
    };
    
    private Warehouse ParseWarehouse() => Lexemes.Length < 9 ? new Warehouse() : new Warehouse
    {
        Key = Convert.ToInt32(Lexemes[0]), EndOfLease = DateTime.Parse(Lexemes[1]), Contact = Lexemes[2],
        RegionKey = Convert.ToInt32(Lexemes[3]), CityKey = Convert.ToInt32(Lexemes[4]),
        StreetKey = Convert.ToInt32(Lexemes[5]), Postcode = Convert.ToInt32(Lexemes[6]),
        HouseNumber = Convert.ToInt32(Lexemes[7]), HouseLetter = Lexemes[8]
    };

    public string[] Lexemes { get; set; } = Array.Empty<string>();
}