using GroceryStore.Core.Application.Dto;

namespace GroceryStore.Infrastructure.Console;

public class Printer
{
    public void Print<TDto>(IEnumerable<TDto> dtos) where TDto : IDto
    {
        switch (dtos)
        {
            case IEnumerable<CityDto> cityDtos:
                System.Console.WriteLine($"{"Key",-15} {"Name",-15} {"RegionKey",-15}");
    
                foreach (var cityDto in cityDtos)
                    System.Console.WriteLine($"{cityDto.Key,-15} {cityDto.Name,-15} {cityDto.RegionKey,-15}");
    
                break;
            case IEnumerable<CountryDto> countryDtos:
                System.Console.WriteLine($"{"Key",-15} {"Name",-15}");
    
                foreach (var countryDto in countryDtos)
                    System.Console.WriteLine($"{countryDto.Key,-15} {countryDto.Name,-15}");
    
                break;
            case IEnumerable<EmployeeDto> employeeDtos:
                System.Console.WriteLine($"{"Key",-15} {"Surname",-15} {"Name",-15} {"Patronymic",-15} {"StoreKey",-15} {"PositionKey",-15} {"EmploymentDate",-15}");
    
                foreach (var employeeDto in employeeDtos)
                    System.Console.WriteLine($"{employeeDto.Key,-15} {employeeDto.Surname,-15} {employeeDto.Name,-15} {employeeDto.Patronymic,-15} {employeeDto.StoreKey,-15} {employeeDto.PositionKey,-15} {employeeDto.EmploymentDate,-15}");
    
                break;
            case IEnumerable<ManufacturerDto> manufacturerDtos:
                System.Console.WriteLine($"{"Key",-15} {"Name",-15} {"Contact",-15} {"CountryKey",-15} {"RegionKey",-15} {"CityKey",-15}, {"StreetKey",-15} {"Postcode",-15} {"HouseNumber",-15} {"HouseLetter",-15}");
    
                foreach (var manufacturerDto in manufacturerDtos)
                    System.Console.WriteLine($"{manufacturerDto.Key,-15} {manufacturerDto.Name,-15} {manufacturerDto.Contact,-15} {manufacturerDto.CountryKey,-15} {manufacturerDto.RegionKey,-15} {manufacturerDto.CityKey,-15}, {manufacturerDto.StreetKey,-15} {manufacturerDto.Postcode,-15} {manufacturerDto.HouseNumber,-15} {manufacturerDto.HouseLetter,-15}");
    
                break;
            case IEnumerable<PositionDto> positionDtos:
                System.Console.WriteLine($"{"Key",-15} {"Name",-15}");
    
                foreach (var positionDto in positionDtos)
                    System.Console.WriteLine($"{positionDto.Key,-15} {positionDto.Name,-15}");
    
                break;
            case IEnumerable<ProductDto> productDtos:
                System.Console.WriteLine($"{"Key",-15} {"Name",-15} {"BestBefore",-15} {"ManufacturerKey",-15} {"BestBefore",-15}");
    
                foreach (var productDto in productDtos)
                    System.Console.WriteLine($"{productDto.Key,-15} {productDto.Name,-15} {productDto.BestBefore,-15} {productDto.ManufacturerKey,-15} {productDto.BestBefore,-15}");
    
                break;
            case IEnumerable<ProductInStoreDto> productInStoreDtos:
                System.Console.WriteLine($"{"StoreKey",-15} {"ProductKey",-15} {"Quantity",-15} {"WarehouseKey",-15}");
    
                foreach (var productInStoreDto in productInStoreDtos)
                    System.Console.WriteLine($"{productInStoreDto.StoreKey,-15} {productInStoreDto.ProductKey,-15} {productInStoreDto.Quantity,-15} {productInStoreDto.WarehouseKey,-15}");
    
                break;
            case IEnumerable<ProductInWarehouseDto> productInWarehouseDtos:
                System.Console.WriteLine($"{"WarehouseKey",-15} {"ProductKey",-15} {"Quantity",-15} {"DateOfManufacture",-15}");
    
                foreach (var productInWarehouseDto in productInWarehouseDtos)
                    System.Console.WriteLine($"{productInWarehouseDto.WarehouseKey,-15} {productInWarehouseDto.ProductKey,-15} {productInWarehouseDto.Quantity,-15} {productInWarehouseDto.DateOfManufacture,-15}");
    
                break;
            case IEnumerable<RegionDto> regionDtos:
                System.Console.WriteLine($"{"Key",-15} {"Name",-15} {"CountryKey",-15}");
    
                foreach (var regionDto in regionDtos)
                    System.Console.WriteLine($"{regionDto.Key,-15} {regionDto.Name,-15} {regionDto.CountryKey,-15}");
    
                break;
            case IEnumerable<RegularCustomerDto> regularCustomerDtos:
                System.Console.WriteLine($"{"Key",-15} {"Name",-15} {"Address",-15} {"PhoneNumber",-15}");
    
                foreach (var regularCustomerDto in regularCustomerDtos)
                    System.Console.WriteLine($"{regularCustomerDto.Key,-15} {regularCustomerDto.Name,-15} {regularCustomerDto.Address,-15} {regularCustomerDto.PhoneNumber,-15}");
    
                break;
            case IEnumerable<SaleDto> saleDtos:
                System.Console.WriteLine($"{"ProductKey",-15} {"CustomerKey",-15} {"Date",-15} {"Quantity",-15}");
    
                foreach (var saleDto in saleDtos)
                    System.Console.WriteLine($"{saleDto.ProductKey,-15} {saleDto.CustomerKey,-15} {saleDto.Date,-15} {saleDto.Quantity,-15}");
    
                break;
            case IEnumerable<StoreDto> storeDtos:
                System.Console.WriteLine($"{"Key",-15} {"EndOfLease",-15} {"Contact",-15} {"RegionKey",-15} {"CityKey",-15} {"StreetKey",-15} {"Postcode",-15} {"HouseNumber",-15} {"HouseLetter",-15}");
    
                foreach (var storeDto in storeDtos)
                    System.Console.WriteLine($"{storeDto.Key,-15} {storeDto.EndOfLease,-15} {storeDto.Contact,-15} {storeDto.RegionKey,-15} {storeDto.CityKey,-15} {storeDto.StreetKey,-15} {storeDto.Postcode,-15} {storeDto.HouseNumber,-15} {storeDto.HouseLetter,-15}");
    
                break;
            case IEnumerable<StreetDto> streetDtos:
                System.Console.WriteLine($"{"Key",-15} {"Name",-15} {"CityKey",-15}");
    
                foreach (var streetDto in streetDtos)
                    System.Console.WriteLine($"{streetDto.Key,-15} {streetDto.Name,-15} {streetDto.CityKey,-15}");
    
                break;
            case IEnumerable<WarehouseDto> warehouseDtos:
                System.Console.WriteLine($"{"Key",-15} {"EndOfLease",-15} {"Contact",-15} {"RegionKey",-15} {"CityKey",-15} {"StreetKey",-15} {"Postcode",-15} {"HouseNumber",-15} {"HouseLetter",-15}");
    
                foreach (var warehouseDto in warehouseDtos)
                    System.Console.WriteLine($"{warehouseDto.Key,-15} {warehouseDto.EndOfLease,-15} {warehouseDto.Contact,-15} {warehouseDto.RegionKey,-15} {warehouseDto.CityKey,-15} {warehouseDto.StreetKey,-15} {warehouseDto.Postcode,-15} {warehouseDto.HouseNumber,-15} {warehouseDto.HouseLetter,-15}");
    
                break;
            default:
                throw new Exception($"Impossible to print type {typeof(TDto)}");
        }
    }
}