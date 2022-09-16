using CoffeeManagement.Common.BLL;
using CoffeeManagement.Common.Req;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL;
using CoffeeManagement.DAL.Models;

namespace CoffeeManagement.BLL
{
    public class CategorySvc : GenericSvc<CategoryRep, Category>
    {
        #region -- Overrides --

        /// <summary>
        /// Read category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _repository.Read(id);
            res.Data = m;

            return res;
        }

        /// <summary>
        /// Update category
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public override SingleRsp Update(Category m)
        {
            var res = new SingleRsp();

            var m1 = m.CategoryId > 0 ? _repository.Read(m.CategoryId) : _repository.Read(m.CategoryName);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }

        /// <summary>
        /// Create category by model
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public override SingleRsp Create(Category m)
        {
            return _repository.CreateCategory(m);
        }

        #endregion -- Overrides --

        #region -- Methods --

        public CategorySvc()
        { }

        /// <summary>
        /// Create a new category by simple request
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public SingleRsp Create(SimpleReq req)
        {
            var model = _repository.Read(req.Keyword);
            if (model == null)
            {
                var res = new SingleRsp();
                model = new Category();
                model.CategoryName = req.Keyword;
                res = _repository.CreateCategory(model);
                res.Data = model;
                return res;
            }
            return null;
        }

        #endregion -- Methods --
    }
}