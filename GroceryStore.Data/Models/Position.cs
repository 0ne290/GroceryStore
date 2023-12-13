// ReSharper disable CollectionNeverUpdated.Global

namespace GroceryStore.Data.Models;

public sealed class Position
{
    public int Key { get; set; }

    public string? Name { get; set; }

    public ICollection<Employee> StoreStaff { get; set; } = new List<Employee>();
}
