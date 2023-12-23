using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.NullObjects;

public class NullSale : ISale
{
    public int ProductKey => -1;

    public int CustomerKey => -1;

    public DateTime Date => DateTime.UnixEpoch;

    public int? Quantity => -1;

    public IRegularCustomer CustomerKeyNavigation => new NullRegularCustomer();

    public IProduct ProductKeyNavigation => new NullProduct();
}
