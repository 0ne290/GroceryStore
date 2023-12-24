using GroceryStore.Data.Entities;
using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Dto;
using GroceryStore.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data.Dao;

public class CityDao<Entity, Dto> : BaseDao where Dto : IDto where Entity : class, IEntity
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
        var city = DbContext.Set<Entity>().Find(key);
        
        if (city is null)
            return Dto.Empty();

        return city;
    }

    public void Update(City city) => DbContext.Cities.Update(city);

    public void Remove(City city) => DbContext.Cities.Remove(city);
}