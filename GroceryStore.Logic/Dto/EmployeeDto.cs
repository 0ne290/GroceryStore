namespace GroceryStore.Logic.Dto;

public class EmployeeDto : BaseDto
{
    public EmployeeDto(int key = -1) : base(new [] { key }) { }
    
    public int Key { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public string FullName { get; set; } = "NullFullName";

    public int StoreKey { get; set; } = -1;

    public int PositionKey { get; set; } = -1;

    public DateTime EmploymentDate { get; set; }

    //public IPosition? PositionKeyNavigation { get; set; }

    //public IStore? StoreKeyNavigation { get; set; }
}
