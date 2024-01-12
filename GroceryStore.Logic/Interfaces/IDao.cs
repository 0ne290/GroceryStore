namespace GroceryStore.Logic.Interfaces;

public interface IDao<TDto> : IDisposable, IAsyncDisposable
{
    bool Create(TDto dto);

    IEnumerable<TDto> GetAll();

    TDto GetByKey(object[] key);

    bool Update(TDto dto);

    bool Remove(TDto dto);

    bool SaveChanges();
}