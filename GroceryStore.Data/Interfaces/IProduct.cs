namespace GroceryStore.Data.Interfaces;

public interface IProduct
{
    int? Key { get; }

    string? Name { get; }

    string? DegreeOfProcessing { get; }

    int? ManufacturerKey { get; }

    int? BestBefore { get; }

    IManufacturer? ManufacturerKeyNavigation { get; }

    ICollection<ISale> Sales { get; }

    ICollection<IProductInStore> ProductsInStores { get; }

    ICollection<IProductInWarehouse> ProductsInWarehouses { get; }
}