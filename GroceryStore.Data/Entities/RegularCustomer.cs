namespace GroceryStore.Data.Entities;

public sealed class RegularCustomer
{
    public static RegularCustomer Empty() => new RegularCustomer()
    {
        Key = -1, Name = "NullName", Address = "NullAddress", PhoneNumber = "NullPhoneNumber",
        Purchases = Enumerable.Empty<Sale>()
    };
    
    public int Key { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public IEnumerable<Sale> Purchases { get; set; } = new List<Sale>();
}
