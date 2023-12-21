namespace GroceryStore.Logic.Dto;

public class EmployeeDto : BaseDto
{
    public EmployeeDto(int key) : base(key) { }

    public string FullName { get; set; } = "NullFullName";

    public int StoreKey { get; set; } = -1;

    public int PositionKey { get; set; } = -1;

    public DateTime EmploymentDate { get; set; } = DateTime.UnixEpoch;

    //public IPosition? PositionKeyNavigation { get; set; }

    //public IStore? StoreKeyNavigation { get; set; }
}
