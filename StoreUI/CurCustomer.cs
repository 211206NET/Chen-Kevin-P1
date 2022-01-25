using StoreModels;
using BL;
namespace StoreUI;

public static class CurCustomer
{
    //public static int ordernum {get; set;}
    public static Customer cur_customer {get; set;}
    public static Customer cur_employee {get; set;}
    public static Storefront cur_store {get; set;}
    public static List<LineItem> cur_lineItems {get; set;}
    public static Order cur_order {get; set;}


    public static decimal CalculateTotal() 
    {
        decimal total = 0;
        if(cur_lineItems?.Count > 0 )
        {

            foreach(LineItem orderitem in cur_lineItems)
            {
                
                total += orderitem.ProductItem.Price * orderitem.Quantity;
            }
            
        }
        
        return total;
    }



}