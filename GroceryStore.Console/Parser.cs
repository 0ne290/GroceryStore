using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Console;

public class Parser
{
    public IDto Parse(Type type)
    {
        if (!typeof(IDto).IsAssignableFrom(type))
            throw new ArgumentException("Parsing can only be performed for the IDto type");
        
        if (type == typeof(CityDto))
            return ParseCityDto();
        if (type == typeof(CountryDto))
            return ParseCountryDto();
            
        throw new ArgumentException($"Type {type} is not yet supported for parsing");
    }

    private CityDto ParseCityDto() => Lexemes.Length < 3 ? new CityDto() : new CityDto(Convert.ToInt32(Lexemes[0]))
    {
        Name = Lexemes[1], RegionKey = Convert.ToInt32(Lexemes[2])
    };
    
    private CountryDto ParseCountryDto() => Lexemes.Length < 2 ? new CountryDto() : new CountryDto(Convert.ToInt32(Lexemes[0]))
    {
        Name = Lexemes[1]
    };
    
    public string[] Lexemes { get; set; }
}