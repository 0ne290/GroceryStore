using System.Runtime.CompilerServices;
using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Console;

public class Parser
{
    public IDto Parse(Type type)
    {
        if (!typeof(IDto).IsAssignableFrom(type))
            throw new ArgumentException("Parsing can only be performed for the IDto type");
        
        if (type.Equals(typeof(CityDto)))
            return ParseCityDto();
            
        throw new ArgumentException($"Type {type} is not yet supported for parsing");
    }

    private CityDto ParseCityDto()
    {
        return new CityDto();
    }
    
    public string[] Lexemes { get; set; }
}