// ReSharper disable CollectionNeverUpdated.Global

namespace GroceryStore.Data.Models;

public sealed class Product
{
    public int? Key { get; set; }

    public string? Name { get; set; }

    public string? DegreeOfProcessing { get; set; }

    public int? ManufacturerKey { get; set; }

    public int? BestBefore { get; set; }

    public Manufacturer? ManufacturerKeyNavigation { get; set; }

    public ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public ICollection<ProductInStore> ProductsInStores { get; set; } = new List<ProductInStore>();

    public ICollection<ProductInWarehouse> ProductsInWarehouses { get; set; } = new List<ProductInWarehouse>();
}
