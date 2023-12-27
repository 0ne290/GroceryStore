namespace GroceryStore.Logic.Interfaces;

public interface IService<TDto>
{
    bool Add(TDto dto);

    IEnumerable<TDto> GetAll();

    void Update(TDto dto);

    bool SaveChanges();
}