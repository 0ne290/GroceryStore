namespace GroceryStore.Logic.Dto;

public abstract class BaseDto
{
    protected BaseDto(int[] primaryKey) => PrimaryKey = primaryKey;

    public bool IsEmpty() => PrimaryKey.Any(key => key == -1);
    
    protected int[] PrimaryKey { get; set; }
}