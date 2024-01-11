namespace GroceryStore.Logic.Dto;

public class ProductDto : BaseDto
{
    public ProductDto(int key) : base(new [] { key }) { }
    
    public ProductDto() : base(new [] { -1 }) { }
    
    public int Key { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public string Name { get; set; } = "NullName";

    public string DegreeOfProcessing { get; set; } = "NullDegreeOfProcessing";

    public int ManufacturerKey { get; set; } = -1;

    public int BestBefore { get; set; } = -1;

    //public IManufacturer? ManufacturerKeyNavigation { get; set; }
//
    //public IEnumerable<ISale> Sales { get; set; } = new List<ISale>();
//
    //public IEnumerable<IProductInStore> ProductsInStores { get; set; } = new List<IProductInStore>();
//
    //public IEnumerable<IProductInWarehouse> ProductsInWarehouses { get; set; } = new List<IProductInWarehouse>();
}