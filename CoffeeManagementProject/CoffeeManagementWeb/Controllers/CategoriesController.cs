using CoffeeManagement.BLL;
using CoffeeManagement.Common.Req;
using CoffeeManagement.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoffeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategorySvc categorySvc;

        public CategoriesController()
        {
            categorySvc = new CategorySvc();
        }

        // GET: api/Categories/{id}
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest();
                }

                var res = new SingleRsp();
                res = categorySvc.Read(id);
                if (res == null)
                {
                    return NotFound();
                }
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // GET: api/Categories/
        [HttpGet]
        public IActionResult GetCategories()
        {
            var res = new SingleRsp();
            res.Data = categorySvc.All;
            return Ok(res);
        }

        // POST: api/Categories/Create
        [HttpPost("Create")]
        public IActionResult CreateCategory([FromBody] SimpleReq req)
        {
            try
            {
                var res = new SingleRsp();
                res = categorySvc.Create(req);
                if (res == null)
                {
                    return Content($"Category with Name = {req.Keyword} exists");
                }
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}