using GroceryStore.Core.Application.Interfaces;

namespace GroceryStore.Core.Application.Dto;

public class CityDto : IDto
{
    public int Key { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public int RegionKey { get; set; }
    
    public bool IsEmpty { get; init; }
}