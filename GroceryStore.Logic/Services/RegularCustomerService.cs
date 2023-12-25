using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic.Services;

public class RegularCustomerService
{
    public RegularCustomerService(IDao<RegularCustomerDto> regularCustomers) => _regularCustomers = regularCustomers;

    public bool AddRegularCustomer(RegularCustomerDto regularCustomerDto) => _regularCustomers.Create(regularCustomerDto);

    public IEnumerable<RegularCustomerDto> GetCountries() => _regularCustomers.GetAll();

    public void UpdateCity(RegularCustomerDto regularCustomerDto) => _regularCustomers.Update(regularCustomerDto);
    
    public bool SaveChanges() => _regularCustomers.SaveChanges();

    private readonly IDao<RegularCustomerDto> _regularCustomers;
}