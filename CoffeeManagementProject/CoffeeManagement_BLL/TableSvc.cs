using CoffeeManagement.Common.BLL;
using CoffeeManagement.Common.Req;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL;
using CoffeeManagement.DAL.Models;
using System.Linq;

namespace CoffeeManagement.BLL
{
    public class TableSvc : GenericSvc<TableRep, Table>
    {
        private TableRep tableRep;

        public TableSvc()
        {
            tableRep = new TableRep();
        }

        public SingleRsp CreateTable(TableReq table)
        {
            var res = new SingleRsp();
            Table t = new Table();
            t.TableId = table.TableId;
            t.TableName = table.TableName;
            t.Capacity = table.Capacity;
            t.Active = table.Active;
            res = tableRep.CreateTable(t);
            return res;
        }

        public SingleRsp UpdateTable(TableReq table)
        {
            var res = new SingleRsp();
            Table t = new Table();
            t.TableId = table.TableId;
            t.TableName = table.TableName;
            t.Capacity = table.Capacity;
            t.Active = table.Active;
            res = tableRep.UpdateTable(t);
            return res;
        }

        public SingleRsp RemoveTable(int tableId)
        {
            var res = new SingleRsp();
            res = tableRep.RemoveTable(tableId);
            return res;
        }

        public SingleRsp SearchTable(SearchTableReq s)
        {
            var res = new SingleRsp();
            var tables = tableRep.SearchTable(s.Capacity);
            int tCount, totalPages, offSet;
            offSet = s.Size * (s.Page - 1);
            tCount = tables.Count;
            totalPages = (tCount % s.Size) == 0 ? tCount / s.Size : 1 + (tCount / s.Size);
            var t = new
            {
                Data = tables.Skip(offSet).Take(s.Size).ToList(),
                Page = s.Page,
                Size = s.Size
            };
            res.Data = t;
            return res;
        }

        public SingleRsp ListEmptyTable()
        {
            var res = new SingleRsp();
            res.Data = tableRep.ListEmptyTable();
            return res;
        }

        #region -- Overrides --

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _repository.Read(id);
            return res;
        }

        #endregion -- Overrides --
    }
}