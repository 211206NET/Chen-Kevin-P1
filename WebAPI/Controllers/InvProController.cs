using Microsoft.AspNetCore.Mvc;
using StoreModels;
using BL;
using CustomExceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvProController : ControllerBase
    {

        private IBL _bl;
        public InvProController(IBL bl)
        {
            _bl = bl;
        }


        // GET: api/<InvProController>
        [HttpGet("Get all Product info")]
        public List<Product> Get()
        {
            return _bl.GetAllProduct();
        }



        //POST api/<InvProController>
        [HttpPost("This is where you place your order as customer")]
        public ActionResult Post(int customerId, int storeId, int total, string times )
        {
            Order cur_order = new Order();
            cur_order.CustomerId = customerId;
            cur_order.OrderDate = times;
            cur_order.StoreId = storeId;
            cur_order.Total = total;

           int orderid = _bl.AddOrder(customerId, cur_order);
           return Ok($"Your order number/ID is {orderid}"); ; 
        }


    }
}
