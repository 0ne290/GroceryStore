namespace GroceryStore.Logic.Interfaces;

public interface IService<TDto> : IDisposable, IAsyncDisposable
{
    bool Add(TDto dto);

    IEnumerable<TDto> GetAll();
    
    TDto GetByKey(object[] key);

    bool Update(TDto dto);

    bool SaveChanges();
}