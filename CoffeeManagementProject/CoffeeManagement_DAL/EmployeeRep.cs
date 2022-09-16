using CoffeeManagement.Common.DAL;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeManagement.DAL
{
    public class EmployeeRep : GenericRep<CoffeeDBContext, Employee>
    {
        public override Employee Read(int id)
        {
            var res = All.FirstOrDefault(e => e.EmployeeId == id);
            return res;
        }

        public override Employee Read(string code)
        {
            return base.Read(code);
        }

        public SingleRsp UpdateEmployee(Employee e)
        {
            var res = new SingleRsp();
            using (var context = new CoffeeDBContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var m = context.Employees.Update(e);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
    }
}
