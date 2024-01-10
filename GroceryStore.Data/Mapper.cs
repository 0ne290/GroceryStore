using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Data;

public class Mapper
{
    public IEntity DtoToEntity(IDto dto) => dto switch
    {
        CityDto cityDto => CityDtoToCity(cityDto),
        CountryDto countryDto => CountryDtoToCountry(countryDto),
        EmployeeDto employeeDto => EmployeeDtoToEmployee(employeeDto),
        ManufacturerDto manufacturerDto => ManufacturerDtoToManufacturer(manufacturerDto),
        PositionDto positionDto => PositinDtoToPosition(positionDto),
        ProductDto productDto => ProductDtoToProduct(productDto),
        ProductInStoreDto productInStoreDto => ProductInStoreDtoToProductInStore(productInStoreDto),
        ProductInWarehouseDto productInWarehouseDto => ProductInWarehouseDtoToProductInWarehouse(productInWarehouseDto),
        RegionDto regionDto => RegionDtoToRegion(regionDto),
        RegularCustomerDto regularCustomerDto => RegularCustomerDtoToRegularCustomer(regularCustomerDto),
        SaleDto saleDto => SaleDtoToSale(saleDto),
        StoreDto storeDto => StoreDtoToStore(storeDto),
        StreetDto streetDto => StreetDtoToStreet(streetDto),
        WarehouseDto warehouseDto => WarehouseDtoToWarehouse(warehouseDto),
        _ => throw new ArgumentException($"There is no corresponding entity in the database for the DTO class \"{dto}\"")
    };
    
    private City CityDtoToCity(CityDto cityDto) => new()
    {
        Key = cityDto.Key, Name = cityDto.Name == "NullName" ? null : cityDto.Name,
        RegionKey = cityDto.RegionKey == -1 ? null : cityDto.RegionKey
    };
    
    private Country CountryDtoToCountry(CountryDto countryDto) => new()
    {
        Key = countryDto.Key, Name = countryDto.Name == "NullName" ? null : countryDto.Name
    };

    private Employee EmployeeDtoToEmployee(EmployeeDto employeeDto) => new()
    {
        Key = employeeDto.Key, FullName = employeeDto.FullName == "NullFullName" ? null : employeeDto.FullName,
        StoreKey = employeeDto.StoreKey == -1 ? null : employeeDto.StoreKey,
        PositionKey = employeeDto.PositionKey == -1 ? null : employeeDto.PositionKey,
        EmploymentDate = employeeDto.EmploymentDate == default ? null : employeeDto.EmploymentDate
    };

    private Manufacturer ManufacturerDtoToManufacturer(ManufacturerDto manufacturerDto) => new()
    {
        Key = manufacturerDto.Key, Name = manufacturerDto.Name == "NullName" ? null : manufacturerDto.Name,
        Contact = manufacturerDto.Contact == "NullContact" ? null : manufacturerDto.Contact,
        CountryKey = manufacturerDto.CountryKey == -1 ? null : manufacturerDto.CountryKey,
        RegionKey = manufacturerDto.RegionKey == -1 ? null : manufacturerDto.RegionKey,
        CityKey = manufacturerDto.CityKey == -1 ? null : manufacturerDto.CityKey,
        StreetKey = manufacturerDto.StreetKey == -1 ? null : manufacturerDto.StreetKey,
        Postcode = manufacturerDto.Postcode == -1 ? null : manufacturerDto.Postcode,
        HouseNumber = manufacturerDto.HouseNumber == -1 ? null : manufacturerDto.HouseNumber,
        HouseLetter = manufacturerDto.HouseLetter == "NullHouseLetter" ? null : manufacturerDto.HouseLetter
    };
    
    private Position PositinDtoToPosition(PositionDto positionDto) => new()
    {
        Key = positionDto.Key, Name = positionDto.Name == "NullName" ? null : positionDto.Name
    };
    
    private Product ProductDtoToProduct(ProductDto productDto) => new()
    {
        Key = productDto.Key, Name = productDto.Name == "NullName" ? null : productDto.Name,
        DegreeOfProcessing = productDto.DegreeOfProcessing == "NullDegreeOfProcessing" ? null : productDto.DegreeOfProcessing,
        ManufacturerKey = productDto.ManufacturerKey == -1 ? null : productDto.ManufacturerKey,
        BestBefore = productDto.BestBefore == -1 ? null : productDto.BestBefore
    };
    
