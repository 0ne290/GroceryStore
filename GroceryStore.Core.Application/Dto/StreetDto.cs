using GroceryStore.Core.Application.Interfaces;

namespace GroceryStore.Core.Application.Dto;

public class StreetDto : IDto
{
    public int Key { get; set; }

    public string Name { get; set; } = string.Empty;

    public int CityKey { get; set; }
    
    public bool IsEmpty { get; init; }
}