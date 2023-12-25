using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic.Services;

public class ManufacturerService
{
    public ManufacturerService(IDao<ManufacturerDto> manufacturers) => _manufacturers = manufacturers;

    public bool AddManufacturer(ManufacturerDto manufacturerDto) => _manufacturers.Create(manufacturerDto);

    public IEnumerable<ManufacturerDto> GetCountries() => _manufacturers.GetAll();

    public void UpdateCity(ManufacturerDto manufacturerDto) => _manufacturers.Update(manufacturerDto);
    
    public bool SaveChanges() => _manufacturers.SaveChanges();

    private readonly IDao<ManufacturerDto> _manufacturers;
}