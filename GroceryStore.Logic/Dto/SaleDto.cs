namespace GroceryStore.Logic.Dto;

public class SaleDto : BaseDto
{
    public SaleDto(int productKey, int customerKey, DateTime date) : base(new [] { productKey, customerKey }) => Date = date;

    public override bool IsEmpty() => base.IsEmpty() || Date.Equals(DateTime.UnixEpoch);
    
    public int ProductKey { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public int CustomerKey { get => PrimaryKey[1]; set => PrimaryKey[1] = value; }

    public DateTime Date { get; set; }

    public int Quantity { get; set; } = -1;

    //public IRegularCustomer CustomerKeyNavigation { get; set; } = null!;

    //public IProduct ProductKeyNavigation { get; set; } = null!;
}
