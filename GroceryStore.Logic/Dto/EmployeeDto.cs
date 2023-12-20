namespace GroceryStore.Logic.Dto;

public class EmployeeDto
{
    public int Key { get; set; }

    public string FullName { get; set; }

    public int StoreKey { get; set; }

    public int PositionKey { get; set; }

    public DateTime EmploymentDate { get; set; }

    //public IPosition? PositionKeyNavigation { get; set; }

    //public IStore? StoreKeyNavigation { get; set; }
}
