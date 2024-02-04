namespace GroceryStore.Core.Application.Dto;

public class StreetDto : BaseDto
{
    public StreetDto(bool isEmpty = true) : base(isEmpty) { }

    public int Key { get; set; }

    public string Name { get; set; }

    public int CityKey { get; set; }
}