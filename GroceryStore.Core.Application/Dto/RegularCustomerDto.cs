namespace GroceryStore.Core.Application.Dto;

public class RegularCustomerDto : BaseDto
{
    public RegularCustomerDto(bool isEmpty = true) : base(isEmpty) { }

    public int Key { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }
}