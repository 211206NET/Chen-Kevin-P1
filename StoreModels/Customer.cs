using CustomExceptions;
using System.Text.RegularExpressions;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace StoreModels;


public class Customer
{
    public Customer()
    {}

    public Customer(string username, string password, string city)
    {   
        this.Peoples = new List<string>();
        this.UserName = username;
        this.Password = password;
        this.City =  city;
    }
    public Customer(DataRow row)
    {
        this.Id = (int) row["Id"];
        this.UserName = row["UserName"].ToString() ?? "";
        this.Password = row["Password"].ToString() ?? "";
        // this.City = row["City"].ToString() ?? "";
    }

    public void ToDataRow(ref DataRow row)
    {
        row["UserName"] = this.UserName;
        row["Password"] = this.Password;
        // row["City"] = this.City;
    }

    public int Id {get; set;}

    [Required]
    [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Username can only have alphanumeric characters")]
    public string UserName {get; set;}
    [Required]
    [RegularExpression("^[a-zA-Z0-9!?']+$", ErrorMessage = "Password can only have alphanumeric characters, !, ?, and '")]
    public string Password {get; set;}

    public string City {get; set;}

    public List<string> Peoples {get; set;} // temp list of customers

    //public string Email {get; set;}
    //public List<string> Peoples {get; set;} // temp list of customers
    //public List<Order> Orders {get; set;}


    public override string ToString()
    {
            return $"Username: {this.UserName} Password: {this.Password}";
    }

    
}