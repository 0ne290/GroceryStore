using System.Linq.Expressions;
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
    
    public IEnumerable<TDto> Get(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)//, string includeProperties = "")
    {
        IQueryable<TEntity> query = _dbContext.Set<TEntity>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        //foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //{
        //    query = query.Include(includeProperty);
        //}
        
        // ReSharper disable once MergeConditionalExpression
        var entities = orderBy != null ? orderBy(query).AsNoTracking().AsEnumerable() : query.AsNoTracking().AsEnumerable();
        
        return from entity in entities
            select (TDto)_mapper.EntityToDto(entity);
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
        
        return entity is null ? new TDto() : (TDto)_mapper.EntityToDto(entity);
    }

    public bool Update(TDto dto)
    {
        if (dto.IsEmpty())
            return false;
        
        var entity = _mapper.DtoToEntity(dto);
        
        _dbContext.Set<TEntity>().Update((TEntity)entity);

        return true;
    }

    public bool Remove(TDto dto)
    {
        if (dto.IsEmpty())
            return false;
        
        var entity = _mapper.DtoToEntity(dto);
        
        _dbContext.Set<TEntity>().Remove((TEntity)entity);

        return true;
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
    
    public void Dispose() => _dbContext.Dispose();

    public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();
    
    private readonly GroceryStoreContext _dbContext;
    
    private readonly Mapper _mapper;
}