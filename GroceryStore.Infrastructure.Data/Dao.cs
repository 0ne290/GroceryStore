using System.Linq.Expressions;
using GroceryStore.Core.Domain.Entities;
using GroceryStore.Core.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Infrastructure.Data;

public class Dao<TEntity> : IDao<TEntity> where TEntity : BaseEntity
{
    public Dao(GroceryStoreContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    public void Create(TEntity entity) => _dbSet.Add(entity);
    
    public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter) => _dbSet.Where(filter).AsNoTracking().AsEnumerable();

    public IEnumerable<TEntity> GetAll() => _dbSet.AsNoTracking().AsEnumerable();

    public TEntity? GetByKey(object[] key) => _dbSet.Find(key);

    public void Update(TEntity entity) => _dbSet.Update(entity);

    public void Remove(TEntity entity) => _dbSet.Remove(entity);
    
    public Exception? SaveChanges()
    {
        try
        {
            _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            return e;
        }

        return null;
    }
    
    public void Dispose() => _dbContext.Dispose();

    public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();
    
    private readonly GroceryStoreContext _dbContext;

    private readonly DbSet<TEntity> _dbSet;
}