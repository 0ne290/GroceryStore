using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.NullObjects;

public class NullPosition : IPosition
{
    public int Key => -1;

    public string Name => "NullName";

    public IEnumerable<IEmployee> StoreStaff => Enumerable.Empty<IEmployee>();
}