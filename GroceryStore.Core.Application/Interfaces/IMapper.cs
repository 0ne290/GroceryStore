using GroceryStore.Core.Domain.Interfaces;

namespace GroceryStore.Core.Application.Interfaces;

public interface IMapper
{
    IDto EntityToDto(IEntity entity);
}