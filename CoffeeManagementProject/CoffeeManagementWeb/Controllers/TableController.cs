using CoffeeManagement.BLL;
using CoffeeManagement.Common.Req;
using CoffeeManagement.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private TableSvc tableSvc;

        public TableController()
        {
            tableSvc = new TableSvc();
        }

        [HttpPost("create_table")]
        public IActionResult CreateTable([FromBody] TableReq tableReq)
        {
            var res = new SingleRsp();
            res = tableSvc.CreateTable(tableReq);
            return Ok(res);
        }

        [HttpPost("update_table")]
        public IActionResult UpdateTable([FromBody] TableReq tableReq)
        {
            var res = new SingleRsp();
            res = tableSvc.UpdateTable(tableReq);
            return Ok(res);
        }

        [HttpPost("remove_table")]
        public IActionResult RemoveTable([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = tableSvc.RemoveTable(simpleReq.Id);
            return Ok(res);
        }

        [HttpPost("search_table_by_capacity")]
        public IActionResult SearchTable([FromBody] SearchTableReq s)
        {
            var res = new SingleRsp();
            res = tableSvc.SearchTable(s);
            return Ok(res);
        }

        [HttpGet("list_empty_table")]
        public IActionResult ListEmptyTable()
        {
            var res = new SingleRsp();
            res = tableSvc.ListEmptyTable();
            return Ok(res);
        }
    }
}