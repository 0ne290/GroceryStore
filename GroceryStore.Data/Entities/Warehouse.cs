// ReSharper disable CollectionNeverUpdated.Global

using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.Entities;

public sealed class Warehouse : IWarehouse
{
    public int Key { get; set; }

    public DateTime? EndOfLease { get; set; }

    public string? Contact { get; set; }

    public int? RegionKey { get; set; }

    public int? CityKey { get; set; }

    public int? StreetKey { get; set; }

    public int? Postcode { get; set; }

    public int? HouseNumber { get; set; }

    public string? HouseLetter { get; set; }
    
    public IRegion? RegionKeyNavigation { get; set; }
    
    public ICity? CityKeyNavigation { get; set; }

    public IStreet? StreetKeyNavigation { get; set; }

    public ICollection<IProductInStore> ProductsInStores { get; set; } = new List<IProductInStore>();

    public ICollection<IProductInWarehouse> ProductsInWarehouses { get; set; } = new List<IProductInWarehouse>();
}
