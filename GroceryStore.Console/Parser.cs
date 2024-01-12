using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Console;

public class Parser
{
    public object[] ParseKey(Type type)
    {
        if (!typeof(IDto).IsAssignableFrom(type))
            throw new ArgumentException("Parsing key can only be performed for the IDto type");
        
        if (type == typeof(CityDto))
            return ParseCityDto();
        if (type == typeof(CountryDto))
            return ParseCountryDto();
        if (type == typeof(EmployeeDto))
            return ParseEmployeeDto();
        if (type == typeof(ManufacturerDto))
            return ParseManufacturerDto();
        if (type == typeof(PositionDto))
            return ParsePositionDto();
        if (type == typeof(ProductDto))
            return ParseProductDto();
        if (type == typeof(ProductInStoreDto))
            return ParseProductInStoreDto();
        if (type == typeof(ProductInWarehouseDto))
            return ParseProductInWarehouseDto();
        if (type == typeof(RegionDto))
            return ParseRegionDto();
        if (type == typeof(RegularCustomerDto))
            return ParseRegularCustomerDto();
        if (type == typeof(SaleDto))
            return ParseSaleDto();
        if (type == typeof(StoreDto))
            return ParseStoreDto();
        if (type == typeof(StreetDto))
            return ParseStreetDto();
        if (type == typeof(WarehouseDto))
            return ParseWarehouseDto();
        
        throw new ArgumentException($"Type {type} is not yet supported for parsing key");
    }
    
    public IDto Parse(Type type)
    {
        if (!typeof(IDto).IsAssignableFrom(type))
            throw new ArgumentException("Parsing can only be performed for the IDto type");
        
        if (type == typeof(CityDto))
            return ParseCityDto();
        if (type == typeof(CountryDto))
            return ParseCountryDto();
        if (type == typeof(EmployeeDto))
            return ParseEmployeeDto();
        if (type == typeof(ManufacturerDto))
            return ParseManufacturerDto();
        if (type == typeof(PositionDto))
            return ParsePositionDto();
        if (type == typeof(ProductDto))
            return ParseProductDto();
        if (type == typeof(ProductInStoreDto))
            return ParseProductInStoreDto();
        if (type == typeof(ProductInWarehouseDto))
            return ParseProductInWarehouseDto();
        if (type == typeof(RegionDto))
            return ParseRegionDto();
        if (type == typeof(RegularCustomerDto))
            return ParseRegularCustomerDto();
        if (type == typeof(SaleDto))
            return ParseSaleDto();
        if (type == typeof(StoreDto))
            return ParseStoreDto();
        if (type == typeof(StreetDto))
            return ParseStreetDto();
        if (type == typeof(WarehouseDto))
            return ParseWarehouseDto();
        
        throw new ArgumentException($"Type {type} is not yet supported for parsing");
    }

    private CityDto ParseCityDto() => Lexemes.Length < 3 ? new CityDto() : new CityDto(Convert.ToInt32(Lexemes[0]))
    {
        Name = Lexemes[1], RegionKey = Convert.ToInt32(Lexemes[2])
    };
    
    private CountryDto ParseCountryDto() => Lexemes.Length < 2 ? new CountryDto() : new CountryDto(Convert.ToInt32(Lexemes[0]))
    {
        Name = Lexemes[1]
    };
    
    private EmployeeDto ParseEmployeeDto() => Lexemes.Length < 5 ? new EmployeeDto() : new EmployeeDto(Convert.ToInt32(Lexemes[0]))
    {
        FullName = Lexemes[1], StoreKey = Convert.ToInt32(Lexemes[2]), PositionKey = Convert.ToInt32(Lexemes[3]),
        EmploymentDate = DateTime.Parse(Lexemes[4])
    };
    
    private ManufacturerDto ParseManufacturerDto() => Lexemes.Length < 10 ? new ManufacturerDto() : new ManufacturerDto(Convert.ToInt32(Lexemes[0]))
    {
        Name = Lexemes[1], Contact = Lexemes[2], CountryKey = Convert.ToInt32(Lexemes[3]),
        RegionKey = Convert.ToInt32(Lexemes[4]), CityKey = Convert.ToInt32(Lexemes[5]),
        StreetKey = Convert.ToInt32(Lexemes[6]), Postcode = Convert.ToInt32(Lexemes[7]),
        HouseNumber = Convert.ToInt32(Lexemes[8]), HouseLetter = Lexemes[9]
    };
    
