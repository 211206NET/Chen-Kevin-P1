using Xunit;
using StoreModels;
using StoreUI;

namespace Tests;

public class ModelsTest
{
    [Fact]
    public void TestCustomerCreate()
    {
        //Arrange
        Customer testCustomer = new Customer();

        string username = "Test UserName";
        string password = "Test Password";

        //Act
        testCustomer.UserName = username;
        testCustomer.Password = password;

        //Assert
        Assert.Equal(username, testCustomer.UserName);
        Assert.Equal(password, testCustomer.Password);
    }

    [Fact]
    public void TestOrderCreate()
    {
        //Arrange
        Order testOrder = new Order();

        string orderdate = "18/15/2020";
        int orderID = 5;
        int storeID = 5;
        int customerId = 1;
        decimal totalorder = 20.00m;

        //Act
        testOrder.OrderDate = orderdate;
        testOrder.OrderId = orderID;
        testOrder.StoreId = storeID;
        testOrder.CustomerId = customerId;
        testOrder.Total = totalorder;

        //Assert
        Assert.Equal(orderdate, testOrder.OrderDate);
        Assert.Equal(orderID, testOrder.OrderId);
        Assert.Equal(storeID, testOrder.StoreId);
        Assert.Equal(customerId, testOrder.CustomerId);
        Assert.Equal(totalorder, testOrder.Total);
    }

    [Fact]
    public void TestLineItemCreate()
    {
        //Arrange
        LineItem testLineItems = new LineItem();
        int orderId = 3;
        int productID = 2;
        int quantity = 5;

        //Act
        testLineItems.OrderId = orderId;
        testLineItems.ProductId = productID;
        testLineItems.Quantity = quantity;

        //Assert
        Assert.Equal(orderId, testLineItems.OrderId);
        Assert.Equal(productID, testLineItems.ProductId);
        Assert.Equal(quantity, testLineItems.Quantity);
    }

    [Fact]
    public void TestProduct()
    {
        Product testproduct = new Product();

        int productID = 1;
        string Dis = "stuff";
        string prdouctname = "candyapple";
        decimal price = 4.00m;

        testproduct.ProductId = productID;
        testproduct.Description = Dis;
        testproduct.ProductName = prdouctname;
        testproduct.Price = price;

        Assert.Equal(productID, testproduct.ProductId);
        Assert.Equal(Dis, testproduct.Description); 
        Assert.Equal(prdouctname, testproduct.ProductName); 
        Assert.Equal(price, testproduct.Price);  
    }

    [Fact]
    public void TestProduct1()
    {
        Product testp1 = new Product();

        Assert.NotNull(testp1);
    }
    
    [Fact]
    public void TestOrder2()
    {
        //Arrange
        Order testOrder1 = new Order();
        
        Assert.NotNull(testOrder1);
    }

    [Fact]
    public void TestCustomer()
    {
        //Arrange
        Customer testCustomer1 = new Customer();
        
        Assert.NotNull(testCustomer1);
    }

    [Fact]
    public void TestInventory()
    {
        //Arrange
        Inventory testInventory = new Inventory();
        
        Assert.NotNull(testInventory);
    }

    [Fact]
    public void TestLineItem()
    {
        //Arrange
        LineItem testLineItem = new LineItem();
        
        Assert.NotNull(testLineItem);
    }

    [Fact]
    public void TestEmployee()
    {
        //Arrange
        Customer testCustomer = new Customer();

        string username = "Test UserName";
        string password = "Test Password";

        //Act
        testCustomer.UserName = username;
        testCustomer.Password = password;

        //Assert
        Assert.Equal(username, testCustomer.UserName);
        Assert.Equal(password, testCustomer.Password);
    }

    [Fact]
    public void TestStore()
    {
        //Arrange

        //Act
        Storefront storeNew = new Storefront();

        //Assert
        Assert.NotNull(storeNew);
    }

        [Fact]
    public void TestLineItemCreate2()
    {
        //Arrange
        LineItem testLineItems = new LineItem();
        int orderId = 1;
        int proId = 2;
        int quantity = 3;

        //Act
        testLineItems.OrderId = orderId;
        testLineItems.ProductId = proId;
        testLineItems.Quantity = quantity;

        //Assert
        Assert.Equal(orderId, testLineItems.OrderId);
        Assert.Equal(proId, testLineItems.ProductId);
        Assert.Equal(quantity, testLineItems.Quantity);
    }

    // [Theory]
    //[InlineData("#$%^@#$%#@")]
    //[InlineData("     ")]
    //[InlineData(null)]
    //[InlineData("")]
    // public void TestCustomerShouldNotSetInvalidInfo()
    // {
    //     //test if the input is correct in customer name and password



    // }



}// class ModelsTest