    private ProductInStore ProductInStoreDtoToProductInStore(ProductInStoreDto productInStoreDto) => new()
    {
        StoreKey = productInStoreDto.StoreKey, ProductKey = productInStoreDto.ProductKey,
        Quantity = productInStoreDto.Quantity == -1 ? null : productInStoreDto.Quantity,
        WarehouseKey = productInStoreDto.WarehouseKey == -1 ? null : productInStoreDto.WarehouseKey
    };
    
    private ProductInWarehouse ProductInWarehouseDtoToProductInWarehouse(ProductInWarehouseDto productInWarehouseDto) => new()
    {
        WarehouseKey = productInWarehouseDto.WarehouseKey, ProductKey = productInWarehouseDto.ProductKey,
        Quantity = productInWarehouseDto.Quantity == -1 ? null : productInWarehouseDto.Quantity,
        DateOfManufacture = productInWarehouseDto.DateOfManufacture == default ? null : productInWarehouseDto.DateOfManufacture
    };
    
    private Region RegionDtoToRegion(RegionDto regionDto) => new()
    {
        Key = regionDto.Key, Name = regionDto.Name == "NullName" ? null : regionDto.Name,
        CountryKey = regionDto.CountryKey == -1 ? null : regionDto.CountryKey
    };
    
    private RegularCustomer RegularCustomerDtoToRegularCustomer(RegularCustomerDto regularCustomerDto) => new()
    {
        Key = regularCustomerDto.Key, Name = regularCustomerDto.Name == "NullName" ? null : regularCustomerDto.Name,
        Address = regularCustomerDto.Address == "NullAddress" ? null : regularCustomerDto.Address,
        PhoneNumber = regularCustomerDto.PhoneNumber == "NullPhoneNumber" ? null : regularCustomerDto.PhoneNumber
    };
    
    private Sale SaleDtoToSale(SaleDto saleDto) => new()
    {
        ProductKey = saleDto.ProductKey, CustomerKey = saleDto.CustomerKey, Date = saleDto.Date,
        Quantity = saleDto.Quantity == -1 ? null : saleDto.Quantity
    };
    
    private Store StoreDtoToStore(StoreDto storeDto) => new()
    {
        Key = storeDto.Key, EndOfLease = storeDto.EndOfLease == default ? null : storeDto.EndOfLease,
        Contact = storeDto.Contact == "NullContact" ? null : storeDto.Contact,
        RegionKey = storeDto.RegionKey == -1 ? null : storeDto.RegionKey,
        CityKey = storeDto.CityKey == -1 ? null : storeDto.CityKey,
        StreetKey = storeDto.StreetKey == -1 ? null : storeDto.StreetKey,
        Postcode = storeDto.Postcode == -1 ? null : storeDto.Postcode,
        HouseNumber = storeDto.HouseNumber == -1 ? null : storeDto.HouseNumber,
        HouseLetter = storeDto.HouseLetter == "NullHouseLetter" ? null : storeDto.HouseLetter,
    };
    
    private Street StreetDtoToStreet(StreetDto streetDto) => new()
    {
        Key = streetDto.Key, Name = streetDto.Name == "NullName" ? null : streetDto.Name,
        CityKey = streetDto.CityKey == -1 ? null : streetDto.CityKey
    };
    
    private Warehouse WarehouseDtoToWarehouse(WarehouseDto warehouseDto) => new()
    {
        Key = warehouseDto.Key, EndOfLease = warehouseDto.EndOfLease == default ? null : warehouseDto.EndOfLease,
        Contact = warehouseDto.Contact == "NullContact" ? null : warehouseDto.Contact,
        RegionKey = warehouseDto.RegionKey == -1 ? null : warehouseDto.RegionKey,
        CityKey = warehouseDto.CityKey == -1 ? null : warehouseDto.CityKey,
        StreetKey = warehouseDto.StreetKey == -1 ? null : warehouseDto.StreetKey,
        Postcode = warehouseDto.Postcode == -1 ? null : warehouseDto.Postcode,
        HouseNumber = warehouseDto.HouseNumber == -1 ? null : warehouseDto.HouseNumber,
        HouseLetter = warehouseDto.HouseLetter == "NullHouseLetter" ? null : warehouseDto.HouseLetter,
    };
    
    public IDto EntityToDto(IEntity entity) => entity switch
    {
        City city => CityToCityDto(city),
        Country country => CountryToCountryDto(country),
        _ => throw new ArgumentException($"There is no corresponding DTO class for the entity \"{entity}\"")
    };
    
    private CityDto CityToCityDto(City city) => new(city.Key)
    {
        Name = city.Name ?? "NullName", RegionKey = city.RegionKey ?? -1
    };
    
    private CountryDto CountryToCountryDto(Country country) => new(country.Key)
    {
        Name = country.Name ?? "NullName"
    };
}
