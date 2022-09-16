using CoffeeManagement.Common.DAL;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeManagement.DAL
{
    public class ProductRep : GenericRep<CoffeeDBContext, Product>
    {
        public ProductRep()
        {
        }

        public override Product Read(int id)
        {
            var res = All.FirstOrDefault(p => p.ProductId == id);
            return res;
        }

        public List<Product> GetAllProduct()
        {
            return All.Select(p => p).OrderBy(p => p.ProductName).ThenByDescending(p => p.Price).ToList();
        }

        public SingleRsp Remove(int id)
        {
            var res = new SingleRsp();
            var m = base.All.First(i => i.ProductId == id);

            using (var context = new CoffeeDBContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Products.Remove(m);
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

        public SingleRsp CreateProduct(Product product)
        {
            var res = new SingleRsp();
            using (var context = new CoffeeDBContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Products.Add(product);
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

        public SingleRsp UpdateProduct(Product product)
        {
            var res = new SingleRsp();
            using (var context = new CoffeeDBContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Products.Update(product);
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

        public List<Product> SearchProduct(string keyword)
        {
            return All.Where(p => p.ProductName.Contains(keyword)).OrderBy(p => p.ProductName).ThenByDescending(p => p.Price).ToList();
        }

        /// <summary>
        /// Read product by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override Product Read(string name)
        {
            return All.Where(p => p.ProductName.Equals(name)).FirstOrDefault();
        }
    }
}