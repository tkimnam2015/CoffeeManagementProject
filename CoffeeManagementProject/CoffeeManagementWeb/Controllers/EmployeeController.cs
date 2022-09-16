using CoffeeManagement.BLL;
using CoffeeManagement.Common.Req;
using CoffeeManagement.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeSvc employeeSvc;

        public EmployeeController()
        {
            employeeSvc = new EmployeeSvc();
        }

        [HttpGet("get-all")]
        public IActionResult GetEmployeesAll()
        {
            var res = new SingleRsp();
            res.Data = employeeSvc.All;
            return Ok(res);
        }

        [HttpPost("get-by-id")]
        public IActionResult GetEmployeeById(int id)
        {
            var res = new SingleRsp();
            res.Data = employeeSvc.Read(id);
            return Ok(res);
        }

        [HttpPut("update-employee")]
        public IActionResult UpdateEmployee([FromBody] UpdateEmployeeReq updateEmployee)
        {
            var res = new SingleRsp();
            res = employeeSvc.UpdateEmployee(updateEmployee);
            return Ok(res);
        }
    }
}
