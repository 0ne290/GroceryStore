using GroceryStore.Core.Application.Interfaces;

namespace GroceryStore.Core.Application.Dto;

public class EmployeeDto : IDto
{
    public int Key { get; set; }

    public string Surname { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Patronymic { get; set; } = string.Empty;

    public int StoreKey { get; set; }

    public int PositionKey { get; set; }

    public DateTime EmploymentDate { get; set; }
    
    public bool IsEmpty { get; init; }
}
