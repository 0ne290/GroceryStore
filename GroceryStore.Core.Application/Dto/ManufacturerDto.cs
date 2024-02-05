using GroceryStore.Core.Application.Interfaces;

namespace GroceryStore.Core.Application.Dto;

public class ManufacturerDto : IDto
{
    public int Key { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Contact { get; set; } = string.Empty;

    public int CountryKey { get; set; }

    public int RegionKey { get; set; }

    public int CityKey { get; set; }

    public int StreetKey { get; set; }

    public int Postcode { get; set; }

    public int HouseNumber { get; set; }

    public string HouseLetter { get; set; } = string.Empty;
    
    public bool IsEmpty { get; init; }
}
