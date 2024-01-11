namespace GroceryStore.Logic.Dto;

public class StreetDto : BaseDto
{
    public StreetDto(int key) : base(new [] { key }) { }
    
    public StreetDto() : base(new [] { -1 }) { }
    
    public int Key { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public string Name { get; set; } = "NullName";

    public int CityKey { get; set; } = -1;

    //public ICity? CityKeyNavigation { get; set; }
//
    //public IEnumerable<IStore> Stores { get; set; } = new List<IStore>();
//
    //public IEnumerable<IManufacturer> Manufacturers { get; set; } = new List<IManufacturer>();
//
    //public IEnumerable<IWarehouse> Warehouses { get; set; } = new List<IWarehouse>();
}