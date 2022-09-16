using CoffeeManagement.Common.DAL;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Linq;

namespace CoffeeManagement.DAL
{
    public class CategoryRep : GenericRep<CoffeeDBContext, Category>
    {
        #region -- Overrides --

        /// <summary>
        /// Read category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category</returns>
        public override Category Read(int id)
        {
            return All.FirstOrDefault(category => category.CategoryId == id);
        }

        /// <summary>
        /// Read category by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Category</returns>
        public override Category Read(string name)
        {
            return All.FirstOrDefault(category => category.CategoryName == name);
        }

        #endregion -- Overrides --

        #region -- Methods --

        /// <summary>
        /// Create a new category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public SingleRsp CreateCategory(Category category)
        {
            var res = new SingleRsp();
            using (var dBContext = new CoffeeDBContext())
            {
                using (var tran = dBContext.Database.BeginTransaction())
                {
                    try
                    {
                        var t = dBContext.Categories.Update(category);
                        dBContext.SaveChanges();
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

        #endregion -- Methods --
    }
}