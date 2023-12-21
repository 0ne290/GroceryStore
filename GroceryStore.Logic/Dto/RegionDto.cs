namespace GroceryStore.Logic.Dto;

public class RegionDto : BaseDto
{
    public RegionDto(int key) : base(key) { }

    public string Name { get; set; } = "NullName";

    public int CountryKey { get; set; } = -1;

    //public IEnumerable<ICity> Cities { get; set; } = new List<ICity>();
//
    //public ICountry? CountryKeyNavigation { get; set; }
//
    //public IEnumerable<IStore> Stores { get; set; } = new List<IStore>();
//
    //public IEnumerable<IManufacturer> Manufacturers { get; set; } = new List<IManufacturer>();
//
    //public IEnumerable<IWarehouse> Warehouses { get; set; } = new List<IWarehouse>();
}