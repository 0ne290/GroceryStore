namespace GroceryStore.Logic.Dto;

public class CountryDto : BaseDto
{
    public CountryDto(int key) : base(key) { }

    public string Name { get; set; } = "NullName";

    //public IEnumerable<IManufacturer> Manufacturers { get; set; } = new List<IManufacturer>();

    //public IEnumerable<IRegion> Regions { get; set; } = new List<IRegion>();
}
