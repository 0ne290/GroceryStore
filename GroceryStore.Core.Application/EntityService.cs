using System.Linq.Expressions;
using GroceryStore.Core.Application.Interfaces;
using GroceryStore.Core.Domain.Interfaces;

namespace GroceryStore.Core.Application;

/*
    Попытка проиллюстрировать что такое Use Case. Зависимость слоя представления от сущностей нежелательна (но, кстати,
    не противоречит Clean Architecture). Как видно, в моем проекте всего один "божественный" Use Case (тем более, что
    это, фактически, мини-обертка над UnitOfWork) Все это - зло. Поэтому в полноценных приложениях Use Case'ы предельно
    детерминированы (таким образом, в большинстве случаев им необходим один конкретный DAO (или небольшое их множество)
    и они не требуют сущности для этих DAO (вместо этого они требуют небольшой перечень связанных по смыслу критериев в
    соответствии с выполняемой задачей и уже сами создают сущность из этих критериев)). Например, в моем случае можно
    было создать Use Case "Добавить географическую идентичность". Тогда этот Use Case содержал бы четыре
    DAO - IDao<Country>, IDao<Region>, IDao<City> и IDao<Street>. А в параметры он бы принимал всего лишь названия этих
    четырех сущностей.
*/
public class EntityService : IEntityService
{
    public EntityService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public bool Add<TEntity>(TEntity entity) where TEntity : class, IEntity
    {
        if (entity.IsEmpty())
            return false;
        
        _unitOfWork.Add(entity);

        return true;
    }

    public IEnumerable<TDto> Get<TEntity, TDto>(Expression<Func<TEntity, bool>> filter) where TEntity : class, IEntity
        where TDto : IDto
    {
        var entities = _unitOfWork.Get(filter);
        
        return from entity in entities
            select (TDto)_mapper.EntityToDto(entity);
    }

    public IEnumerable<TDto> GetAll<TEntity, TDto>() where TEntity : class, IEntity where TDto : IDto
    {
        var entities = _unitOfWork.GetAll<TEntity>();
        
        return from entity in entities
            select (TDto)_mapper.EntityToDto(entity);
    }
    
    public TDto GetByKey<TEntity, TDto>(object[] key) where TEntity : class, IEntity where TDto : IDto, new()
    {
        var entity = _unitOfWork.GetByKey<TEntity>(key);

        return entity == null ? new TDto() { IsEmpty = true } : (TDto)_mapper.EntityToDto(entity);
    }

    public bool Update<TEntity>(TEntity entity) where TEntity : class, IEntity
    {
        if (entity.IsEmpty())
            return false;
        
        _unitOfWork.Update(entity);

        return true;
    }

    public bool Remove<TEntity>(TEntity entity) where TEntity : class, IEntity
    {
        if (entity.IsEmpty())
            return false;
        
        _unitOfWork.Remove(entity);

        return true;
    }

    public Exception? SaveChanges<TEntity>() where TEntity : class, IEntity => _unitOfWork.SaveChanges<TEntity>();

    public IDictionary<Type, Exception?> SaveAllChanges() => _unitOfWork.SaveAllChanges();

    public void Dispose() => _unitOfWork.Dispose();

    public async ValueTask DisposeAsync() => await _unitOfWork.DisposeAsync();
    
    private readonly IUnitOfWork _unitOfWork;
    
    private readonly IMapper _mapper;
}