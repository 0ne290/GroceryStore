// ReSharper disable CollectionNeverUpdated.Global

namespace GroceryStore.Data.Models;

public sealed class RegularCustomer
{
    public int Key { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public ICollection<Sale> Purchases { get; set; } = new List<Sale>();
}
