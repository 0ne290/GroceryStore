namespace GroceryStore.Core.Domain.Interfaces;

public interface ISaver
{
    Exception? SaveChanges();
}