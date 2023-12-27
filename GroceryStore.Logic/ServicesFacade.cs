using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Services;

namespace GroceryStore.Logic;

public class ServicesFacade
{
    public ServicesFacade(CityService cities, CountryService countries, EmployeeService staff,
        ManufacturerService manufacturers, PositionService positions, ProductInStoreService productsInStores,
        ProductInWarehouseService productsInWarehouses, ProductService products, RegionService regions,
        RegularCustomerService regularCustomers, SaleService sales, StoreService stores, StreetService streets,
        WarehouseService warehouses)
    {
        _cities = cities;
        _countries = countries;
        _staff = staff;
        _manufacturers = manufacturers;
        _positions = positions;
        _productsInStores = productsInStores;
        _productsInWarehouses = productsInWarehouses;
        _products = products;
        _regions = regions;
        _regularCustomers = regularCustomers;
        _sales = sales;
        _stores = stores;
        _streets = streets;
        _warehouses = warehouses;
    }

    public bool AddCity(CityDto cityDto) => _cities.AddCity(cityDto);

    public IEnumerable<CityDto> GetCities() => _cities.GetCities();

    public void UpdateCity(CityDto cityDto) => _cities.UpdateCity(cityDto);
    
    public bool SaveCityChanges() => _cities.SaveChanges();
    
    public bool AddCountry(CountryDto countryDto) => _countries.AddCountry(countryDto);

    public IEnumerable<CountryDto> GetCountries() => _countries.GetCountries();

    public void UpdateCountry(CountryDto countryDto) => _countries.UpdateCountry(countryDto);
    
    public bool SaveCountryChanges() => _countries.SaveChanges();
    
    public bool AddEmployee(EmployeeDto employeeDto) => _staff.AddEmployee(e)

    public IEnumerable<EmployeeDto> GetStaff() => _staff.GetAll();

    public void UpdateEmployee(EmployeeDto employeeDto) => _staff.Update(employeeDto);
    
    public bool SaveChanges() => _staff.SaveChanges();
    
    private readonly CityService _cities;

    private readonly CountryService _countries;

    private readonly EmployeeService _staff;

    private readonly ManufacturerService _manufacturers;

    private readonly PositionService _positions;

    private readonly ProductInStoreService _productsInStores;

    private readonly ProductInWarehouseService _productsInWarehouses;

    private readonly ProductService _products;

    private readonly RegionService _regions;

    private readonly RegularCustomerService _regularCustomers;

    private readonly SaleService _sales;

    private readonly StoreService _stores;

    private readonly StreetService _streets;

    private readonly WarehouseService _warehouses;
}