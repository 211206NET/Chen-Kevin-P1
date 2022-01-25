using BL;
using StoreModels;
using System.Linq;
namespace StoreUI;

public class OrderMenu : IMenu
{

    private IBL _bl;

    public OrderMenu(IBL bl)
    {
        _bl = bl;
    }

    public void Start()
    {   
        if(CurCustomer.cur_customer == null || CurCustomer.cur_customer.Id == 0 )
        {
            Console.WriteLine("please login first!");
            return;
        }
        if(CurCustomer.cur_lineItems == null)
        {
            CurCustomer.cur_lineItems = new List<LineItem>();
        }
        Order newOrder = new Order();
        LineItem AddtoCart = new LineItem();
        bool exit1 = false;
        
        bool exit2 = false;
        // Random rand = new Random();
        // int randOrderId = rand.Next(1, 50);
        DateTime t = DateTime.Now;
        string today = t.ToString("dd/MM/yyyy");
        
        while(!exit1)
        {
            Console.WriteLine("Welcome to the order menu of the CANDY store\n");
            //Console.WriteLine("What would you like to do?\nview product and place an order [1]\nview your cart [2]\ncheckout and exit [3]");
            Console.WriteLine("What would you like to do?\nview product and place an order [1]");
            Console.WriteLine("Just to view the product [2]");
            Console.WriteLine("exit back to main menu [3]");
            Console.WriteLine("Press [4] to view your orders so far.");
            Console.WriteLine("Press [5] to check quantity checker");
            string? input = Console.ReadLine();


        
            switch(input)
            {
                case"1":
                while(!exit2)
                {

                    Console.WriteLine("Welcome to the store! \n Please select the following products by number");
                    
                    // Storefront store = CurCustomer.cur_store;
                    Storefront store = new Storefront();
                    // Console.WriteLine(store.StoreId);
                    int storeID = store.StoreId;
                    List<Product> allProduct = _bl.GetAllProduct();
                    for(int i =0; i< allProduct.Count; i++)
                    {
                        Console.WriteLine($"[{i}] {allProduct[i].ProductName}: \n {allProduct[i].Description}: \n Price: {allProduct[i].Price}");
                    }
                    Console.WriteLine("\ninput the product number of the item you like to purchase\n");
                    int input1 = int.Parse(Console.ReadLine());
                    Product selectedProduct = allProduct[input1];
                    //selectedProduct.ProductName = allProduct[input1].ProductName;
                    
                    //Console.WriteLine($"How much of the would you like to buy of {selectedProduct.ProductName}");
                    Console.WriteLine($"How much of the would you like to buy of {allProduct[input1].ProductName}");
                    
                    int input2 = int.Parse(Console.ReadLine());
                    int productId = selectedProduct.ProductId;
                    Console.WriteLine($"\nThis is the product ID{productId}\n");

                    AddtoCart.ProductItem = selectedProduct;
                    AddtoCart.Quantity = input2;
                    AddtoCart.ProductId = selectedProduct.ProductId;
                    
                    CurCustomer.cur_lineItems.Add(AddtoCart);

                    decimal total = CurCustomer.CalculateTotal();

                    if(CurCustomer.cur_order == null)
                    {
                        newOrder.OrderDate = today;
                        //newOrder.OrderNumber = randOrderId;
                        newOrder.StoreId = 1;
                        newOrder.CustomerId = CurCustomer.cur_customer.Id;
                        newOrder.Total = total;

                        CurCustomer.cur_order = newOrder;

                    }
                    else if ( CurCustomer.cur_order != null )
                    {
                        CurCustomer.cur_order.Total = CurCustomer.cur_order.Total + total;
                    }
                    else
                    {}
                    Console.WriteLine("\nerror error starts here\n");
                    Console.WriteLine($"\nYour total {CurCustomer.cur_order.Total}");

                    Console.WriteLine("You wish to continue shopping?");
                    Console.WriteLine("[1] to place order\n[2] to continue shopping");

                    string cshop = Console.ReadLine();

                    if( cshop == "1")
                    {
                        int newOrderId = _bl.AddOrder(CurCustomer.cur_customer.Id, CurCustomer.cur_order);
                        foreach( LineItem items in CurCustomer.cur_lineItems)
                        {
                            _bl.AddLineItem(items, newOrderId);
                            System.Console.WriteLine("Thank you for placing your order!\n");
                            Order clearOrder = new Order();
                            CurCustomer.cur_order = clearOrder;
                            exit2 = true;
                        }
                    }
                    else if( cshop == "2")
                    {

                    }


                    
                    
                    //Console.WriteLine(total);
                    //Console.WriteLine($"Total: {newOrder.Total}");
                    // Console.WriteLine("Are you finish adding to the shopping cart?");
                    // Console.WriteLine("[1] for YES\n[2] for NO");
                    // string? done = Console.ReadLine();
                    // if( done == "1") 
                    // {
                    //     exit2 = true;
                    // }


                }//while case1:
                break;
                
                case"2":
                Console.WriteLine("Just view the product");
                List<Product> all2Product = _bl.GetAllProduct();
                for(int i =0; i< all2Product.Count; i++)
                {
                    Console.WriteLine($"[{i}] {all2Product[i].ProductName}: \n {all2Product[i].Description}: \n Price: {all2Product[i].Price}");
                }
            
                break;
                case"3":
                Console.WriteLine("Your returning to main menu");
                exit1 = true;
                //foreach(LineItem item in CurCustomer.cur_lineItems)
                // foreach(LineItem item in cur_cart)
                // {
                //     Console.WriteLine($"Name: {item.ProductItem.ProductName} {item.Quantity}");
                // }
                
                break;
                case"4":
                Console.WriteLine("Outputting customer orders\n");
                Console.WriteLine($"Your customer Id was {CurCustomer.cur_customer.Id}\n");
                List<Order> custOrder = _bl.GetAllOrders(CurCustomer.cur_customer.Id);
                foreach(Order cur_order in custOrder)
                {
                    Console.WriteLine($"This is your customer ID {cur_order.CustomerId}");
                    Console.WriteLine($"This is your order ID {cur_order.OrderId}");
                    Console.WriteLine($"This is the date you bought it from {cur_order.OrderDate}");
                    Console.WriteLine($"The store you bought it from {cur_order.StoreId}");
                    Console.WriteLine($"The total cost of that order {cur_order.Total}");
                }
                break;
                case"5":
                int hold1;
                Console.WriteLine("The Quantity checker for inventory\n");
                Console.WriteLine("Im going to test with product 1");
                hold1 =_bl.GetQuantity(1);
                Console.WriteLine($"The output for the inventory quantity {hold1}\n");
                break;
                
                default:
                    Console.WriteLine("Wrong input");
                break;
            }//switch
        
        }//while


        


        



    }//Start
}//OrderMenu