using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic;

public class Service<TDto> : IService<TDto> where TDto : IDto
{
    public Service(IDao<TDto> dao) => _dao = dao;

    public bool Add(TDto dto) => _dao.Create(dto);

    public IEnumerable<TDto> GetAll() => _dao.GetAll();

    public void Update(TDto dto) => _dao.Update(dto);
    
    public bool SaveChanges() => _dao.SaveChanges();
    
    public void Dispose() => _dao.Dispose();

    public async ValueTask DisposeAsync() => await _dao.DisposeAsync();

    private readonly IDao<TDto> _dao;
}