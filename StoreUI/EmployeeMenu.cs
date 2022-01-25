using BL;
using StoreModels;
namespace StoreUI;



public class EmployeeMenu : IMenu
{
    private IBL _bl;

    public EmployeeMenu(IBL bl)
    {
        //example of dependecy injection
        _bl = bl;
    }


    public void Start(){

        
        bool exit = false;
        while(!exit)
        {
            Console.WriteLine("This is the customer's menu");
            Console.WriteLine("what would you like to do");
            Console.WriteLine("Enter [1] to sign in as a employee");
            Console.WriteLine("Enter [2] show all current customer");
            Console.WriteLine("Enter [4] to restock product");
            Console.WriteLine("Enter [3] to return to menu");
            
            string input = Console.ReadLine();
            Customer employee = new Customer();
            switch(input)
            {
                case "1": // this place holder for now in output customers name
                        Console.WriteLine("Your signing in as a employee");
                        Console.WriteLine("Enter you Username");
                        employee.UserName = Console.ReadLine();
                        Console.WriteLine("Enter your password");
                        employee.Password = Console.ReadLine();
                        int EmployeeID = _bl.IsEmployee(employee);
                        if(EmployeeID == -1)
                        {
                            Console.WriteLine("Wrong Username or Password");
                            
                        }
                        else
                        {
                            Console.WriteLine("Your now login");
                            if(CurCustomer.cur_employee == null)
                            {
                                CurCustomer.cur_employee = new Customer();
                            }
                            CurCustomer.cur_employee.Id = EmployeeID;
                            Console.WriteLine(CurCustomer.cur_employee.Id);
                        }
                    
                    break;
                
                case "2":
                    if(CurCustomer.cur_employee == null || CurCustomer.cur_employee.Id == 0 )
                    {
                        Console.WriteLine("Your not an employee!");
                        return;
                    }
                    Console.WriteLine("List of customers");
                    List<Customer> LCustomers = _bl.GetAllCustomers();
                    foreach(Customer cust in LCustomers)
                    {
                        Console.WriteLine(cust.UserName);
                    }
;
                    //code
                    break;

                case "3":
                    exit = true;
                    //return;
                    break;

                case "4":
                    Console.WriteLine("Your restocking product\n");
                    Console.WriteLine("Just the product");
                    List<Product> all2Product = _bl.GetAllProduct();
                    for(int i =0; i< all2Product.Count; i++)
                    {
                    Console.WriteLine($"[{i}] {all2Product[i].ProductName}: \n {all2Product[i].Description}: \n Price: {all2Product[i].Price}");
                    }
                    Console.WriteLine("Enter the Product ID \n");
                    int input1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Product ammount\n");
                    int input2 = int.Parse(Console.ReadLine());
                    _bl.RestockInventory(input1, input2);
                    
                    break;
                
                default:
                    //code
                    Console.WriteLine("Wrong input");
                    break;


            } // switch case        

        }//while

    } //start

}