namespace GroceryStore.Logic.Interfaces;

public interface IDao<TDto> : IDisposable, IAsyncDisposable
{
    bool Create(TDto dto);

    IEnumerable<TDto> GetAll();

    TDto GetByKey(object[] key);

    void Update(TDto dto);

    void Remove(TDto dto);

    bool SaveChanges();
}