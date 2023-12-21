using GroceryStore.Data.Dao;
using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;

namespace GroceryStore.Logic.Services;

public class CityService
{
    public CityService(CityDao cities) => _cities = cities;

    public bool AddCity(CityDto cityDto)
    {
        if (cityDto.IsEmpty())
            return false;
        
        var city = CityDtoToCity(cityDto);

        _cities.Create(city);

        return true;
    }

    public IEnumerable<CityDto> GetCities()
    {
        var cities = _cities.GetAll();

        return from city in cities
            select CityToCityDto(city);
    }

    public bool UpdateCity(CityDto cityDto)
    {
        if (cityDto.IsEmpty())
            return false;
        
        var city = CityDtoToCity(cityDto);
        
        _cities.Update(city);

        return true;
    }
    
    public bool SaveChanges() => _cities.SaveChanges();

    private static CityDto CityToCityDto(ICity city) => new CityDto(city.Key) { Name = city.Name ?? "NullName", RegionKey = city.RegionKey ?? -1 };
    
    private static City CityDtoToCity(CityDto cityDto) => new City() { Key = cityDto.Key, Name = cityDto.Name == "NullName" ? null : cityDto.Name, RegionKey = cityDto.RegionKey == -1 ? null : cityDto.RegionKey };

    private readonly CityDao _cities;
}