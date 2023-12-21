using GroceryStore.Data.Dao;
using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;

namespace GroceryStore.Logic.Services;

public class EmployeeService
{
    public EmployeeService(EmployeeDao staff) => _staff = staff;

    public bool AddEmployee(EmployeeDto employeeDto)
    {
        if (employeeDto.IsEmpty())
            return false;
        
        var employee = EmployeeDtoToEmployee(employeeDto);

        _staff.Create(employee);

        return true;
    }

    public IEnumerable<EmployeeDto> GetStaff()
    {
        var staff = _staff.GetAll();

        return from employee in staff
            select EmployeeToEmployeeDto(employee);
    }

    public bool UpdateEmployee(EmployeeDto employeeDto)
    {
        if (employeeDto.IsEmpty())
            return false;
        
        var employee = EmployeeDtoToEmployee(employeeDto);
        
        _staff.Update(employee);

        return true;
    }
    
    public bool SaveChanges() => _staff.SaveChanges();

    private static EmployeeDto EmployeeToEmployeeDto(IEmployee employee) => new EmployeeDto(employee.Key)
    {
        FullName = employee.FullName ?? "NullFullName", StoreKey = employee.StoreKey ?? -1,
        PositionKey = employee.PositionKey ?? -1, EmploymentDate = employee.EmploymentDate ?? DateTime.UnixEpoch
    };
    
    private static Employee EmployeeDtoToEmployee(EmployeeDto employeeDto) => new Employee()
    {
        Key = employeeDto.Key, FullName = employeeDto.FullName == "NullFullName" ? null : employeeDto.FullName,
        StoreKey = employeeDto.StoreKey == -1 ? null : employeeDto.StoreKey,
        PositionKey = employeeDto.PositionKey == -1 ? null : employeeDto.PositionKey,
        EmploymentDate = employeeDto.EmploymentDate.Equals(DateTime.UnixEpoch) ? null : employeeDto.EmploymentDate
    };

    private readonly EmployeeDao _staff;
}