namespace GroceryStore.Core.Application.Dto;

public class EmployeeDto : BaseDto
{
    public EmployeeDto(bool isEmpty = true) : base(isEmpty) { }

    public int Key { get; set; }

    public string Surname { get; set; }

    public string Name { get; set; }

    public string Patronymic { get; set; }

    public int StoreKey { get; set; }

    public int PositionKey { get; set; }

    public DateTime EmploymentDate { get; set; }
}
