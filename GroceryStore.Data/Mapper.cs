using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Data;

public class Mapper
{
    public IEntity DtoToEntity(IDto dto)
    {
        if (dto is CityDto cityDto)
            return CityDtoToCity(cityDto);
        
        throw new ArgumentException($"There is no corresponding entity in the database for the DTO class \"{dto}\"");
    }
    
    private City CityDtoToCity(CityDto cityDto) => new City()
    {
        Key = cityDto.Key, Name = cityDto.Name == "NullName" ? null : cityDto.Name,
        RegionKey = cityDto.RegionKey == -1 ? null : cityDto.RegionKey
    };
    
    public IDto EntityToDto(IEntity entity)
    {
        if (entity is City city)
            return CityToCityDto(city);
        
        throw new ArgumentException($"There is no corresponding DTO class for the entity \"{entity}\"");
    }
    
    private CityDto CityToCityDto(City city) => new CityDto(city.Key)
    {
        Name = city.Name ?? "NullName", RegionKey = city.RegionKey ?? -1
    };
}