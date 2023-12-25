using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic.Services;

public class SaleService
{
    public SaleService(IDao<SaleDto> sales) => _sales = sales;

    public bool AddSale(SaleDto saleDto) => _sales.Create(saleDto);

    public IEnumerable<SaleDto> GetCountries() => _sales.GetAll();

    public void UpdateCity(SaleDto saleDto) => _sales.Update(saleDto);
    
    public bool SaveChanges() => _sales.SaveChanges();

    private readonly IDao<SaleDto> _sales;
}