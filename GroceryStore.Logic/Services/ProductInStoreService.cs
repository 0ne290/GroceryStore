using GroceryStore.Data.Dao;
using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;

namespace GroceryStore.Logic.Services;

public class ProductInStoreService
{
    public ProductInStoreService(ProductInStoreDao productsInStore) => _productsInStore = productsInStore;

    public bool AddProductInStore(ProductInStoreDto productInStoreDto)
    {
        if (productInStoreDto.IsEmpty())
            return false;
        
        var productInStore = ProductInStoreDtoToProductInStore(productInStoreDto);

        _productsInStore.Create(productInStore);

        return true;
    }

    public IEnumerable<ProductInStoreDto> GetProductsInStore()
    {
        var productsInStore = _productsInStore.GetAll();

        return from productInStore in productsInStore
            select ProductInStoreToProductInStoreDto(productInStore);
    }

    public bool UpdateProductInStore(ProductInStoreDto productInStoreDto)
    {
        if (productInStoreDto.IsEmpty())
            return false;
        
        var productInStore = ProductInStoreDtoToProductInStore(productInStoreDto);
        
        _productsInStore.Update(productInStore);

        return true;
    }
    
    public bool SaveChanges() => _productsInStore.SaveChanges();

    private static ProductInStoreDto ProductInStoreToProductInStoreDto(IProductInStore productInStore) => new ProductInStoreDto(productInStore.StoreKey, productInStore.ProductKey)
    {
        Quantity = productInStore.Quantity ?? -1, WarehouseKey = productInStore.WarehouseKey ?? -1
    };
    
    private static ProductInStore ProductInStoreDtoToProductInStore(ProductInStoreDto productInStoreDto) => new ProductInStore()
    {
        StoreKey = productInStoreDto.StoreKey, ProductKey = productInStoreDto.ProductKey,
        Quantity = productInStoreDto.Quantity == -1 ? null : productInStoreDto.Quantity,
        WarehouseKey = productInStoreDto.WarehouseKey == -1 ? null : productInStoreDto.WarehouseKey
    };

    private readonly ProductInStoreDao _productsInStore;
}