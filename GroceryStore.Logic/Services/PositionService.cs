using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic.Services;

public class PositionService
{
    public PositionService(IDao<PositionDto> positions) => _positions = positions;

    public bool AddPosition(PositionDto positionDto) => _positions.Create(positionDto);

    public IEnumerable<PositionDto> GetCountries() => _positions.GetAll();

    public void UpdateCity(PositionDto positionDto) => _positions.Update(positionDto);
    
    public bool SaveChanges() => _positions.SaveChanges();

    private readonly IDao<PositionDto> _positions;
}