using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic.Services;

public class WarehouseService
{
    public WarehouseService(IDao<WarehouseDto> warehouses) => _warehouses = warehouses;

    public bool AddWarehouse(WarehouseDto warehouseDto) => _warehouses.Create(warehouseDto);

    public IEnumerable<WarehouseDto> GetCountries() => _warehouses.GetAll();

    public void UpdateCity(WarehouseDto warehouseDto) => _warehouses.Update(warehouseDto);
    
    public bool SaveChanges() => _warehouses.SaveChanges();

    private readonly IDao<WarehouseDto> _warehouses;
}