using GroceryStore.Core.Domain.Interfaces;

namespace GroceryStore.Core.Domain.Entities;

public abstract class BaseEntity : IEntity
{
    protected BaseEntity(int[] primaryKey) => PrimaryKey = primaryKey;
    
    public virtual bool IsEmpty() => PrimaryKey.Any(key => key < 1);

    protected int[] PrimaryKey { get; set; }
}