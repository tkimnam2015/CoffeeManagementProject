using CoffeeManagement.Common.BLL;
using CoffeeManagement.Common.Req;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL;
using CoffeeManagement.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeManagement.BLL
{
    public class ProductSvc : GenericSvc<ProductRep, Product>
    {
        private ProductRep productRep;

        public ProductSvc()
        {
            productRep = new ProductRep();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _repository.Read(id);

            return res;
        }

        public SingleRsp DeleteProduct(int id)
        {
            var res = new SingleRsp();
            res.Data = _repository.Remove(id);

            return res;
        }

        public SingleRsp Update(UpdateProductReq m)
        {
            var res = new SingleRsp();

            var m1 = m.ProductId > 0 ? productRep.Read(m.ProductId) : _repository.Read(m.ProductName);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                Product product = new Product();
                product.ProductId = m.ProductId;
                product.ProductName = m.ProductName;
                product.Price = m.Price;
                product.CategoryId = m.CategoryId;

                res = productRep.UpdateProduct(product);

                res.Data = m;
            }

            return res;
        }

        public SingleRsp CreateProduct(ProductReq productReq)
        {
            var res = new SingleRsp();
            Product product = new Product();
            product.ProductName = productReq.ProductName;
            product.Price = productReq.Price;
            product.CategoryId = productReq.CategoryId;

            res = productRep.CreateProduct(product);

            return res;
        }

        public SingleRsp GetAll()
        {
            var res = new SingleRsp();

            res.Data = productRep.GetAllProduct();

            return res;
        }

        public SingleRsp UpdateProduct(ProductReq productReq)
        {
            var res = new SingleRsp();
            Product product = new Product();
            product.ProductName = productReq.ProductName;
            product.Price = productReq.Price;
            product.CategoryId = productReq.CategoryId;

            res = productRep.UpdateProduct(product);

            return res;
        }

        public SingleRsp SearchProduct(SearchProductReq searchProductReq)
        {
            var res = new SingleRsp();
            //Lay dssp theo tu khoa
            var products = productRep.SearchProduct(searchProductReq.Keyword);
            //xu ly phan trang
            int pCount, totalPage, offset;
            offset = searchProductReq.Size * (searchProductReq.Page - 1);
            pCount = products.Count;
            totalPage = (pCount % searchProductReq.Size) == 0 ? pCount / searchProductReq.Size : (pCount / searchProductReq.Size) + 1;
            var obj = new
            {
                Data = products.Skip(offset).Take(searchProductReq.Size).ToList(),
                Page = searchProductReq.Page,
                Size = searchProductReq.Size
            };
            res.Data = obj;

            return res;
        }

        /// <summary>
        /// Read product by name
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Single Response</returns>
        public override SingleRsp Read(string code)
        {
            var res = new SingleRsp();
            res.Data = _repository.Read(code);
            return res;
        }
    }
}