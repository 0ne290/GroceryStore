namespace GroceryStore.Core.Application.Dto;

public class CityDto : BaseDto
{
    public CityDto(bool isEmpty = true) : base(isEmpty) { }

    public int Key { get; set; }
    
    public string Name { get; set; }

    public int RegionKey { get; set; }
}