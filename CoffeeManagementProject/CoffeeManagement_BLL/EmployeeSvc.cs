using CoffeeManagement.Common.BLL;
using CoffeeManagement.Common.Req;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL;
using CoffeeManagement.DAL.Models;
using System;
using System.Linq;

namespace CoffeeManagement.BLL
{
    public class EmployeeSvc : GenericSvc<EmployeeRep, Employee>
    {
        private EmployeeRep employeeRep;

        public EmployeeSvc()
        {
            employeeRep = new EmployeeRep();
        }

        public SingleRsp UpdateEmployee(UpdateEmployeeReq updateEmployee)
        {
            var res = new SingleRsp();
            var e = _repository.Read(updateEmployee.EmployeeId); //lấy thông tin của đối tượng cần update, xong chỉ thay đổi những thuộc tính mình cần đổi
            e.Identification = updateEmployee.Identification;
            res = employeeRep.UpdateEmployee(e);
            return res;
        }
    }
}
