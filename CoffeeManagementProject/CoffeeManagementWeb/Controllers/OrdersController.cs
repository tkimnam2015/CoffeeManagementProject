using CoffeeManagement.BLL;
using CoffeeManagement.Common.Req;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoffeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderSvc orderSvc;

        public OrdersController()
        {
            orderSvc = new OrderSvc();
        }

        // GET: api/Orders
        [HttpGet]
        public IActionResult GetOrders()
        {
            try
            {
                var res = new SingleRsp();
                res.Data = orderSvc.All;
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // GET: api/Orders/{id}
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest("Order Id invalid");

                var res = new SingleRsp();
                res = orderSvc.Read(id);

                if (res == null)
                    return NotFound($"Order with Id = {id} not found");
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }

        // GET: api/Orders/Search/{customerName}
        [HttpGet("Search/{customerName}")]
        public IActionResult GetOrders(string customerName)
        {
            try
            {
                if (customerName == null)
                    return BadRequest();

                var res = orderSvc.Search(customerName);
                if (res == null)
                    return NotFound($"Order with Customer Name = {customerName} not found");
                return Ok(new SingleRsp());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Orders/Update/{id}
        [HttpPut("Update/{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] OrderReq orderReq)
        {
            if (id != orderReq.OrderId)
            {
                return BadRequest("Order Id mismatch");
            }

            var res = new SingleRsp();
            res = orderSvc.Update(orderReq);
            if (res == null)
                return NotFound($"Order with Id = {id} not found");
            return Ok(res);
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderReq orderReq)
        {
            try
            {
                var res = new SingleRsp();
                res = orderSvc.Create(orderReq);
                if (res == null)
                {
                    return NoContent();
                }
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }

        [HttpPut("Payment/{id}")]
        public IActionResult PaymentOrder(int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest("Order Id invalid");

                var res = new SingleRsp();
                res = orderSvc.Payment(id);
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

        // DELETE: api/Orders/Delete/{id}
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest("Order Id invalid");
                var res = new SingleRsp();
                res = orderSvc.Delete(id);

                if (res == null)
                {
                    return NotFound($"Order with Id = {id} not found");
                }

                return Content($"Order with Id = {id} deleted successfull");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }

        [HttpPost("stats-by-year")]
        public IActionResult GetProductById([FromBody] StatsYearReq year)
        {
            var res = new SingleRsp();
            res = orderSvc.StatsByYear(year.Year);
            return Ok(res);
        }
    }
}