using GroceryStore.Data.Dao;
using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;

namespace GroceryStore.Logic.Services;

public class WarehouseService
{
    public WarehouseService(WarehouseDao warehouses) => _warehouses = warehouses;

    public bool AddWarehouse(WarehouseDto warehouseDto)
    {
        if (warehouseDto.IsEmpty())
            return false;
        
        var warehouse = WarehouseDtoToWarehouse(warehouseDto);

        _warehouses.Create(warehouse);

        return true;
    }

    public IEnumerable<WarehouseDto> GetCities()
    {
        var warehouses = _warehouses.GetAll();

        return from warehouse in warehouses
            select WarehouseToWarehouseDto(warehouse);
    }

    public bool UpdateWarehouse(WarehouseDto warehouseDto)
    {
        if (warehouseDto.IsEmpty())
            return false;
        
        var warehouse = WarehouseDtoToWarehouse(warehouseDto);
        
        _warehouses.Update(warehouse);

        return true;
    }
    
    public bool SaveChanges() => _warehouses.SaveChanges();

    private static WarehouseDto WarehouseToWarehouseDto(IWarehouse warehouse) => new WarehouseDto(warehouse.Key)
    {
        EndOfLease = warehouse.EndOfLease ?? DateTime.UnixEpoch, Contact = warehouse.Contact ?? "NullContact",
        RegionKey = warehouse.RegionKey ?? -1, CityKey = warehouse.CityKey ?? -1, StreetKey = warehouse.StreetKey ?? -1,
        Postcode = warehouse.Postcode ?? -1, HouseNumber = warehouse.HouseNumber ?? -1,
        HouseLetter = warehouse.HouseLetter ?? "NullHouseLetter"
    };
    
    private static Warehouse WarehouseDtoToWarehouse(WarehouseDto warehouseDto) => new Warehouse()
    {
        Key = warehouseDto.Key,
        EndOfLease = warehouseDto.EndOfLease.Equals(DateTime.UnixEpoch) ? null : warehouseDto.EndOfLease,
        Contact = warehouseDto.Contact == "NullContact" ? null : warehouseDto.Contact,
        RegionKey = warehouseDto.RegionKey == -1 ? null : warehouseDto.RegionKey,
        CityKey = warehouseDto.CityKey == -1 ? null : warehouseDto.CityKey,
        StreetKey = warehouseDto.StreetKey == -1 ? null : warehouseDto.StreetKey,
        Postcode = warehouseDto.Postcode == -1 ? null : warehouseDto.Postcode,
        HouseNumber = warehouseDto.HouseNumber == -1 ? null : warehouseDto.HouseNumber,
        HouseLetter = warehouseDto.HouseLetter == "NullHouseLetter" ? null : warehouseDto.HouseLetter
    };

    private readonly WarehouseDao _warehouses;
}