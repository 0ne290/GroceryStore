namespace GroceryStore.Core.Application.Dto;

public abstract class BaseDto
{
    public BaseDto(bool isEmpty = true) => IsEmpty = isEmpty;
    
    public bool IsEmpty { get; }
}