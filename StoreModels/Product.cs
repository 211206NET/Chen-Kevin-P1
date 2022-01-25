namespace StoreModels;

public class Product
{
    public int ProductId {get; set;}
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    // public Product (DataRow row)
    // {
    //     this.ProductId = (int) row["Id"];
    //     this.ProductName = row["ProductName"].ToString() ?? "";
    //     this.Description = row["Description"].ToString() ?? "";
    //     this.Price = row["Price"].ToString() ?? "";
    // }

    // public void ToDataRow(ref DataRow row)
    // {
    //     row["UserName"] = this.UserName;
    //     row["Password"] = this.Password;
    //     // row["City"] = this.City;
    // }


}