using GroceryStore.Core.Domain.Interfaces;

namespace GroceryStore.Core.Application;

public class EntityService
{
    public EntityService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    
    
    
    private readonly IUnitOfWork _unitOfWork;
}