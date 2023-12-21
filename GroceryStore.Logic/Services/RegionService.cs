using GroceryStore.Data.Dao;
using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;

namespace GroceryStore.Logic.Services;

public class RegionService
{
    public RegionService(RegionDao regions) => _regions = regions;

    public bool AddRegion(RegionDto regionDto)
    {
        if (regionDto.IsEmpty())
            return false;
        
        var region = RegionDtoToRegion(regionDto);

        _regions.Create(region);

        return true;
    }

    public IEnumerable<RegionDto> GetRegions()
    {
        var regions = _regions.GetAll();

        return from region in regions
            select RegionToRegionDto(region);
    }
    
    public bool UpdateRegion(RegionDto regionDto)
    {
        if (regionDto.IsEmpty())
            return false;
        
        var region = RegionDtoToRegion(regionDto);
        
        _regions.Update(region);

        return true;
    }
    
    public bool SaveChanges() => _regions.SaveChanges();

    private static RegionDto RegionToRegionDto(IRegion region) => new RegionDto(region.Key) { Name = region.Name ?? "NullName", CountryKey = region.CountryKey ?? -1 };
    
    private static Region RegionDtoToRegion(RegionDto regionDto) => new Region() { Key = regionDto.Key, Name = regionDto.Name == "NullName" ? null : regionDto.Name, CountryKey = regionDto.CountryKey == -1 ? null : regionDto.CountryKey };

    private readonly RegionDao _regions;
}