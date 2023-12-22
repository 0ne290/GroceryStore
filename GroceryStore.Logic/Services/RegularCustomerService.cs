using GroceryStore.Data.Dao;
using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;

namespace GroceryStore.Logic.Services;

public class RegularCustomerService
{
    public RegularCustomerService(RegularCustomerDao regularCustomers) => _regularCustomers = regularCustomers;

    public bool AddRegularCustomer(RegularCustomerDto regularCustomerDto)
    {
        if (regularCustomerDto.IsEmpty())
            return false;
        
        var regularCustomer = RegularCustomerDtoToRegularCustomer(regularCustomerDto);

        _regularCustomers.Create(regularCustomer);

        return true;
    }

    public IEnumerable<RegularCustomerDto> GetRegularCustomers()
    {
        var regularCustomers = _regularCustomers.GetAll();

        return from regularCustomer in regularCustomers
            select RegularCustomerToRegularCustomerDto(regularCustomer);
    }

    public bool UpdateRegularCustomer(RegularCustomerDto regularCustomerDto)
    {
        if (regularCustomerDto.IsEmpty())
            return false;
        
        var regularCustomer = RegularCustomerDtoToRegularCustomer(regularCustomerDto);
        
        _regularCustomers.Update(regularCustomer);

        return true;
    }
    
    public bool SaveChanges() => _regularCustomers.SaveChanges();

    private static RegularCustomerDto RegularCustomerToRegularCustomerDto(IRegularCustomer regularCustomer) => new RegularCustomerDto(regularCustomer.Key)
    {
        Name = regularCustomer.Name ?? "NullName", Address = regularCustomer.Address ?? "NullAddress",
        PhoneNumber = regularCustomer.PhoneNumber ?? "NullPhoneNumber"
    };
    
    private static RegularCustomer RegularCustomerDtoToRegularCustomer(RegularCustomerDto regularCustomerDto) => new RegularCustomer()
    {
        Key = regularCustomerDto.Key, Name = regularCustomerDto.Name == "NullName" ? null : regularCustomerDto.Name,
        Address = regularCustomerDto.Address == "NullAddress" ? null : regularCustomerDto.Address,
        PhoneNumber = regularCustomerDto.PhoneNumber == "NullPhoneNumber" ? null : regularCustomerDto.PhoneNumber
    };

    private readonly RegularCustomerDao _regularCustomers;
}