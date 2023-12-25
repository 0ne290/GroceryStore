using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic.Services;

public class EmployeeService
{
    public EmployeeService(IDao<EmployeeDto> staff) => _staff = staff;

    public bool AddEmployee(EmployeeDto employeeDto) => _staff.Create(employeeDto);

    public IEnumerable<EmployeeDto> GetCountries() => _staff.GetAll();

    public void UpdateCity(EmployeeDto employeeDto) => _staff.Update(employeeDto);
    
    public bool SaveChanges() => _staff.SaveChanges();

    private readonly IDao<EmployeeDto> _staff;
}