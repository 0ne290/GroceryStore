using GroceryStore.Data.Interfaces;
using GroceryStore.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Data;

public class Dao<TEntity, TDto> : IDao<TDto> where TDto : IDto, new() where TEntity : class, IEntity
{
    public Dao(GroceryStoreContext dbContext, Mapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public bool Create(TDto dto)
    {
        if (dto.IsEmpty())
            return false;
        
        var entity = (TEntity)_mapper.DtoToEntity(dto);

        _dbContext.Set<TEntity>().Add(entity);

        return true;
    }

    public IEnumerable<TDto> GetAll()
    {
        var entities = _dbContext.Set<TEntity>().AsNoTracking().AsEnumerable();

        return from entity in entities
            select (TDto)_mapper.EntityToDto(entity);
    }

    public TDto GetByKey(object[] key)
    {
        var entity = _dbContext.Set<TEntity>().Find(key);
        
        if (entity is null)
            return new TDto();

        return (TDto)_mapper.EntityToDto(entity);
    }

    public void Update(TDto dto)
    {
        var entity = _mapper.DtoToEntity(dto);
        
        _dbContext.Set<TEntity>().Update((TEntity)entity);
    }

    public void Remove(TDto dto)
    {
        var entity = _mapper.DtoToEntity(dto);
        
        _dbContext.Set<TEntity>().Remove((TEntity)entity);
    }
    
    public bool SaveChanges()
    {
        try
        {
            _dbContext.SaveChanges();
        }
        catch
        {
            return false;
        }

        return true;
    }
    
    private readonly GroceryStoreContext _dbContext;
    
    private readonly Mapper _mapper;
}