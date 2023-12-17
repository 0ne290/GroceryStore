using GroceryStore.Data.Dao;
using GroceryStore.Data.Entities;
using GroceryStore.Logic.Dto;

namespace GroceryStore.Logic;

public class RegionService
{
    public RegionService(RegionDao regions) => _regions = regions;

    public void AddRegion(RegionDto regionDto)
    {
        var city = RegionDtoToRegion(regionDto);

        _regions.Create(city);
    }

    public IEnumerable<RegionDto> GetRegions()
    {
        var regions = _regions.GetAll();

        return from region in regions
            select RegionToRegionDto(region);
    }
    
    public void SaveChanges() => _regions.SaveChanges();

    private RegionDto RegionToRegionDto(Region region) => new RegionDto() { Key = region.Key, Name = region.Name ?? "NullName", CountryKey = region.CountryKey ?? -1 };
    
    private Region RegionDtoToRegion(RegionDto regionDto) => new Region() { Key = regionDto.Key, Name = regionDto.Name, CountryKey = regionDto.CountryKey };

    private readonly RegionDao _regions;
}