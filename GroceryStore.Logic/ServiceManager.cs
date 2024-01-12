using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic;

public class ServiceManager : IServiceManager
{
    public void AddService<TDto>(IService<TDto> service) where TDto : IDto =>
        _services.Add(typeof(TDto), service);

    public bool Add<TDto>(TDto dto) where TDto : IDto => ((IService<TDto>)_services[typeof(TDto)]).Add(dto);

    public IEnumerable<TDto> GetAll<TDto>() where TDto : IDto => ((IService<TDto>)_services[typeof(TDto)]).GetAll();
    
    public TDto GetByKey<TDto>(object[] key) where TDto : IDto => ((IService<TDto>)_services[typeof(TDto)]).GetByKey(key);

    public bool Update<TDto>(TDto dto) where TDto : IDto => ((IService<TDto>)_services[typeof(TDto)]).Update(dto);
    
    public bool SaveChanges<TDto>() where TDto : IDto => ((IService<TDto>)_services[typeof(TDto)]).SaveChanges();
    
    public void Dispose()
    {
        foreach (var service in _services.Values)
            ((IDisposable)service).Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        foreach (var service in _services.Values)
            await ((IAsyncDisposable)service).DisposeAsync();
    }

    private readonly Dictionary<Type, object> _services = new();
}