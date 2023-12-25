namespace GroceryStore.Logic.Dto;

public class CountryDto : BaseDto
{
    public CountryDto(int key = -1) : base(new [] { key }) { }
    
    public CountryDto() : this(-1) { }
    
    public int Key { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public string Name { get; set; } = "NullName";

    //public IEnumerable<IManufacturer> Manufacturers { get; set; } = new List<IManufacturer>();

    //public IEnumerable<IRegion> Regions { get; set; } = new List<IRegion>();
}
