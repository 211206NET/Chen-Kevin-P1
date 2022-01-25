using Microsoft.AspNetCore.Mvc;
using StoreModels;
using BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private IBL _bl;
        public EmployeeController(IBL bl)
        {
            _bl = bl;
        }

        //Get api/<EmployeeController>
        [HttpGet("Login as Employee {Username},{Password}")]
        public ActionResult<Customer> CustomerLogin(string Username, string Password)
        {

            Customer cur_employee = new Customer();
            cur_employee.UserName = Username;
            cur_employee.Password = Password;
            int i = _bl.IsEmployee(cur_employee);
            if (i > -1)
            {
                return Ok($"Your login in as a employee remember you ID is {cur_employee.Id}");
            }
            else
            {
                return Unauthorized("wrong password or username");
            }

        }

        // POST api/<EmployeeController>
        [HttpPost("updating the product's quantity in the current inventory")]
        public ActionResult Post(int productId, int Qamount)
        {
            if (productId > -1 || Qamount > -1)
            {
                _bl.RestockInventory(productId, Qamount);
                return Ok("The inventory was updated");
            }
            else
            {
                return Unauthorized("The product ID or quantity was wrong");
            }
        }

    }
}
