namespace GroceryStore.Logic.Interfaces;

public interface IServicesFacade : IDisposable, IAsyncDisposable
{
    void AddService<TDto>(IService<TDto> service) where TDto : IDto;

    bool Add<TDto>(TDto dto) where TDto : IDto;

    IEnumerable<TDto> GetAll<TDto>() where TDto : IDto;

    void Update<TDto>(TDto dto) where TDto : IDto;

    bool SaveChanges<TDto>() where TDto : IDto;
}