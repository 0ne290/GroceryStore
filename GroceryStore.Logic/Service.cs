using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic;

public class Service<TEntity, TDto> : IService<TDto> where TDto : IDto where TEntity : IEntity
{
    public Service(IDao<TEntity, TDto> dao) => _dao = dao;

    public bool Add(TDto dto) => _dao.Create(dto);

    public IEnumerable<TDto> GetAll() => _dao.GetAll();

    public TDto GetByKey(object[] key) => _dao.GetByKey(key);

    public bool Update(TDto dto) => _dao.Update(dto);
    
    public bool SaveChanges() => _dao.SaveChanges();
    
    public void Dispose() => _dao.Dispose();

    public async ValueTask DisposeAsync() => await _dao.DisposeAsync();

    private readonly IDao<TEntity, TDto> _dao;
}