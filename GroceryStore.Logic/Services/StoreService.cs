using GroceryStore.Data.Dao;
using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;

namespace GroceryStore.Logic.Services;

public class StoreService
{
    public StoreService(StoreDao stores) => _stores = stores;

    public bool AddStore(StoreDto storeDto)
    {
        if (storeDto.IsEmpty())
            return false;
        
        var store = StoreDtoToStore(storeDto);

        _stores.Create(store);

        return true;
    }

    public IEnumerable<StoreDto> GetStores()
    {
        var stores = _stores.GetAll();

        return from store in stores
            select StoreToStoreDto(store);
    }
    
    public bool UpdateStore(StoreDto storeDto)
    {
        if (storeDto.IsEmpty())
            return false;
        
        var store = StoreDtoToStore(storeDto);
        
        _stores.Update(store);

        return true;
    }
    
    public bool SaveChanges() => _stores.SaveChanges();

    private static StoreDto StoreToStoreDto(IStore store) => new StoreDto(store.Key)
    {
        EndOfLease = store.EndOfLease ?? DateTime.UnixEpoch, Contact = store.Contact ?? "NullContact",
        RegionKey = store.RegionKey ?? -1, CityKey = store.CityKey ?? -1, StreetKey = store.StreetKey ?? -1,
        Postcode = store.Postcode ?? -1, HouseNumber = store.HouseNumber ?? -1, HouseLetter = store.HouseLetter ?? "NullHouseLetter"
    };
    
    private static Store StoreDtoToStore(StoreDto storeDto) => new Store()
    {
        EndOfLease = storeDto.EndOfLease.Equals(DateTime.UnixEpoch) ? null : storeDto.EndOfLease,
        Contact = storeDto.Contact == "NullContact" ? null : storeDto.Contact,
        RegionKey = storeDto.RegionKey == -1 ? null : storeDto.RegionKey,
        CityKey = storeDto.CityKey == -1 ? null : storeDto.CityKey,
        StreetKey = storeDto.StreetKey == -1 ? null : storeDto.StreetKey,
        Postcode = storeDto.Postcode == -1 ? null : storeDto.Postcode,
        HouseNumber = storeDto.HouseNumber == -1 ? null : storeDto.HouseNumber,
        HouseLetter = storeDto.HouseLetter == "NullHouseLetter" ? null : storeDto.HouseLetter
    };

    private readonly StoreDao _stores;
}