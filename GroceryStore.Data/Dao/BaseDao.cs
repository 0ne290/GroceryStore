namespace GroceryStore.Data.Dao;

public abstract class BaseDao
{
    protected BaseDao(GroceryStoreContext dbContext, Mapper mapper)
    {
        DbContext = dbContext;
        Mapper = mapper;
    }
    
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
    protected readonly Mapper Mapper;
}