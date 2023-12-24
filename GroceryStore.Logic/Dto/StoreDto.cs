namespace GroceryStore.Logic.Dto;

public class StoreDto : BaseDto
{
    public StoreDto(int key = -1) : base(new [] { key }) { }
    
    public int Key { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public DateTime EndOfLease { get; set; }

    public string Contact { get; set; } = "NullContact";

    public int RegionKey { get; set; } = -1;

    public int CityKey { get; set; } = -1;

    public int StreetKey { get; set; } = -1;

    public int Postcode { get; set; } = -1;

    public int HouseNumber { get; set; } = -1;

    public string HouseLetter { get; set; } = "NullHouseLetter";

    //public IRegion? RegionKeyNavigation { get; set; }
    //
    //public ICity? CityKeyNavigation { get; set; }
//
    //public IStreet? StreetKeyNavigation { get; set; }
//
    //public IEnumerable<IEmployee> Staff { get; set; } = new List<IEmployee>();
//
    //public IEnumerable<IProductInStore> Products { get; set; } = new List<IProductInStore>();
}