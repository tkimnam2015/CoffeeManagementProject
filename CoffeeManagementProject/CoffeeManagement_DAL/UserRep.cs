using CoffeeManagement.Common.DAL;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeManagement.DAL
{
    public class UserRep : GenericRep<CoffeeDBContext, User>
    {
        public override User Read(int id)
        {
            return All.FirstOrDefault(u => u.UserId==id);
        }

        public override User Read(string code)
        {
            return base.Read(code);
        }

        public SingleRsp CreateUser(User u)
        {
            var res = new SingleRsp();
            using (var context = new CoffeeDBContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Users.Add(u);
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

        public SingleRsp UpdateUser(User u)
        {
            var res = new SingleRsp();
            using (var context = new CoffeeDBContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Users.Update(u);
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
