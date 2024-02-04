namespace GroceryStore.Core.Domain.Entities;

public sealed class Product : BaseEntity
{
    public Product() : base(new int[1]) { }
    
    public int Key { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public string? Name { get; set; }

    public string? DegreeOfProcessing { get; set; }

    public int? ManufacturerKey { get; set; }

    public int? BestBefore { get; set; }

    public Manufacturer? ManufacturerKeyNavigation { get; set; }

    public IEnumerable<Sale> Sales { get; set; } = new List<Sale>();

    public IEnumerable<ProductInStore> ProductsInStores { get; set; } = new List<ProductInStore>();

    public IEnumerable<ProductInWarehouse> ProductsInWarehouses { get; set; } = new List<ProductInWarehouse>();
}
