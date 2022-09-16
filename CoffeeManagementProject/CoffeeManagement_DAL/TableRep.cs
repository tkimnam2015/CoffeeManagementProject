using CoffeeManagement.Common.DAL;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeManagement.DAL
{
    public class TableRep : GenericRep<CoffeeDBContext, Table>
    {
        public TableRep()
        {
        }

        #region -- Overrides --

        public override Table Read(int id)
        {
            return All.FirstOrDefault(p => p.TableId == id);
        }

        #endregion -- Overrides --

        #region -- Methods --

        public SingleRsp CreateTable(Table table)
        {
            var res = new SingleRsp();
            using (var context = new CoffeeDBContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Tables.Add(table);
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

        public SingleRsp UpdateTable(Table table)
        {
            var res = new SingleRsp();
            using (var context = new CoffeeDBContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Tables.Update(table);
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

        public SingleRsp RemoveTable(int tableId)
        {
            var res = new SingleRsp();
            using (var context = new CoffeeDBContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Tables.FirstOrDefault(c => c.TableId == tableId);
                        context.Remove(t);
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

        public List<Table> SearchTable(int capacity)
        {
            return All.Where(t => t.Capacity == capacity).ToList();
        }

        public List<Table> ListEmptyTable()
        {
            return All.Where(t => t.Active == false).ToList();
        }

        #endregion -- Methods --
    }
}