using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic.Services;

public class StreetService
{
    public StreetService(IDao<StreetDto> streets) => _streets = streets;

    public bool AddStreet(StreetDto streetDto) => _streets.Create(streetDto);

    public IEnumerable<StreetDto> GetCountries() => _streets.GetAll();

    public void UpdateCity(StreetDto streetDto) => _streets.Update(streetDto);
    
    public bool SaveChanges() => _streets.SaveChanges();

    private readonly IDao<StreetDto> _streets;
}