namespace GroceryStore.Core.Application.Dto;

public class CountryDto : BaseDto
{
    public CountryDto(bool isEmpty = true) : base(isEmpty) { }

    public int Key { get; set; }

    public string Name { get; set; }
}
