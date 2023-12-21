using GroceryStore.Data.Dao;
using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;

namespace GroceryStore.Logic.Services;

public class ManufacturerService
{
    public ManufacturerService(ManufacturerDao manufacturers) => _manufacturers = manufacturers;

    public bool AddManufacturer(ManufacturerDto manufacturerDto)
    {
        if (manufacturerDto.IsEmpty())
            return false;
        
        var manufacturer = ManufacturerDtoToManufacturer(manufacturerDto);

        _manufacturers.Create(manufacturer);

        return true;
    }

    public IEnumerable<ManufacturerDto> GetManufacturers()
    {
        var manufacturers = _manufacturers.GetAll();

        return from manufacturer in manufacturers
            select ManufacturerToManufacturerDto(manufacturer);
    }
    
    public bool UpdateManufacturer(ManufacturerDto manufacturerDto)
    {
        if (manufacturerDto.IsEmpty())
            return false;
        
        var manufacturer = ManufacturerDtoToManufacturer(manufacturerDto);
        
        _manufacturers.Update(manufacturer);

        return true;
    }
    
    public bool SaveChanges() => _manufacturers.SaveChanges();

    private static ManufacturerDto ManufacturerToManufacturerDto(IManufacturer manufacturer) => new ManufacturerDto(manufacturer.Key)
    {
        Name = manufacturer.Name ?? "NullName", Contact = manufacturer.Contact ?? "NullContact",
        CountryKey = manufacturer.CountryKey ?? -1, RegionKey = manufacturer.RegionKey ?? -1,
        CityKey = manufacturer.CityKey ?? -1, StreetKey = manufacturer.StreetKey ?? -1,
        Postcode = manufacturer.Postcode ?? -1, HouseNumber = manufacturer.HouseNumber ?? -1,
        HouseLetter = manufacturer.HouseLetter ?? "NullHouseLetter"
    };
    
    private static Manufacturer ManufacturerDtoToManufacturer(ManufacturerDto manufacturerDto) => new Manufacturer()
    {
        Name = manufacturerDto.Name == "NullName" ? null : manufacturerDto.Name,
        Contact = manufacturerDto.Contact == "NullContact" ? null : manufacturerDto.Contact,
        CountryKey = manufacturerDto.CountryKey == -1 ? null : manufacturerDto.CountryKey,
        RegionKey = manufacturerDto.RegionKey == -1 ? null : manufacturerDto.RegionKey,
        CityKey = manufacturerDto.CityKey == -1 ? null : manufacturerDto.CityKey,
        StreetKey = manufacturerDto.StreetKey == -1 ? null : manufacturerDto.StreetKey,
        Postcode = manufacturerDto.Postcode == -1 ? null : manufacturerDto.Postcode,
        HouseNumber = manufacturerDto.HouseNumber == -1 ? null : manufacturerDto.HouseNumber,
        HouseLetter = manufacturerDto.HouseLetter == "NullHouseLetter" ? null : manufacturerDto.HouseLetter
    };

    private readonly ManufacturerDao _manufacturers;
}