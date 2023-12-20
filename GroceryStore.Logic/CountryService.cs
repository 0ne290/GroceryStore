using GroceryStore.Data.Dao;
using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;

namespace GroceryStore.Logic;

public class CountryService
{
    public CountryService(CountryDao countries) => _countries = countries;

    public void AddCountry(CountryDto countryDto)
    {
        var country = CountryDtoToCountry(countryDto);

        _countries.Create(country);
    }

    public IEnumerable<CountryDto> GetCountries()
    {
        var countries = _countries.GetAll();

        return from country in countries
            select CountryToCountryDto(country);
    }
    
    public void UpdateRegion(CountryDto countryDto)
    {
        var country = CountryDtoToCountry(countryDto);
        
        _regions.Update(country);
    }
    
    public bool SaveChanges() => _regions.SaveChanges();

    private CountryDto CountryToCountryDto(ICountry country) => new CountryDto() { Key = country.Key, Name = country.Name ?? "NullName" };
    
    private Country CountryDtoToCountry(CountryDto countryDto) => new Country() { Key = countryDto.Key, Name = countryDto.Name == "NullName" ? null : countryDto.Name };

    private readonly CountryDao _countries;
}
