namespace GroceryStore.Data.Entities;

public sealed class Product
{
    public static Product Empty() => new Product()
    {
        Key = -1, Name = "NullName", DegreeOfProcessing = "NullDegreeOfProcessing", ManufacturerKey = -1,
        BestBefore = -1, ManufacturerKeyNavigation = Manufacturer.Empty(), Sales = Enumerable.Empty<Sale>(),
        ProductsInStores = Enumerable.Empty<ProductInStore>(),
        ProductsInWarehouses = Enumerable.Empty<ProductInWarehouse>()
    };
    
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
