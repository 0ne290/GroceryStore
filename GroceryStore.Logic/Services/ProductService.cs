using GroceryStore.Data.Dao;
using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;

namespace GroceryStore.Logic.Services;

public class ProductService
{
    public ProductService(ProductDao products) => _products = products;

    public bool AddProduct(ProductDto productDto)
    {
        if (productDto.IsEmpty())
            return false;
        
        var product = ProductDtoToProduct(productDto);

        _products.Create(product);

        return true;
    }

    public IEnumerable<ProductDto> GetProducts()
    {
        var products = _products.GetAll();

        return from product in products
            select ProductToProductDto(product);
    }
    
    public bool UpdateProduct(ProductDto productDto)
    {
        if (productDto.IsEmpty())
            return false;
        
        var product = ProductDtoToProduct(productDto);
        
        _products.Update(product);

        return true;
    }
    
    public bool SaveChanges() => _products.SaveChanges();

    private static ProductDto ProductToProductDto(IProduct product) => new ProductDto(product.Key)
    {
        Name = product.Name ?? "NullName", DegreeOfProcessing = product.DegreeOfProcessing ?? "NullDegreeOfProcessing",
        ManufacturerKey = product.ManufacturerKey ?? -1, BestBefore = product.BestBefore ?? -1
    };
    
    private static Product ProductDtoToProduct(ProductDto productDto) => new Product()
    {
        Name = productDto.Name == "NullName" ? null : productDto.Name,
        DegreeOfProcessing = productDto.DegreeOfProcessing == "NullDegreeOfProcessing" ? null : productDto.DegreeOfProcessing,
        ManufacturerKey = productDto.ManufacturerKey == -1 ? null : productDto.ManufacturerKey,
        BestBefore = productDto.BestBefore == -1 ? null : productDto.BestBefore
    };

    private readonly ProductDao _products;
}