using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic.Services;

public class CountryService
{
    public CountryService(IDao<CountryDto> countries) => _countries = countries;

    public bool AddCountry(CountryDto countryDto) => _countries.Create(countryDto);

    public IEnumerable<CountryDto> GetCountries() => _countries.GetAll();

    public void UpdateCountry(CountryDto countryDto) => _countries.Update(countryDto);
    
    public bool SaveChanges() => _countries.SaveChanges();

    private readonly IDao<CountryDto> _countries;
}