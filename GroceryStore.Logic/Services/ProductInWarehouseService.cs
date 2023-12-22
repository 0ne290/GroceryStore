using GroceryStore.Data.Dao;
using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;

namespace GroceryStore.Logic.Services;

public class ProductInWarehouseService
{
    public ProductInWarehouseService(ProductInWarehouseDao productsInWarehouse) => _productsInWarehouse = productsInWarehouse;

    public bool AddProductInWarehouse(ProductInWarehouseDto productInWarehouseDto)
    {
        if (productInWarehouseDto.IsEmpty())
            return false;
        
        var productInWarehouse = ProductInWarehouseDtoToProductInWarehouse(productInWarehouseDto);

        _productsInWarehouse.Create(productInWarehouse);

        return true;
    }

    public IEnumerable<ProductInWarehouseDto> GetProductsInStore()
    {
        var productsInWarehouse = _productsInWarehouse.GetAll();

        return from productInWarehouse in productsInWarehouse
            select ProductInWarehouseToProductInWarehouseDto(productInWarehouse);
    }

    public bool UpdateProductInWarehouse(ProductInWarehouseDto productInWarehouseDto)
    {
        if (productInWarehouseDto.IsEmpty())
            return false;
        
        var productInWarehouse = ProductInWarehouseDtoToProductInWarehouse(productInWarehouseDto);
        
        _productsInWarehouse.Update(productInWarehouse);

        return true;
    }
    
    public bool SaveChanges() => _productsInWarehouse.SaveChanges();

    private static ProductInWarehouseDto ProductInWarehouseToProductInWarehouseDto(IProductInWarehouse productInWarehouse) => new ProductInWarehouseDto(productInWarehouse.WarehouseKey, productInWarehouse.ProductKey)
    {
        Quantity = productInWarehouse.Quantity ?? -1,
        DateOfManufacture = productInWarehouse.DateOfManufacture ?? DateTime.UnixEpoch
    };
    
    private static ProductInWarehouse ProductInWarehouseDtoToProductInWarehouse(ProductInWarehouseDto productInWarehouseDto) => new ProductInWarehouse()
    {
        WarehouseKey = productInWarehouseDto.WarehouseKey, ProductKey = productInWarehouseDto.ProductKey,
        Quantity = productInWarehouseDto.Quantity == -1 ? null : productInWarehouseDto.Quantity,
        DateOfManufacture = productInWarehouseDto.DateOfManufacture.Equals(DateTime.UnixEpoch) ? null : productInWarehouseDto.DateOfManufacture
    };

    private readonly ProductInWarehouseDao _productsInWarehouse;
}