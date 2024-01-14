using System.Linq.Expressions;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic;

public class UnitOfWork : IUnitOfWork
{
    public void AddDao<TEntity, TDto>(IDao<TEntity, TDto> dao) where TDto : IDto where TEntity : IEntity =>
        _daos.Add(typeof(TDto), dao);

    public bool Add<TEntity, TDto>(TDto dto) where TDto : IDto where TEntity : IEntity =>
        ((IDao<TEntity, TDto>)_daos[typeof(TDto)]).Create(dto);

    public IEnumerable<TDto> Get<TEntity, TDto>(Expression<Func<TEntity, bool>>? filter = null)
        where TDto : IDto where TEntity : IEntity =>
        ((IDao<TEntity, TDto>)_daos[typeof(TDto)]).Get(filter);

    public IEnumerable<TDto> GetAll<TEntity, TDto>() where TDto : IDto where TEntity : IEntity =>
        ((IDao<TEntity, TDto>)_daos[typeof(TDto)]).GetAll();
    
    public TDto GetByKey<TEntity, TDto>(object[] key) where TDto : IDto where TEntity : IEntity =>
        ((IDao<TEntity, TDto>)_daos[typeof(TDto)]).GetByKey(key);

    public bool Update<TEntity, TDto>(TDto dto) where TDto : IDto where TEntity : IEntity =>
        ((IDao<TEntity, TDto>)_daos[typeof(TDto)]).Update(dto);

    public bool Remove<TEntity, TDto>(TDto dto) where TDto : IDto where TEntity : IEntity =>
        ((IDao<TEntity, TDto>)_daos[typeof(TDto)]).Remove(dto);
    
    public bool SaveChanges<TEntity, TDto>() where TDto : IDto where TEntity : IEntity =>
        ((IDao<TEntity, TDto>)_daos[typeof(TDto)]).SaveChanges();
    
    public void Dispose()
    {
        foreach (var dao in _daos.Values)
            ((IDisposable)dao).Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        foreach (var dao in _daos.Values)
            await ((IAsyncDisposable)dao).DisposeAsync();
    }

    private readonly Dictionary<Type, object> _daos = new();
}