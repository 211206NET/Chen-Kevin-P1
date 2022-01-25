using BL;
using StoreModels;
namespace StoreUI;



public class CustomerMenu : IMenu
{
    private IBL _bl;

    public CustomerMenu(IBL bl)
    {
        //example of dependecy injection
        _bl = bl;
    }


    public void Start(){

        
        bool exit = false;
        do
        {
            Console.WriteLine("This is the customer's menu");
            Console.WriteLine("what would you like to do");
            Console.WriteLine("Enter [1] to sign in");
            Console.WriteLine("Enter [2] to sign up");
            
            string input = Console.ReadLine();
            Customer customer = new Customer();
            //Console.WriteLine(customer.Id);
            switch(input)
            {
                case "1": // this place holder for now in output customers name
                    bool exit1 = false;
                    while(!exit1)
                    {    
                        Console.WriteLine("Your signing in");
                        Console.WriteLine("Enter you Username");
                        customer.UserName = Console.ReadLine();
                        Console.WriteLine("Enter your password");
                        customer.Password = Console.ReadLine();
                        int CustomerID = _bl.IsDuplicate(customer);
                        if(CustomerID == -1)
                        {
                            Console.WriteLine("Wrong Username or Password");
                            Console.WriteLine("press ENTER to try again or enter [x] to exit");
                            string stat = "";
                            stat = Console.ReadLine();
                            if(stat == "x") exit1 = true;
                            
                        }
                        else
                        {
                            Console.WriteLine("Your now login");
                            if(CurCustomer.cur_customer == null)
                            {
                                CurCustomer.cur_customer = new Customer();
                            }
                            CurCustomer.cur_customer.Id = CustomerID;
                            Console.WriteLine(CurCustomer.cur_customer.Id);
                            exit1 = true;
                        }
                    }//while                    
                    break;
                
                case "2":
                    
                    Console.WriteLine("Enter UserName");
                    customer.UserName = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    customer.Password = Console.ReadLine();
                    _bl.AddCustomer(customer);
                    //code
                    break;

                // case "3":
                //     //code
                //     break;
                
                default:
                    //code
                    Console.WriteLine("Wrong input exiting out now!!!");
                    exit = true;
                    break;


            } // switch case        

        } while(exit);

    } // void start


    // private void CreateNewCustomer()
    // {
    //     createCustomer:
    //     Console.WriteLine("Adding a new customer:");
    //     Console.WriteLine("UserName: ");
    //     string username = Console.ReadLine() ?? "";
    //     Console.WriteLine("Password: ");
    //     string password = Console.ReadLine() ?? "";
    //     Console.WriteLine("City: ");
    //     string city = Console.ReadLine() ?? "";


    //     try
    //     {
    //         Customer newCustomer = new Customer {
    //             UserName = username,
    //             Password = password,
    //             City = city
                
    //         };
    //         _bl.AddCustomer(newCustomer);
    //     }
    //     catch (InputInvalidException ex)
    //     {
    //         Console.WriteLine(ex.Message);
    //         goto createCustomer;
    //     }
    //     catch (DuplicateRecordException ex)
    //     {
    //         Console.WriteLine(ex.Message);
    //         goto createCustomer;
    //     }
    // }//CreateNewCustomer

} // CustomerMenu bracket