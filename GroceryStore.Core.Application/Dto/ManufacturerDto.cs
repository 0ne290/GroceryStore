namespace GroceryStore.Core.Application.Dto;

public class ManufacturerDto : BaseDto
{
    public ManufacturerDto(bool isEmpty = true) : base(isEmpty) { }

    public int Key { get; set; }

    public string Name { get; set; }

    public string Contact { get; set; }

    public int CountryKey { get; set; }

    public int RegionKey { get; set; }

    public int CityKey { get; set; }

    public int StreetKey { get; set; }

    public int Postcode { get; set; }

    public int HouseNumber { get; set; }

    public string HouseLetter { get; set; }
}
