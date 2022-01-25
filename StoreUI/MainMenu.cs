using StoreModels;
using BL;
namespace StoreUI;

public class MainMenu : IMenu
{
    private IBL _bl;

    public MainMenu(IBL bl)
    {
        _bl = bl;
    }

    public void Start(){

        bool exit = false;

        Console.WriteLine("Your entering the Candy shop website\n");

        while(!exit)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Press [1] to enter as a customers");
            Console.WriteLine("Press [2] to enter into the order menu");
            Console.WriteLine("Press [3x] employee menu");
            Console.WriteLine("Press [3] to exit\n");
            
            string? login = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(login))
            {
                switch(login)
                {
                    case "1":
                        Console.WriteLine("Your Entering the customer menu");
                        FactoryMenu.GetMenu("customer").Start();
                        break;
                    
                    case "2":
                        Console.WriteLine("Your Entering the ordering menu");
                        FactoryMenu.GetMenu("ordering").Start();

                        break;
                    
                    case "3x":

                        Console.WriteLine("Login into employee menu");
                        FactoryMenu.GetMenu("employee").Start();

                        break;

                    case "3":
                        Console.WriteLine("Goodbye!");
                        exit = true;
                    break;
                    
                    default:
                        Console.WriteLine("Wrong input");
                        break;

                }//switch
            }//if 

        }//while loop

        }//Start
    // List<Customer> cust = _bl.GetAllCustomers();

    // foreach (Customer customer in cust)
    // {
    //     System.Console.WriteLine(customer);
    // }
} //MainMenu class

