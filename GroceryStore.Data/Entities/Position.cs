// ReSharper disable CollectionNeverUpdated.Global

using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.Entities;

public sealed class Position : IPosition
{
    public int Key { get; set; }

    public string? Name { get; set; }

    public ICollection<IEmployee> StoreStaff { get; set; } = new List<IEmployee>();
}
