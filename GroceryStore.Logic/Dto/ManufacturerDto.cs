namespace GroceryStore.Logic.Dto;

public class ManufacturerDto : BaseDto
{
    public ManufacturerDto(int key) : base(key) { }

    public string Name { get; set; } = "NullName";

    public string Contact { get; set; } = "NullContact";

    public int CountryKey { get; set; } = -1;

    public int RegionKey { get; set; } = -1;

    public int CityKey { get; set; } = -1;

    public int StreetKey { get; set; } = -1;

    public int Postcode { get; set; } = -1;

    public int HouseNumber { get; set; } = -1;

    public string HouseLetter { get; set; } = "NullHouseLetter";
    
    //public ICountry? CountryKeyNavigation { get; set; }
    
    //public IRegion? RegionKeyNavigation { get; set; }
    
    //public ICity? CityKeyNavigation { get; set; }

    //public IStreet? StreetKeyNavigation { get; set; }

    //public ICollection<IProduct> Products { get; set; } = new List<IProduct>();
}
