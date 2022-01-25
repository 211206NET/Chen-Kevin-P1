namespace StoreModels;

public class Storefront
{
    public Storefront()
    {
        this.Inventories = new List<Inventory>();
    }

    public int StoreId = 1;
    //{get; set;}
    public string Address { get; set; }
    public string Name { get; set; }
    public List<Inventory> Inventories { get; set; }
    public List<Order> Orders { get; set; }
}