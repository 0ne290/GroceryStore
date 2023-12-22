using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.NullObjects;

public class NullRegularCustomer : IRegularCustomer
{
    public int Key => -1;

    public string Name => "NullName";

    public string Address => "NullAddress";

    public string PhoneNumber => "NullPhoneNumber";

    public IEnumerable<ISale> Purchases => Enumerable.Empty<ISale>();
}