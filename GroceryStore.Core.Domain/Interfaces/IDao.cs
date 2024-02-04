using System.Linq.Expressions;
using GroceryStore.Core.Domain.Entities;

namespace GroceryStore.Core.Domain.Interfaces;

public interface IDao<TEntity> : IDisposable, IAsyncDisposable where TEntity : BaseEntity
{
    void Create(TEntity entity);

    IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter);//, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "");

    IEnumerable<TEntity> GetAll();

    TEntity? GetByKey(object[] key);

    void Update(TEntity entity);

    void Remove(TEntity entity);

    Exception? SaveChanges();
}