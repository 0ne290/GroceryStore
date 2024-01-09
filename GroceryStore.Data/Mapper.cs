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
        _ => throw new ArgumentException($"There is no corresponding entity in the database for the DTO class \"{dto}\"")
    };
    
    private City CityDtoToCity(CityDto cityDto) => new City()
    {
        Key = cityDto.Key, Name = cityDto.Name == "NullName" ? null : cityDto.Name,
        RegionKey = cityDto.RegionKey == -1 ? null : cityDto.RegionKey
    };
    
    private Country CountryDtoToCountry(CountryDto countryDto) => new Country()
    {
        Key = countryDto.Key, Name = countryDto.Name == "NullName" ? null : countryDto.Name
    };

    private Employee EmployeeDtoToEmployee(EmployeeDto employeeDto) => new Employee()
    {
        Key = employeeDto.Key, FullName = employeeDto.FullName == "NullFullName" ? null : employeeDto.FullName,
        StoreKey = employeeDto.StoreKey == -1 ? null : employeeDto.StoreKey,
        PositionKey = employeeDto.PositionKey == -1 ? null : employeeDto.PositionKey,
        EmploymentDate = employeeDto.EmploymentDate == default(DateTime) ? null : employeeDto.EmploymentDate
    };

    private Manufacturer ManufacturerDtoToManufacturer(ManufacturerDto manufacturerDto) => new Manufacturer()
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
    
    public IDto EntityToDto(IEntity entity) => entity switch
    {
        City city => CityToCityDto(city),
        Country country => CountryToCountryDto(country),
        _ => throw new ArgumentException($"There is no corresponding DTO class for the entity \"{entity}\"")
    };
    
    private CityDto CityToCityDto(City city) => new CityDto(city.Key)
    {
        Name = city.Name ?? "NullName", RegionKey = city.RegionKey ?? -1
    };
    
    private CountryDto CountryToCountryDto(Country country) => new CountryDto(country.Key)
    {
        Name = country.Name ?? "NullName"
    };
}
