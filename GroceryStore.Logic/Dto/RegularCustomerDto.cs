namespace GroceryStore.Logic.Dto;

public class RegularCustomerDto : BaseDto
{
    public RegularCustomerDto(int key) : base(new[] { key }) { }
    
    public RegularCustomerDto() : base(new[] { -1 }) { }
    
    public int Key { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public string Name { get; set; } = "NullName";

    public string Address { get; set; } = "NullAddress";

    public string PhoneNumber { get; set; } = "NullPhoneNumber";

    //public IEnumerable<ISale> Purchases { get; set; } = new List<ISale>();
}