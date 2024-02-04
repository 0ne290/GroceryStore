using GroceryStore.Core.Application.Dto;
using GroceryStore.Core.Domain.Entities;

namespace GroceryStore.Core.Application;

public class Mapper
{
    public object EntityToDto(object entity) => entity switch
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
    
    private CityDto CityToCityDto(City city) => new(city.Key)
    {
        Name = city.Name ?? "NullName", RegionKey = city.RegionKey ?? -1
    };
    
    private CountryDto CountryToCountryDto(Country country) => new(country.Key)
    {
        Name = country.Name ?? "NullName"
    };
    
    private EmployeeDto EmployeeToEmployeeDto(Employee employee) => new(employee.Key)
    {
        Surname = employee.Surname ?? "NullSurname", Name = employee.Name ?? "NullName",
        Patronymic = employee.Patronymic ?? "NullPatronymic", StoreKey = employee.StoreKey ?? -1,
        PositionKey = employee.PositionKey ?? -1, EmploymentDate = employee.EmploymentDate ?? default
    };

    private ManufacturerDto ManufacturerToManufacturerDto(Manufacturer manufacturer) => new(manufacturer.Key)
    {
        Name = manufacturer.Name ?? "NullName", Contact = manufacturer.Contact ?? "NullContact",
        CountryKey = manufacturer.CountryKey ?? -1, RegionKey = manufacturer.RegionKey ?? -1,
        CityKey = manufacturer.CityKey ?? -1, StreetKey = manufacturer.StreetKey ?? -1,
        Postcode = manufacturer.Postcode ?? -1, HouseNumber = manufacturer.HouseNumber ?? -1,
        HouseLetter = manufacturer.HouseLetter ?? "NullHouseLetter"
    };
    
    private PositionDto PositinToPositionDto(Position position) => new(position.Key)
    {
        Name = position.Name ?? "NullName"
    };
    
    private ProductDto ProductToProductDto(Product product) => new(product.Key)
    {
        Name = product.Name ?? "NullName", DegreeOfProcessing = product.DegreeOfProcessing ?? "NullDegreeOfProcessing",
        ManufacturerKey = product.ManufacturerKey ?? -1, BestBefore = product.BestBefore ?? -1
    };
    
    private ProductInStoreDto ProductInStoreToProductInStoreDto(ProductInStore productInStore) => new(productInStore.StoreKey, productInStore.ProductKey)
    {
        Quantity = productInStore.Quantity ?? -1, WarehouseKey = productInStore.WarehouseKey ?? -1
    };
    
    private ProductInWarehouseDto ProductInWarehouseToProductInWarehouseDto(ProductInWarehouse productInWarehouse) => new(productInWarehouse.WarehouseKey, productInWarehouse.ProductKey)
    {
        Quantity = productInWarehouse.Quantity ?? -1, DateOfManufacture = productInWarehouse.DateOfManufacture ?? default
    };
    
    private RegionDto RegionToRegionDto(Region region) => new(region.Key)
    {
        Name = region.Name ?? "NullName", CountryKey = region.CountryKey ?? -1
    };
    
    private RegularCustomerDto RegularCustomerToRegularCustomerDto(RegularCustomer regularCustomer) => new(regularCustomer.Key)
    {
        Name = regularCustomer.Name ?? "NullName", Address = regularCustomer.Address ?? "NullAddress",
        PhoneNumber = regularCustomer.PhoneNumber ?? "NullPhoneNumber"
    };
    
    private SaleDto SaleToSaleDto(Sale sale) => new(sale.ProductKey, sale.CustomerKey, sale.Date)
    {
        Quantity = sale.Quantity ?? -1
    };
    
    private StoreDto StoreToStoreDto(Store store) => new(store.Key)
    {
        EndOfLease = store.EndOfLease ?? default, Contact = store.Contact ?? "NullContact",
        RegionKey = store.RegionKey ?? -1, CityKey = store.CityKey ?? -1, StreetKey = store.StreetKey ?? -1,
        Postcode = store.Postcode ?? -1, HouseNumber = store.HouseNumber ?? -1,
        HouseLetter = store.HouseLetter ?? "NullHouseLetter"
    };
    
    private StreetDto StreetToStreetDto(Street street) => new(street.Key)
    {
        Name = street.Name ?? "NullName", CityKey = street.CityKey ?? -1
    };
    
    private WarehouseDto WarehouseToWarehouseDto(Warehouse warehouse) => new(warehouse.Key)
    {
        EndOfLease = warehouse.EndOfLease ?? default, Contact = warehouse.Contact ?? "NullContact",
        RegionKey = warehouse.RegionKey ?? -1, CityKey = warehouse.CityKey ?? -1, StreetKey = warehouse.StreetKey ?? -1,
        Postcode = warehouse.Postcode ?? -1, HouseNumber = warehouse.HouseNumber ?? -1,
        HouseLetter = warehouse.HouseLetter ?? "NullHouseLetter"
    };
}
