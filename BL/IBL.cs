using StoreModels;

namespace BL;

public interface IBL
{
    // Restaurant SearchRestaurant(string searchString);

    List<Customer> GetAllCustomers();

    List<Order> GetAllOrders(int custID);

    void AddCustomer(Customer customerToAdd);

    int IsDuplicate(Customer customerToFind);

    int GetQuantity(int num);
    
    int IsEmployee(Customer employeeToFind);

    int AddOrder(int CustomerId, Order OrderToAdd);

    void AddLineItem(LineItem Cart, int orderId);

    void RestockInventory(int prodID, int q);

    List<Product> GetAllProduct();

    //void AddInventory(int inventoryId, Order orderId);

}