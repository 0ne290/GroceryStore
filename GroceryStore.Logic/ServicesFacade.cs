using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic;

public class ServicesFacade : IServicesFacade
{
    public void AddService<TDto>(IService<TDto> service) where TDto : IDto =>
        _services.Add(typeof(TDto), service);

    public bool Add<TDto>(TDto dto) where TDto : IDto => ((IService<TDto>)_services[typeof(TDto)]).Add(dto);

    public IEnumerable<TDto> GetAll<TDto>() where TDto : IDto => ((IService<TDto>)_services[typeof(TDto)]).GetAll();

    public void Update<TDto>(TDto dto) where TDto : IDto => ((IService<TDto>)_services[typeof(TDto)]).Update(dto);
    
    public bool SaveChanges<TDto>() where TDto : IDto => ((IService<TDto>)_services[typeof(TDto)]).SaveChanges();
    
    public void Dispose()
    {
        foreach (var service in _services)
            ((IService<>)service).
    }

    public async ValueTask DisposeAsync()
    {
        await _dao.DisposeAsync();
    }

    private readonly Dictionary<Type, object> _services = new();
}