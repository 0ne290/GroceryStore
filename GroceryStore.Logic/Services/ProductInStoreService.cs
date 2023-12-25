using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic.Services;

public class ProductInStoreService
{
    public ProductInStoreService(IDao<ProductInStoreDto> productsInStore) => _productsInStore = productsInStore;

    public bool AddProductInStore(ProductInStoreDto productInStoreDto) => _productsInStore.Create(productInStoreDto);

    public IEnumerable<ProductInStoreDto> GetCountries() => _productsInStore.GetAll();

    public void UpdateCity(ProductInStoreDto productInStoreDto) => _productsInStore.Update(productInStoreDto);
    
    public bool SaveChanges() => _productsInStore.SaveChanges();

    private readonly IDao<ProductInStoreDto> _productsInStore;
}