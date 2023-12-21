namespace GroceryStore.Logic.Dto;

public class PositionDto : BaseDto
{
    public PositionDto(int key) : base(key) { }

    public int Key { get; set; }

    public string Name { get; set; } = "NullName";

    //public IEnumerable<IEmployee> StoreStaff { get; set; } = new List<IEmployee>();
}
