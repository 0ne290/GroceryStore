using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic.Services;

public class ProductInWarehouseService
{
    public ProductInWarehouseService(IDao<ProductInWarehouseDto> productsInWarehouse) => _productsInWarehouse = productsInWarehouse;

    public bool AddProductInWarehouse(ProductInWarehouseDto productInWarehouseDto) => _productsInWarehouse.Create(productInWarehouseDto);

    public IEnumerable<ProductInWarehouseDto> GetCountries() => _productsInWarehouse.GetAll();

    public void UpdateCity(ProductInWarehouseDto productInWarehouseDto) => _productsInWarehouse.Update(productInWarehouseDto);
    
    public bool SaveChanges() => _productsInWarehouse.SaveChanges();

    private readonly IDao<ProductInWarehouseDto> _productsInWarehouse;
}