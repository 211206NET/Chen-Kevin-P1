using Microsoft.AspNetCore.Mvc;
using StoreModels;
using BL;
using CustomExceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IBL _bl;
        public CustomerController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<CustomerController>
        [HttpGet("Get all customer info")]
        public List<Customer> Get()
        {
            return _bl.GetAllCustomers();
        }

        
        
        // GET api/<CustomerController>/5
        [HttpGet("Get customer's order by ID")]
        public ActionResult <List<Order>> Get(int userID)
        {
            List<Order> allOrder = _bl.GetAllOrders(userID);
            if (allOrder.Count > 0)
            {
                return Ok(allOrder);
            }
            else
            {
                return Unauthorized("No orders");
            }
        }

        //Get api/<CustomerController>
        [HttpGet("Login Customer {Username},{Password}")]
        public ActionResult<Customer> CustomerLogin(string Username, string Password)
        {

            Customer cur_customer = new Customer();
            cur_customer.UserName = Username;
            cur_customer.Password = Password;
            int i = _bl.IsDuplicate(cur_customer);
            if (i > -1)
            {
                return Ok($"Your login in with the customer ID of {cur_customer.Id}");
            }
            else
            {
                return Unauthorized("wrong password or username");
            }

        }



        // POST api/<CustomerController>
        [HttpPost("Sign up as a customer")]
        public ActionResult Post([FromBody] Customer custToAdd)
        {
            try
            {
                _bl.AddCustomer(custToAdd);
                return Created("Successfully added", custToAdd);
            }
            catch (DuplicateRecordException ex)
            {
                return Conflict(ex.Message);
            }
        }


    }
}
