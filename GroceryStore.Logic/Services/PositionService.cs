using GroceryStore.Data.Dao;
using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;

namespace GroceryStore.Logic.Services;

public class PositionService
{
    public PositionService(PositionDao positions) => _positions = positions;

    public bool AddPosition(PositionDto positionDto)
    {
        if (positionDto.IsEmpty())
            return false;
        
        var position = PositionDtoToPosition(positionDto);

        _positions.Create(position);

        return true;
    }

    public IEnumerable<PositionDto> GetPositions()
    {
        var positions = _positions.GetAll();

        return from position in positiond
            select PositionToPositionDto(position);
    }

    public bool UpdatePosition(PositionDto positionDto)
    {
        if (positionDto.IsEmpty())
            return false;
        
        var position = PositionDtoToPositiin(positionDto);
        
        _positions.Update(position);

        return true;
    }
    
    public bool SaveChanges() => _positions.SaveChanges();

    private static PositionDto PositionToPositionDto(IPosition position) => new PositionDto(position.Key)
    {
        Name = position.Name ?? "NullName"
    };
    
    private static Position PositionDtoToPosition(PositionDto positionDto) => new Position()
    {
        Key = positionDto.Key, Name = positionDto.Name == "NullName" ? null : positionDto.Name
    };

    private readonly PositionDao _positions;
}
