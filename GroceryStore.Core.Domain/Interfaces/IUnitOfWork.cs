using System.Linq.Expressions;

namespace GroceryStore.Core.Domain.Interfaces;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    void AddDao<TEntity>(IDao<TEntity> dao) where TEntity : class, IEntity;

    void Add<TEntity>(TEntity entity) where TEntity : class, IEntity;
    
    IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class, IEntity;

    IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class, IEntity;
    
    TEntity? GetByKey<TEntity>(object[] key) where TEntity : class, IEntity;

    void Update<TEntity>(TEntity entity) where TEntity : class, IEntity;
    
    void Remove<TEntity>(TEntity entity) where TEntity : class, IEntity;
    
    Exception? SaveChanges<TEntity>() where TEntity : class, IEntity;

    IDictionary<Type, Exception?> SaveAllChanges();
}