namespace GroceryStore.Core.Application.Dto;

public class StoreDto : BaseDto
{
    public StoreDto(bool isEmpty = true) : base(isEmpty) { }

    public int Key { get; set; }

    public DateTime EndOfLease { get; set; }

    public string Contact { get; set; }

    public int RegionKey { get; set; }

    public int CityKey { get; set; }

    public int StreetKey { get; set; }

    public int Postcode { get; set; }

    public int HouseNumber { get; set; }

    public string HouseLetter { get; set; }
}