    private PositionDto ParsePositionDto() => Lexemes.Length < 2 ? new PositionDto() : new PositionDto(Convert.ToInt32(Lexemes[0]))
    {
        Name = Lexemes[1]
    };
    
    private ProductDto ParseProductDto() => Lexemes.Length < 5 ? new ProductDto() : new ProductDto(Convert.ToInt32(Lexemes[0]))
    {
        Name = Lexemes[1], DegreeOfProcessing = Lexemes[2], ManufacturerKey = Convert.ToInt32(Lexemes[3]),
        BestBefore = Convert.ToInt32(Lexemes[4])
    };
    
    private ProductInStoreDto ParseProductInStoreDto() => Lexemes.Length < 4 ? new ProductInStoreDto() : new ProductInStoreDto(Convert.ToInt32(Lexemes[0]), Convert.ToInt32(Lexemes[1]))
    {
        Quantity = Convert.ToInt32(Lexemes[2]), WarehouseKey = Convert.ToInt32(Lexemes[3])
    };
    
    private ProductInWarehouseDto ParseProductInWarehouseDto() => Lexemes.Length < 4 ? new ProductInWarehouseDto() : new ProductInWarehouseDto(Convert.ToInt32(Lexemes[0]), Convert.ToInt32(Lexemes[1]))
    {
        Quantity = Convert.ToInt32(Lexemes[2]), DateOfManufacture = DateTime.Parse(Lexemes[3])
    };
    
    private RegionDto ParseRegionDto() => Lexemes.Length < 3 ? new RegionDto() : new RegionDto(Convert.ToInt32(Lexemes[0]))
    {
        Name = Lexemes[1], CountryKey = Convert.ToInt32(Lexemes[2])
    };
    
    private RegularCustomerDto ParseRegularCustomerDto() => Lexemes.Length < 4 ? new RegularCustomerDto() : new RegularCustomerDto(Convert.ToInt32(Lexemes[0]))
    {
        Name = Lexemes[1], Address = Lexemes[2], PhoneNumber = Lexemes[3]
    };
    
    private SaleDto ParseSaleDto() => Lexemes.Length < 4 ? new SaleDto() : new SaleDto(Convert.ToInt32(Lexemes[0]), Convert.ToInt32(Lexemes[1]), DateTime.Parse(Lexemes[2]))
    {
        Quantity = Convert.ToInt32(Lexemes[3])
    };
    
    private StoreDto ParseStoreDto() => Lexemes.Length < 9 ? new StoreDto() : new StoreDto(Convert.ToInt32(Lexemes[0]))
    {
        EndOfLease = DateTime.Parse(Lexemes[1]), Contact = Lexemes[2], RegionKey = Convert.ToInt32(Lexemes[3]),
        CityKey = Convert.ToInt32(Lexemes[4]), StreetKey = Convert.ToInt32(Lexemes[5]),
        Postcode = Convert.ToInt32(Lexemes[6]), HouseNumber = Convert.ToInt32(Lexemes[7]), HouseLetter = Lexemes[8]
    };
    
    private StreetDto ParseStreetDto() => Lexemes.Length < 3 ? new StreetDto() : new StreetDto(Convert.ToInt32(Lexemes[0]))
    {
        Name = Lexemes[1], CityKey = Convert.ToInt32(Lexemes[2])
    };
    
    private WarehouseDto ParseWarehouseDto() => Lexemes.Length < 9 ? new WarehouseDto() : new WarehouseDto(Convert.ToInt32(Lexemes[0]))
    {
        EndOfLease = DateTime.Parse(Lexemes[1]), Contact = Lexemes[2], RegionKey = Convert.ToInt32(Lexemes[3]),
        CityKey = Convert.ToInt32(Lexemes[4]), StreetKey = Convert.ToInt32(Lexemes[5]),
        Postcode = Convert.ToInt32(Lexemes[6]), HouseNumber = Convert.ToInt32(Lexemes[7]), HouseLetter = Lexemes[8]
    };

    public string[] Lexemes { get; set; } = Array.Empty<string>();
}