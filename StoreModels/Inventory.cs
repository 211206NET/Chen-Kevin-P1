namespace StoreModels;


public class Inventory 
{
    public int ProductId{ get; set; }

    public int InventoryId { get; set; }

    public int StoreId {get; set; }

    public int Quantity { get; set;}

    public Product ProductItem {get; set;}
    

}