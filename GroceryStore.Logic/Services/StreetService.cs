using GroceryStore.Data.Dao;
using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;

namespace GroceryStore.Logic.Services;

public class StreetService
{
    public StreetService(StreetDao streets) => _streets = streets;

    public bool AddStreet(StreetDto streetDto)
    {
        if (streetDto.IsEmpty())
            return false;
        
        var street = StreetDtoToStreet(streetDto);

        _streets.Create(street);

        return true;
    }

    public IEnumerable<StreetDto> GetStreets()
    {
        var streets = _streets.GetAll();

        return from street in streets
            select StreetToStreetDto(street);
    }
    
    public bool UpdateStreet(StreetDto streetDto)
    {
        if (streetDto.IsEmpty())
            return false;
        
        var street = StreetDtoToStreet(streetDto);
        
        _streets.Update(street);

        return true;
    }
    
    public bool SaveChanges() => _streets.SaveChanges();

    private static StreetDto StreetToStreetDto(IStreet street) => new StreetDto(street.Key)
    {
        Name = street.Name ?? "NullName", CityKey = street.CityKey ?? -1
    };
    
    private static Street StreetDtoToStreet(StreetDto streetDto) => new Street()
    {
        Name = streetDto.Name == "NullName" ? null : streetDto.Name,
        CityKey = streetDto.CityKey == -1 ? null : streetDto.CityKey
    };

    private readonly StreetDao _streets;
}