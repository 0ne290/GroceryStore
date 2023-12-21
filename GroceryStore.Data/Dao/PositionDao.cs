using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Data.NullObjects;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class PositionDao : BaseDao
{
    public PositionDao(GroceryStoreContext dbContext) : base(dbContext) { }
    
    public void Create(Position position) => DbContext.Positions.Add(position);

    public IEnumerable<Position> GetAll() => DbContext.Positions.AsNoTracking();

    public IPosition GetByKey(int key)
    {
        var position = DbContext.Positions.Find(key);
        
        if (position is null)
            return new NullPosition();

        return position;
    }

    public void Update(Position position) => DbContext.Positions.Update(position);

    public void Remove(Position position) => DbContext.Positions.Remove(position);
}