using GroceryStore.Data.Dao;
using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;

namespace GroceryStore.Logic.Services;

public class CountryService
{
    public CountryService(CountryDao countries) => _countries = countries;

    public bool AddCountry(CountryDto countryDto)
    {
        if (countryDto.IsEmpty())
            return false;
        
        var country = CountryDtoToCountry(countryDto);

        _countries.Create(country);

        return true;
    }

    public IEnumerable<CountryDto> GetCountries()
    {
        var countries = _countries.GetAll();

        return from country in countries
            select CountryToCountryDto(country);
    }
    
    public bool UpdateRegion(CountryDto countryDto)
    {
        if (countryDto.IsEmpty())
            return false;
        
        var country = CountryDtoToCountry(countryDto);
        
        _countries.Update(country);

        return true;
    }
    
    public bool SaveChanges() => _countries.SaveChanges();

    private static CountryDto CountryToCountryDto(ICountry country) => new CountryDto(country.Key) { Name = country.Name ?? "NullName" };
    
    private static Country CountryDtoToCountry(CountryDto countryDto) => new Country() { Key = countryDto.Key, Name = countryDto.Name == "NullName" ? null : countryDto.Name };

    private readonly CountryDao _countries;
}
