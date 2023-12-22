namespace GroceryStore.Logic.Dto;

public class PositionDto : BaseDto
{
    public PositionDto(int key) : base(new [] { key }) { }
    
    public int Key { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public string Name { get; set; } = "NullName";

    //public IEnumerable<IEmployee> StoreStaff { get; set; } = new List<IEmployee>();
}
