namespace GroceryStore.Core.Application.Dto;

public class RegionDto : BaseDto
{
    public RegionDto(bool isEmpty = true) : base(isEmpty) { }

    public int Key { get; set; }

    public string Name { get; set; }

    public int CountryKey { get; set; }
}