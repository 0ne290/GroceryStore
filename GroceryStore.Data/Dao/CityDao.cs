using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class CityDao<Entity, Dto> : BaseDao where Dto : IDto, new() where Entity : class, IEntity
{
    public CityDao(GroceryStoreContext dbContext, Mapper mapper) : base(dbContext, mapper) { }

    public bool Create(Dto dto)
    {
        if (dto.IsEmpty())
            return false;
        
        var entity = (Entity)Mapper.DtoToEntity(dto);

        DbContext.Set<Entity>().Add(entity);

        return true;
    }

    public IEnumerable<Dto> GetAll()
    {
        var entities = DbContext.Set<Entity>().AsNoTracking().AsEnumerable();

        return from entity in entities
            select (Dto)Mapper.EntityToDto(entity);
    }

    public Dto GetByKey(object[] key)
    {
        var entity = DbContext.Set<Entity>().Find(key);
        
        if (entity is null)
            return new Dto();

        return (Dto)Mapper.EntityToDto(entity);
    }

    public void Update(City city) => DbContext.Cities.Update(city);

    public void Remove(City city) => DbContext.Cities.Remove(city);
}