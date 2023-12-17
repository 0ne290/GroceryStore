using GroceryStore.Data;
using GroceryStore.Data.Dao;
using GroceryStore.Logic;
using GroceryStore.Logic.Dto;

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

        var cityDto = new CityDto() { Key = 18, Name = "Abobus", RegionKey = 9 };
        
        _cityService.AddCity(cityDto);
        
        _cityService.SaveChanges();

        var cities = _cityService.GetCities();

        foreach (var city in cities)
            System.Console.WriteLine($"Key = {city.Key}; Name = {city.Name}; RegionKey = {city.RegionKey}");
    }

    private static void CompositionRoot(string connectionString)
    {
        _cityService = new CityService(
            new CityDao(
                new MySqlContext(connectionString)));
    }

    private static CityService _cityService;
}