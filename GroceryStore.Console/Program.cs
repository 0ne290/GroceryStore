﻿using GroceryStore.Data;
using GroceryStore.Data.Entities;
using GroceryStore.Logic;
using GroceryStore.Logic.Dto;
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

        Services.Add(countryDto);
        
        System.Console.WriteLine(Services.SaveChanges<CountryDto>());

        var countries = Services.GetAll<CountryDto>();

        foreach (var country in countries)
            System.Console.WriteLine($"Key = {country.Key}; Name = {country.Name}");
        
        Services.Dispose();
    }

    private static void CompositionRoot(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GroceryStoreContext>();
 
        var options = optionsBuilder
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .Options;

        Services.AddService(new Service<CityDto>(
            new Dao<City, CityDto>(
                new GroceryStoreContext(options),
                new Mapper())));

        Services.AddService(new Service<CountryDto>(
            new Dao<Country, CountryDto>(
                new GroceryStoreContext(options),
                new Mapper())));
    }

    private static readonly ServiceManager Services = new ServiceManager();
}