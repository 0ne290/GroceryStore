using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic.Services;

public class CityService
{
    public CityService(IDao<CityDto> cities) => _cities = cities;

    public bool AddCity(CityDto cityDto) => _cities.Create(cityDto);

    public IEnumerable<CityDto> GetCities() => _cities.GetAll();

    public void UpdateCity(CityDto cityDto) => _cities.Update(cityDto);
    
    public bool SaveChanges() => _cities.SaveChanges();

    private readonly IDao<CityDto> _cities;
}