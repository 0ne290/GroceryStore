using GroceryStore.Data.Dao;
using GroceryStore.Data.Entities;
using GroceryStore.Logic.Dto;

namespace GroceryStore.Logic;

public class CityService
{
    public CityService(CityDao cities, RegionDao regions, CountryDao countries)
    {
        _cities = cities;
        _regions = regions;
        _countries = countries;
    }

    public void AddCity(CityDto cityDto, int regionKey)
    {
        var city = CityDtoToCity(cityDto);

        var region = _regions.GetByKey(regionKey);

        city.RegionKeyNavigation = region;

        _cities.Create(city);
    }

    public IEnumerable<CityDto> GetCities()
    {
        var cities = _cities.GetAll();

        return from city in cities
            select CityToCityDto(city);
    }
    
    public void SaveChanges() => _cities.SaveChanges();

    private CityDto CityToCityDto(City city) => new CityDto() { Key = city.Key, Name = city.Name ?? "NullName", RegionKey = city.RegionKey ?? -1 };
    
    private City CityDtoToCity(CityDto cityDto) => new City() { Key = cityDto.Key, Name = cityDto.Name, RegionKey = cityDto.RegionKey };

    private readonly CityDao _cities;
    
    private readonly RegionDao _regions;
    
    private readonly CountryDao _countries;
}