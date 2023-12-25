using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic.Services;

public class ProductService
{
    public ProductService(IDao<ProductDto> products) => _products = products;

    public bool AddProduct(ProductDto productDto) => _products.Create(productDto);

    public IEnumerable<ProductDto> GetCountries() => _products.GetAll();

    public void UpdateCity(ProductDto productDto) => _products.Update(productDto);
    
    public bool SaveChanges() => _products.SaveChanges();

    private readonly IDao<ProductDto> _products;
}