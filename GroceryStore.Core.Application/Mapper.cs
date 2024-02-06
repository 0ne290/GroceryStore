using GroceryStore.Core.Application.Dto;
using GroceryStore.Core.Application.Interfaces;
using GroceryStore.Core.Domain.Entities;
using GroceryStore.Core.Domain.Interfaces;

namespace GroceryStore.Core.Application;

public class Mapper : IMapper
{
    public IDto EntityToDto(IEntity entity) => entity switch
    {
        City city => CityToCityDto(city),
        Country country => CountryToCountryDto(country),
        Employee employee => EmployeeToEmployeeDto(employee),
        Manufacturer manufacturer => ManufacturerToManufacturerDto(manufacturer),
        Position position => PositinToPositionDto(position),
        Product product => ProductToProductDto(product),
        ProductInStore productInStore => ProductInStoreToProductInStoreDto(productInStore),
        ProductInWarehouse productInWarehouse => ProductInWarehouseToProductInWarehouseDto(productInWarehouse),
        Region region => RegionToRegionDto(region),
        RegularCustomer regularCustomer => RegularCustomerToRegularCustomerDto(regularCustomer),
        Sale sale => SaleToSaleDto(sale),
        Store store => StoreToStoreDto(store),
        Street street => StreetToStreetDto(street),
        Warehouse warehouse => WarehouseToWarehouseDto(warehouse),
        _ => throw new ArgumentException($"There is no corresponding DTO class for the entity \"{entity}\"")
    };
    
    private CityDto CityToCityDto(City city) => new()
    {
        Key = city.Key, Name = city.Name ?? string.Empty, RegionKey = city.RegionKey ?? default
    };
    
    private CountryDto CountryToCountryDto(Country country) => new()
    {
        Key = country.Key, Name = country.Name ?? string.Empty
    };
    
    private EmployeeDto EmployeeToEmployeeDto(Employee employee) => new()
    {
        Key = employee.Key, Surname = employee.Surname ?? string.Empty, Name = employee.Name ?? string.Empty,
        Patronymic = employee.Patronymic ?? string.Empty, StoreKey = employee.StoreKey ?? default,
        PositionKey = employee.PositionKey ?? default, EmploymentDate = employee.EmploymentDate ?? default
    };

    private ManufacturerDto ManufacturerToManufacturerDto(Manufacturer manufacturer) => new()
    {
        Key = manufacturer.Key, Name = manufacturer.Name ?? string.Empty,
        Contact = manufacturer.Contact ?? string.Empty, CountryKey = manufacturer.CountryKey ?? default,
        RegionKey = manufacturer.RegionKey ?? default, CityKey = manufacturer.CityKey ?? default,
        StreetKey = manufacturer.StreetKey ?? default, Postcode = manufacturer.Postcode ?? default,
        HouseNumber = manufacturer.HouseNumber ?? default, HouseLetter = manufacturer.HouseLetter ?? string.Empty
    };
    
    private PositionDto PositinToPositionDto(Position position) => new()
    {
        Key = position.Key, Name = position.Name ?? string.Empty
    };
    
    private ProductDto ProductToProductDto(Product product) => new()
    {
        Key = product.Key, Name = product.Name ?? string.Empty,
        DegreeOfProcessing = product.DegreeOfProcessing ?? string.Empty,
        ManufacturerKey = product.ManufacturerKey ?? default, BestBefore = product.BestBefore ?? default
    };
    
    private ProductInStoreDto ProductInStoreToProductInStoreDto(ProductInStore productInStore) => new()
    {
        StoreKey = productInStore.StoreKey, ProductKey = productInStore.ProductKey,
        Quantity = productInStore.Quantity ?? default, WarehouseKey = productInStore.WarehouseKey ?? default
    };
    
    private ProductInWarehouseDto ProductInWarehouseToProductInWarehouseDto(ProductInWarehouse productInWarehouse) =>
        new()
    {
        WarehouseKey = productInWarehouse.WarehouseKey, ProductKey = productInWarehouse.ProductKey,
        Quantity = productInWarehouse.Quantity ?? default,
        DateOfManufacture = productInWarehouse.DateOfManufacture ?? default
    };
    
    private RegionDto RegionToRegionDto(Region region) => new()
    {
        Key = region.Key, Name = region.Name ?? string.Empty, CountryKey = region.CountryKey ?? default
    };
    
    private RegularCustomerDto RegularCustomerToRegularCustomerDto(RegularCustomer regularCustomer) => new()
    {
        Key = regularCustomer.Key, Name = regularCustomer.Name ?? string.Empty,
        Address = regularCustomer.Address ?? string.Empty, PhoneNumber = regularCustomer.PhoneNumber ?? string.Empty
    };
    
    private SaleDto SaleToSaleDto(Sale sale) => new()
    {
        ProductKey = sale.ProductKey, CustomerKey = sale.CustomerKey, Date = sale.Date,
        Quantity = sale.Quantity ?? default
    };
    
    private StoreDto StoreToStoreDto(Store store) => new()
    {
        Key = store.Key, EndOfLease = store.EndOfLease ?? default, Contact = store.Contact ?? string.Empty,
        RegionKey = store.RegionKey ?? default, CityKey = store.CityKey ?? default,
        StreetKey = store.StreetKey ?? default, Postcode = store.Postcode ?? default,
        HouseNumber = store.HouseNumber ?? default, HouseLetter = store.HouseLetter ?? string.Empty
    };
    
    private StreetDto StreetToStreetDto(Street street) => new()
    {
        Key = street.Key, Name = street.Name ?? string.Empty, CityKey = street.CityKey ?? default
    };
    
    private WarehouseDto WarehouseToWarehouseDto(Warehouse warehouse) => new()
    {
        Key = warehouse.Key, EndOfLease = warehouse.EndOfLease ?? default, Contact = warehouse.Contact ?? string.Empty,
        RegionKey = warehouse.RegionKey ?? default, CityKey = warehouse.CityKey ?? default,
        StreetKey = warehouse.StreetKey ?? default, Postcode = warehouse.Postcode ?? default,
        HouseNumber = warehouse.HouseNumber ?? default, HouseLetter = warehouse.HouseLetter ?? string.Empty
    };
}
