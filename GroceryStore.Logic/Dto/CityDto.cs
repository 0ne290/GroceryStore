namespace GroceryStore.Logic.Dto;

public class CityDto : BaseDto
{
    public CityDto(int key) : base(new [] { key }) { }
    
    public int Key { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }
    
    public string Name { get; set; } = "NullName";

    public int RegionKey { get; set; } = -1;

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