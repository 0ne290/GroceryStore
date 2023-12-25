using GroceryStore.Data;
using GroceryStore.Data.Entities;
using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Services;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace GroceryStore.Console;

internal static class Program
{
    private static void Main(string[] args)
    {
        var connectionString = args.Length > 0
            ? args[0]
            : "server=localhost;user=root;password=!EdCbA21435=;database=GroceryStore";
        
        CompositionRoot(connectionString);

        //var cityDto = new CityDto() { Key = 18, Name = "Abobus", RegionKey = -1 };
//
        //_cityService.UpdateCity(cityDto);
        //
        //System.Console.WriteLine(_cityService.SaveChanges());
        
        var countryDto = new CountryDto() { Key = 11, Name = "Russia" };

        _countryService.AddCountry(countryDto);
        
        System.Console.WriteLine(_countryService.SaveChanges());

        var countries = _countryService.GetCountries();

        foreach (var country in countries)
            System.Console.WriteLine($"Key = {country.Key}; Name = {country.Name}");
    }

    private static void CompositionRoot(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GroceryStoreContext>();
 
        var options = optionsBuilder
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .Options;
        
        _cityService = new CityService(
            new Dao<City, CityDto>(
                new GroceryStoreContext(options),
                new Mapper()));
        
        _countryService = new CountryService(
            new Dao<Country, CountryDto>(
                new GroceryStoreContext(options),
                new Mapper()));
    }

    private static CityService _cityService;
    
    private static CountryService _countryService;
}