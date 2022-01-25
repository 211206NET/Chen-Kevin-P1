using StoreModels;

namespace DL;

public interface IRepo
{

    List<Customer> GetAllCustomers();

    List<Product> GetAllProduct();

    List<Order> GetAllOrders(int custID);
    void AddCustomer(Customer customerToAdd);

    //void AddInventory(Inventory inventoryId, Order orderId);

    int IsDuplicate(Customer customerToFind);

    int GetQuantity(int num);

    int IsEmployee(Customer employeeToFind);

    int AddOrder(int CustomerId, Order OrderToAdd);

    void AddLineItem(LineItem Cart, int orderId);

    void RestockInventory(int prodID, int q);




}