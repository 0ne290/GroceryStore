using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.NullObjects;

public class NullProduct : IProduct
{
    public int Key => -1;

    public string Name => "NullName";

    public string DegreeOfProcessing => "NellDegreeOfProcessing";

    public int? ManufacturerKey => -1;

    public int? BestBefore => -1;

    public IManufacturer ManufacturerKeyNavigation => new NullManufacturer();

    public IEnumerable<ISale> Sales => Enumerable.Empty<ISale>();

    public IEnumerable<IProductInStore> ProductsInStores => Enumerable.Empty<IProductInStore>();

    public IEnumerable<IProductInWarehouse> ProductsInWarehouses => Enumerable.Empty<IProductInWarehouse>();
}