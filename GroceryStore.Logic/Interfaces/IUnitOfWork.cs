using System.Linq.Expressions;

namespace GroceryStore.Logic.Interfaces;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    void AddDao<TEntity, TDto>(IDao<TEntity, TDto> service) where TDto : IDto where TEntity : IEntity;

    bool Add<TEntity, TDto>(TDto dto) where TDto : IDto where TEntity : IEntity;
    
    IEnumerable<TDto> Get<TEntity, TDto>(Expression<Func<TEntity, bool>>? filter = null) where TDto : IDto where TEntity : IEntity;

    IEnumerable<TDto> GetAll<TEntity, TDto>() where TDto : IDto where TEntity : IEntity;
    
    TDto GetByKey<TEntity, TDto>(object[] key) where TDto : IDto where TEntity : IEntity;

    bool Update<TEntity, TDto>(TDto dto) where TDto : IDto where TEntity : IEntity;
    
    bool Remove<TEntity, TDto>(TDto dto) where TDto : IDto where TEntity : IEntity;

    bool SaveChanges<TEntity, TDto>() where TDto : IDto where TEntity : IEntity;
}