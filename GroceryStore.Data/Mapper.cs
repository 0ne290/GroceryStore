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