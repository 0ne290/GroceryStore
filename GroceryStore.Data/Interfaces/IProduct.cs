namespace GroceryStore.Data.Interfaces;

public interface IProduct
{
    int Key { get; }

    string? Name { get; }

    string? DegreeOfProcessing { get; }

    int? ManufacturerKey { get; }

    int? BestBefore { get; }

    IManufacturer? ManufacturerKeyNavigation { get; }

    IEnumerable<ISale> Sales { get; }

    IEnumerable<IProductInStore> ProductsInStores { get; }

    IEnumerable<IProductInWarehouse> ProductsInWarehouses { get; }
}