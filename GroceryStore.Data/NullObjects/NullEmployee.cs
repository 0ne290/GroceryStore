using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.NullObjects;

public class NullEmployee : IEmployee
{
    public int Key => -1;

    public string FullName => "NullFullName";

    public int? StoreKey => -1;

    public int? PositionKey => -1;

    public DateTime? EmploymentDate => DateTime.UnixEpoch;

    public IPosition PositionKeyNavigation => new NullPosition();

    public IStore StoreKeyNavigation => new NullStore();
}