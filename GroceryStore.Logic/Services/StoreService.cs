using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic.Services;

public class StoreService
{
    public StoreService(IDao<StoreDto> stores) => _stores = stores;

    public bool AddStore(StoreDto storeDto) => _stores.Create(storeDto);

    public IEnumerable<StoreDto> GetCountries() => _stores.GetAll();

    public void UpdateCity(StoreDto storeDto) => _stores.Update(storeDto);
    
    public bool SaveChanges() => _stores.SaveChanges();

    private readonly IDao<StoreDto> _stores;
}