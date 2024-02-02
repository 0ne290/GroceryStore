using GroceryStore.Domain.Interfaces;

namespace GroceryStore.Logic.Entities;

public sealed class RegularCustomer : IEntity
{
    public int Key { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public IEnumerable<Sale> Purchases { get; set; } = new List<Sale>();
}
