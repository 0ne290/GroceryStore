namespace GroceryStore.Logic.Dto;

public abstract class BaseDto
{
    protected BaseDto(int key) => Key = key;
    
    public bool IsEmpty() => Key == -1;
    
    public int Key { get; set; }
}