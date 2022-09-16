using CoffeeManagement.BLL;
using CoffeeManagement.Common.Req;
using CoffeeManagement.Common.Rsp;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductSvc productSvc;

        public ProductController()
        {
            productSvc = new ProductSvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult GetProductById([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = productSvc.Read(simpleReq.Id);
            return Ok(res);
        }

        [HttpPost("get-all")]
        public IActionResult GetAllProduct()
        {
            var res = new SingleRsp();
            res = productSvc.GetAll();
            return Ok(res);
        }

        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromBody] ProductReq productReq)
        {
            var res = new SingleRsp();
            res = productSvc.CreateProduct(productReq);
            return Ok(res);
        }

        [HttpPost("search-product")]
        public IActionResult SearchProduct([FromBody] SearchProductReq searchProductReq)
        {
            var res = new SingleRsp();
            res = productSvc.SearchProduct(searchProductReq);
            return Ok(res);
        }

        [HttpPost("update-product")]
        public IActionResult UpdateProduct([FromBody] UpdateProductReq product)
        {
            var res = new SingleRsp();
            res = productSvc.Update(product);
            return Ok(res);
        }

        [HttpPost("delete-product")]
        public IActionResult DeleteProduct([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = productSvc.DeleteProduct(simpleReq.Id);
            return Ok(res);
        }
    }
}