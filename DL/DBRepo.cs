using StoreModels;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DL;

public class DBRepo : IRepo

{
    private string _connectionString;

    public DBRepo(string connectString)
    {
        _connectionString = connectString;
    }
    
    
    public List<Customer> GetAllCustomers()
    {

        List<Customer> allCust = new List<Customer>();
        using SqlConnection connection = new SqlConnection(_connectionString);
        string cusToSelect = "SELECT * FROM Customer";
        DataSet CSSet = new DataSet();
        using SqlDataAdapter cusAdapter = new SqlDataAdapter(cusToSelect, connection);    
        cusAdapter.Fill(CSSet, "Customer");
        DataTable? cusTable = CSSet.Tables["Customer"];
            
        if(cusTable != null)
        { 
            foreach(DataRow row in cusTable.Rows)
            {
                Customer custo = new Customer(row);
                allCust.Add(custo);
            }
        } 
        return allCust;
    }

    public List<Order> GetAllOrders(int custID)
    {
        List<Order> allOrder = new List<Order>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string orderToSelect = $"SELECT * FROM Orders WHERE CustomerId = {custID} ";
            using(SqlCommand cmd = new SqlCommand(orderToSelect, connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Order order = new Order();
                        order.OrderId = reader.GetInt32(0);
                        order.OrderDate = reader.GetString(1);
                        order.CustomerId = reader.GetInt32(2);
                        order.StoreId = reader.GetInt32(3);
                        
                        allOrder.Add(order);
                    }
                }
            }
            connection.Close();
        }
        return allOrder;

    }


    
    public void AddCustomer(Customer customerToAdd)
    {
        DataSet custSet = new DataSet();
        string selectCmd = "SELECT * FROM Customer WHERE Id = -1";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            using(SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection))
            {
                dataAdapter.Fill(custSet, "Customer");

                DataTable custTable = custSet.Tables["Customer"];

                DataRow newRow = custTable.NewRow();

                customerToAdd.ToDataRow(ref newRow);

                custTable.Rows.Add(newRow);

                string insertCmd = $"INSERT INTO Customer (UserName, Password) VALUES ('{customerToAdd.UserName}', '{customerToAdd.Password}')"; 

                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter);

                dataAdapter.InsertCommand = cmdBuilder.GetInsertCommand();

                dataAdapter.Update(custTable);
            }
        }      
    }



    // public void AddCandy(Product productToAdd)
    // {
    //     DataSet custSet = new DataSet();
    //     string selectCmd = "SELECT * FROM Product WHERE Id = -1";
    //     using(SqlConnection connection = new SqlConnection(_connectionString))
    //     {
    //         using(SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection))
    //         {
    //             dataAdapter.Fill(custSet, "Product");

    //             DataTable custTable = custSet.Tables["Product"];

    //             DataRow newRow = custTable.NewRow();

    //             productToAdd.ToDataRow(ref newRow);

    //             custTable.Rows.Add(newRow);

    //             string insertCmd = $"INSERT INTO Customer (UserName, Password) VALUES ('{customerToAdd.UserName}', '{customerToAdd.Password}')"; 

    //             SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter);

    //             dataAdapter.InsertCommand = cmdBuilder.GetInsertCommand();

    //             dataAdapter.Update(custTable);
    //         }
    //     }      
    // }

    public void RestockInventory(int prodID, int q)
    {
        
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string invent = "UPDATE Inventory SET Quantity = @p0 WHERE ProductId = @p1";
            using(SqlCommand cmd = new SqlCommand(invent, connection))
            {
                cmd.Parameters.AddWithValue("@p1", prodID);
                cmd.Parameters.AddWithValue("@p0", q);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public int GetQuantity(int num)
    {
        string searchQ = $"SELECT Quantity FROM Inventory WHERE ProductId = {num}";

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand(searchQ, connection);

        connection.Open();

        using SqlDataReader reader = cmd.ExecuteReader();

        if(reader.Read())
        {
            int temp = 0;
            temp = reader.GetInt32(0);
            return temp;
        }
        return -1;

    } 


    public int IsDuplicate(Customer customerToFind) //this is find customer
    {
        string searchQuery = $"SELECT * FROM Customer WHERE UserName='{customerToFind.UserName}' AND Password='{customerToFind.Password}'";

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand(searchQuery, connection);

        connection.Open();

        using SqlDataReader reader = cmd.ExecuteReader();

        if(reader.Read())
        {
            return reader.GetInt32(0);
        }
        return -1;
    }

    public int IsEmployee(Customer employeeToFind)
    {
        string searchQuery = $"SELECT * FROM Employee WHERE UserName='{employeeToFind.UserName}' AND Password='{employeeToFind.Password}'";

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand(searchQuery, connection);

        connection.Open();

        using SqlDataReader reader = cmd.ExecuteReader();

        if(reader.Read())
        {
            return reader.GetInt32(0);
        }
        return -1;
    }



    public List<Product> GetAllProduct()
    {
        List<Product> allProduct = new List<Product>();
        using SqlConnection connection = new SqlConnection(_connectionString);
        string pSelect = "SELECT p.Id, p.ProductName, p.Description, p.Price, i.StoreId, i.Quantity\nFROM Product p\nINNER JOIN Inventory i ON p.Id = i.ProductId\n WHERE i.StoreId = 1\nORDER BY p.Id";
        DataSet ProdSet = new DataSet();
        using SqlDataAdapter prodAdapter = new SqlDataAdapter(pSelect, connection);
        prodAdapter.Fill(ProdSet, "Product");
        DataTable? ProductTable = ProdSet.Tables["Product"];
        foreach(DataRow row in ProductTable.Rows)
        {
            Product prod = new Product();
            prod.ProductId = (int) row["Id"];
            prod.ProductName = row["ProductName"].ToString();
            prod.Description = row["Description"].ToString();
            prod.Price = (decimal) row["Price"];
            allProduct.Add(prod);
        }
        return allProduct;

    }


    
    public int AddOrder(int CustomerId, Order OrderToAdd)
    {
        int newOrderid = 0;
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sqlCmd = "INSERT INTO Orders (CustomerId, StoreId, OrderDate, Total) OUTPUT INSERTED.ID VALUES (@CustomerId, @StoreId, @OrderDate, @Total)";

            using(SqlCommand cmd = new SqlCommand(sqlCmd, connection))
            {
                SqlParameter param = new SqlParameter("@CustomerId", OrderToAdd.CustomerId);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StoreId", OrderToAdd.StoreId);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDate", OrderToAdd.OrderDate);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Total", OrderToAdd.Total);
                cmd.Parameters.Add(param);

                newOrderid = (int)cmd.ExecuteScalar();
            }
            connection.Close();
        }
        return newOrderid;              
    }


    public void AddLineItem(LineItem Cart, int orderId)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sqlCmd = "INSERT INTO LineItem (OrderId, ProductId, Quantity) VALUES (@OrderId, @ProductId, @Quantity)";
            using(SqlCommand cmd = new SqlCommand(sqlCmd, connection))
            {
                cmd.Parameters.Add(new SqlParameter("@OrderId", orderId));
                cmd.Parameters.Add(new SqlParameter("@ProductId", Cart.ProductId));
                cmd.Parameters.Add(new SqlParameter("@Quantity", Cart.Quantity));
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }





}
