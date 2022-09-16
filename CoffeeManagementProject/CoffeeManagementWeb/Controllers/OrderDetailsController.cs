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
    public class OrderDetailsController : ControllerBase
    {
        private readonly OrderDetailSvc orderDetailSvc;

        public OrderDetailsController()
        {
            orderDetailSvc = new OrderDetailSvc();
        }

        // GET: api/OrderDetails
        [HttpGet]
        public IActionResult GetOrderDetails()
        {
            var res = new SingleRsp();
            res.Data = orderDetailSvc.All;
            return Ok(res);
        }

        // GET: api/OrderDetails/{id}
        [HttpGet("{id}")]
        public IActionResult GetOrderDetail(int id)
        {
            if (id < 0)
            {
                return BadRequest("Order Id invalid");
            }

            var res = new SingleRsp();
            res = orderDetailSvc.Read(id);

            if (res.Data == null)
            {
                return NotFound($"Order Detail with Order Id = {id} not found");
            }

            return Ok(res);
        }

        // PUT: api/OrderDetails/Update/{id}
        [HttpPut("Update/{id}")]
        public IActionResult UpdateOrderDetail(int id, [FromBody] OrderDetailReq req)
        {
            try
            {
                var res = new SingleRsp();
                req.OrderId = id;
                res = orderDetailSvc.Update(req);
                if (res == null)
                    return NotFound($"Order detail with Id = {id} and Product Id = {req.ProductId} not found");

                res.SetMessage("Update successfull");
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        // POST: api/OrderDetails
        [HttpPost()]
        public IActionResult CreateOrderDetail([FromBody] OrderDetailReq req)
        {
            var res = new SingleRsp();
            res = orderDetailSvc.Create(req);
            return CreatedAtAction("GetOrderDetail", new { id = req.OrderId }, req);
        }

        // DELETE: api/OrderDetails/Delete/{id}
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteOrderDetail(int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest("Order Id invalid");
                var res = new SingleRsp();
                res = orderDetailSvc.Delete(id);

                if (res == null)
                {
                    return NotFound($"Order detail with Order Id = {id} not found");
                }

                return Content($"Order detail with Order Id = {id} deleted successfull");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }

        [HttpPost("revenue_by_productId_on_month_year")]
        public IActionResult Revenue(RevenueReq r)
        {
            var res = new SingleRsp();
            res = orderDetailSvc.Revenue(r);
            return Ok(res);
        }
    }
}