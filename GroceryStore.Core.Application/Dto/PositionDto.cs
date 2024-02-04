namespace GroceryStore.Core.Application.Dto;

public class PositionDto : BaseDto
{
    public PositionDto(bool isEmpty = true) : base(isEmpty) { }

    public int Key { get; set; }

    public string Name { get; set; }
}
