using GroceryStore.Data.Dao;
using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;

namespace GroceryStore.Logic;

public class RegionService
{
    public RegionService(RegionDao regions) => _regions = regions;

    public void AddRegion(RegionDto regionDto)
    {
        var region = RegionDtoToRegion(regionDto);

        _regions.Create(region);
    }

    public IEnumerable<RegionDto> GetRegions()
    {
        var regions = _regions.GetAll();

        return from region in regions
            select RegionToRegionDto(region);
    }
    
    public void UpdateRegion(RegionDto regionDto)
    {
        var region = RegionDtoToRegion(regionDto);
        
        _regions.Update(region);
    }
    
    public bool SaveChanges() => _regions.SaveChanges();

    private RegionDto RegionToRegionDto(IRegion region) => new RegionDto() { Key = region.Key, Name = region.Name ?? "NullName", CountryKey = region.CountryKey ?? -1 };
    
    private Region RegionDtoToRegion(RegionDto regionDto) => new Region() { Key = regionDto.Key, Name = regionDto.Name == "NullName" ? null : regionDto.Name, CountryKey = regionDto.CountryKey == -1 ? null : regionDto.CountryKey };

    private readonly RegionDao _regions;
}