namespace GroceryStore.Logic.Dto;

public class CityDto
{
    public int Key { get; set;  }

    public string Name { get; set; } = string.Empty;

    public int RegionKey { get; set; }

    //IRegion? RegionKeyNavigation { get; }
//
    //IEnumerable<IStore> Stores { get; }
//
    //IEnumerable<IManufacturer> Manufacturers { get; }
//
    //IEnumerable<IWarehouse> Warehouses { get; }
//
    //IEnumerable<IStreet> Streets { get; }
}