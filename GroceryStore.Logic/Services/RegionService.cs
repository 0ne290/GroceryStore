using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic.Services;

public class RegionService
{
    public RegionService(IDao<RegionDto> regions) => _regions = regions;

    public bool AddRegion(RegionDto regionDto) => _regions.Create(regionDto);

    public IEnumerable<RegionDto> GetCountries() => _regions.GetAll();

    public void UpdateCity(RegionDto regionDto) => _regions.Update(regionDto);
    
    public bool SaveChanges() => _regions.SaveChanges();

    private readonly IDao<RegionDto> _regions;
}