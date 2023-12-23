namespace GroceryStore.Logic.Dto;

public class WarehouseDto : BaseDto
{
    public WarehouseDto(int key) : base(new[] { key }) { }
    
    public int Key { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public DateTime EndOfLease { get; set; } = DateTime.UnixEpoch;

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
    //public IEnumerable<IProductInStore> ProductsInStores { get; set; } = new List<IProductInStore>();
//
    //public IEnumerable<IProductInWarehouse> ProductsInWarehouses { get; set; } = new List<IProductInWarehouse>();
}