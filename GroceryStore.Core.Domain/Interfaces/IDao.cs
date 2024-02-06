using System.Linq.Expressions;

namespace GroceryStore.Core.Domain.Interfaces;

public interface IDao<TEntity> : IDisposable, IAsyncDisposable, ISaver where TEntity : class, IEntity
{
    void Create(TEntity entity);

    IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter);//, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "");

    IEnumerable<TEntity> GetAll();

    TEntity? GetByKey(object[] key);

    void Update(TEntity entity);

    void Remove(TEntity entity);
}