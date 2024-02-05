using System.Linq.Expressions;
using GroceryStore.Core.Domain.Interfaces;

namespace GroceryStore.Core.Application.Interfaces;

public interface IEntityService : IDisposable, IAsyncDisposable
{
    bool Add<TEntity>(TEntity entity) where TEntity : class, IEntity;

    IEnumerable<TDto> Get<TEntity, TDto>(Expression<Func<TEntity, bool>> filter) where TEntity : class, IEntity
        where TDto : IDto;

    IEnumerable<TDto> GetAll<TEntity, TDto>() where TEntity : class, IEntity where TDto : IDto;

    TDto GetByKey<TEntity, TDto>(object[] key) where TEntity : class, IEntity where TDto : IDto, new();

    bool Update<TEntity>(TEntity entity) where TEntity : class, IEntity;

    bool Remove<TEntity>(TEntity entity) where TEntity : class, IEntity;

    Exception? SaveChanges<TEntity>() where TEntity : class, IEntity;

    IDictionary<Type, Exception?> SaveAllChanges();
}