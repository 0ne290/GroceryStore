using GroceryStore.Domain.Interfaces;

namespace GroceryStore.Logic.Entities;

public sealed class Product : IEntity
{
    public int Key { get; set; }

    public string? Name { get; set; }

    public string? DegreeOfProcessing { get; set; }

    public int? ManufacturerKey { get; set; }

    public int? BestBefore { get; set; }

    public Manufacturer? ManufacturerKeyNavigation { get; set; }

    public IEnumerable<Sale> Sales { get; set; } = new List<Sale>();

    public IEnumerable<ProductInStore> ProductsInStores { get; set; } = new List<ProductInStore>();

    public IEnumerable<ProductInWarehouse> ProductsInWarehouses { get; set; } = new List<ProductInWarehouse>();
}
