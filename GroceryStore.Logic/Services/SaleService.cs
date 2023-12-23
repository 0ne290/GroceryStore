using GroceryStore.Data.Dao;
using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;

namespace GroceryStore.Logic.Services;

public class SaleService
{
    public SaleService(SaleDao sales) => _sales = sales;

    public bool AddSale(SaleDto saleDto)
    {
        if (saleDto.IsEmpty())
            return false;
        
        var sale = SaleDtoToSale(saleDto);

        _sales.Create(sale);

        return true;
    }

    public IEnumerable<SaleDto> GetCities()
    {
        var sales = _sales.GetAll();

        return from sale in sales
            select SaleToSaleDto(sale);
    }

    public bool UpdateSale(SaleDto saleDto)
    {
        if (saleDto.IsEmpty())
            return false;
        
        var sale = SaleDtoToSale(saleDto);
        
        _sales.Update(sale);

        return true;
    }
    
    public bool SaveChanges() => _sales.SaveChanges();

    private static SaleDto SaleToSaleDto(ISale sale) => new SaleDto(sale.ProductKey, sale.CustomerKey, sale.Date)
    {
        Quantity = sale.Quantity ?? -1
    };
    
    private static Sale SaleDtoToSale(SaleDto saleDto) => new Sale()
    {
        ProductKey = saleDto.ProductKey, CustomerKey = saleDto.CustomerKey, Date = saleDto.Date,
        Quantity = saleDto.Quantity == -1 ? null : saleDto.Quantity
    };

    private readonly SaleDao _sales;
}