using System.Linq.Expressions;

namespace GroceryStore.Logic.Interfaces;

public interface IDao<TEntity, TDto> : IDisposable, IAsyncDisposable
{
    bool Create(TDto dto);

    IEnumerable<TDto> Get(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);//, string includeProperties = "")

    IEnumerable<TDto> GetAll();

    TDto GetByKey(object[] key);

    bool Update(TDto dto);

    bool Remove(TDto dto);

    bool SaveChanges();
}