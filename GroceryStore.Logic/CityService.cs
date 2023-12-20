using GroceryStore.Data.Dao;
using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;

namespace GroceryStore.Logic;

public class CityService
{
    public CityService(CityDao cities) => _cities = cities;

    public void AddCity(CityDto cityDto)
    {
        var city = CityDtoToCity(cityDto);

        _cities.Create(city);
    }

    public IEnumerable<CityDto> GetCities()
    {
        var cities = _cities.GetAll();

        return from city in cities
            select CityToCityDto(city);
    }

    public void UpdateCity(CityDto cityDto)
    {
        var city = CityDtoToCity(cityDto);
        
        _cities.Update(city);
    }
    
    public bool SaveChanges() => _cities.SaveChanges();

    private CityDto CityToCityDto(ICity city) => new CityDto() { Key = city.Key, Name = city.Name ?? "NullName", RegionKey = city.RegionKey ?? -1 };
    
    private City CityDtoToCity(CityDto cityDto) => new City() { Key = cityDto.Key, Name = cityDto.Name == "NullName" ? null : cityDto.Name, RegionKey = cityDto.RegionKey == -1 ? null : cityDto.RegionKey };

    private readonly CityDao _cities;
}