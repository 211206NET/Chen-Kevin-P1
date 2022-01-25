using StoreModels;
using BL;
using DL;

namespace StoreUI;

public static class FactoryMenu
{
    public static IMenu GetMenu(string menuString)
    {
        menuString = menuString.ToLower();
        //This is full dep injection

        string connectionString = File.ReadAllText("connectionString.txt");
        IRepo repo = new DBRepo(connectionString); //

        //next, I instantiated RRBL (an implementation of IBL) and then injected IRepo implementation for IBL/RRBL
        IBL bl = new CBL(repo);

        switch (menuString)
        {
            case "main":
                return new MainMenu(bl);

            case "customer":
                return new CustomerMenu(bl);
            
            case "ordering":
                return new OrderMenu(bl);
            
            case "employee":
                return new EmployeeMenu(bl);
            
            default:
                return new MainMenu(bl);
        }
    }



} //end of factory bracket 