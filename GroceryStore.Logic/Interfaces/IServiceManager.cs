namespace GroceryStore.Logic.Interfaces;

public interface IServiceManager : IDisposable, IAsyncDisposable
{
    void AddService<TDto>(IService<TDto> service) where TDto : IDto;

    bool Add<TDto>(TDto dto) where TDto : IDto;

    IEnumerable<TDto> GetAll<TDto>() where TDto : IDto;
    
    TDto GetByKey<TDto>(object[] key) where TDto : IDto;

    bool Update<TDto>(TDto dto) where TDto : IDto;

    bool SaveChanges<TDto>() where TDto : IDto;
}