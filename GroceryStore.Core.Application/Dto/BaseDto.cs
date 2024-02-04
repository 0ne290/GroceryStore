namespace GroceryStore.Core.Application.Dto;

public class BaseDto
{
    public BaseDto(bool isEmpty = true) => IsEmpty = isEmpty;
    
    public bool IsEmpty { get; }
}