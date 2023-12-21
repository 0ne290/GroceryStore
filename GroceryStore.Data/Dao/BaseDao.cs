namespace GroceryStore.Data.Dao;

public abstract class BaseDao
{
    protected BaseDao(GroceryStoreContext dbContext) => DbContext = dbContext;
    
    public bool SaveChanges()
    {
        try
        {
            DbContext.SaveChanges();
        }
        catch
        {
            return false;
        }

        return true;
    }

    protected readonly GroceryStoreContext DbContext;
}