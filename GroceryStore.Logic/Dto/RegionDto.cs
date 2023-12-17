namespace GroceryStore.Logic.Dto;

public class RegionDto
{
    public int Key { get; set; }

    public string Name { get; set; }

    public int CountryKey { get; set; }

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