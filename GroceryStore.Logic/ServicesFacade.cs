using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic;

public class ServicesFacade
{
    public void AddService<TDto>(Service<IDto> service) where TDto : IDto =>
        _services.Add(typeof(TDto), service);

    public bool Add<TDto>(TDto dto) where TDto : IDto => _services[typeof(TDto)].Add(dto);

    public IEnumerable<TDto> GetAll<TDto>() where TDto : IDto => (IEnumerable<TDto>)_services[typeof(TDto)].GetAll();

    public void Update<TDto>(TDto dto) where TDto : IDto => _services[typeof(TDto)].Update(dto);
    
    public bool SaveChanges<TDto>() where TDto : IDto => _services[typeof(TDto)].SaveChanges();

    private readonly Dictionary<Type, Service<IDto>> _services = new();
}