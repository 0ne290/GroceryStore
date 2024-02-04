namespace GroceryStore.Core.Application.Dto;

public class ProductDto : BaseDto
{
    public ProductDto(bool isEmpty = true) : base(isEmpty) { }

    public int Key { get; set; }

    public string Name { get; set; }

    public string DegreeOfProcessing { get; set; }

    public int ManufacturerKey { get; set; }

    public int BestBefore { get; set; }
}