namespace StoreModels;

public class LineItem
{

    public LineItem() {}
    public LineItem(Product productItem, int orderId, int productId, int quantity)
    {
        this.OrderId = orderId;
        this.ProductId = productId;
        this.Quantity = quantity; 
    }
    public Product ProductItem { get; set; }
    public int OrderId { get; set; }
    public int ProductId {get; set;}
    public int Quantity { get; set; }

}