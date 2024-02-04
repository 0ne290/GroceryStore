using System.Linq.Expressions;
using GroceryStore.Core.Domain.Entities;
using GroceryStore.Core.Domain.Interfaces;

namespace GroceryStore.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    public void AddDao<TEntity>(IDao<TEntity> dao) where TEntity : BaseEntity => _daos.Add(typeof(TEntity), dao);

    public void Add<TEntity>(TEntity entity) where TEntity : BaseEntity => _daos[typeof(TEntity)].Create(entity);

    public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : BaseEntity =>
        _daos[typeof(TEntity)].Get(filter);

    public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : BaseEntity => _daos[typeof(TEntity)].GetAll();
    
    public TEntity? GetByKey<TEntity>(object[] key) where TEntity : BaseEntity =>
        _daos[typeof(TEntity)].GetByKey(key);

    public void Update<TEntity>(TEntity entity) where TEntity : BaseEntity => _daos[typeof(TEntity)].Update(entity);

    public void Remove<TEntity>(TEntity entity) where TEntity : BaseEntity => _daos[typeof(TEntity)].Remove(entity);

    public Exception? SaveChanges<TEntity>() where TEntity : BaseEntity => _daos[typeof(TEntity)].SaveChanges();
    
    public IDictionary<Type, Exception?> SaveAllChanges() =>
        _daos.ToDictionary<KeyValuePair<Type, dynamic>, Type, Exception?>(typeDaoPair => typeDaoPair.Key, typeDaoPair =>
            typeDaoPair.Value.SaveChanges());
    
    public void Dispose()
    {
        foreach (var dao in _daos.Values)
            dao.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        foreach (var dao in _daos.Values)
            await dao.DisposeAsync();
    }

    private readonly Dictionary<Type, dynamic> _daos = new();
}