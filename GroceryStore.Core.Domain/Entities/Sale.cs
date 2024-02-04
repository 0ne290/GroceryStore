namespace GroceryStore.Core.Domain.Entities;

public sealed class Sale : BaseEntity
{
    public Sale() : base(new int[2]) { }

    public override bool IsEmpty() => base.IsEmpty() || Date == default;
    
    public int ProductKey { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public int CustomerKey { get => PrimaryKey[1]; set => PrimaryKey[1] = value; }

    public DateTime Date { get; set; }

    public int? Quantity { get; set; }

    public RegularCustomer CustomerKeyNavigation { get; set; } = null!;

    public Product ProductKeyNavigation { get; set; } = null!;
}
