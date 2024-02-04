using System.Linq.Expressions;
using GroceryStore.Core.Domain.Entities;

namespace GroceryStore.Core.Domain.Interfaces;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    void AddDao<TEntity>(IDao<TEntity> dao) where TEntity : BaseEntity;

    void Add<TEntity>(TEntity entity) where TEntity : BaseEntity;
    
    IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : BaseEntity;

    IEnumerable<TEntity> GetAll<TEntity>() where TEntity : BaseEntity;
    
    TEntity? GetByKey<TEntity>(object[] key) where TEntity : BaseEntity;

    void Update<TEntity>(TEntity entity) where TEntity : BaseEntity;
    
    void Remove<TEntity>(TEntity entity) where TEntity : BaseEntity;
    
    Exception? SaveChanges<TEntity>() where TEntity : BaseEntity;

    IDictionary<Type, Exception?> SaveAllChanges();
}