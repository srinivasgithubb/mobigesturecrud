using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUD_JavaScript_JQuery_WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet()]
        public IHttpActionResult Get()
        {
            IHttpActionResult ret = null;
            List<Product> list = new List<Product>();
            list = CreateMockData();
            if (list.Count > 0)
            {
                ret = Ok(list);
            }
            else
            {
                ret = NotFound();
            }
            return ret;
        }

        [HttpGet()]
        public IHttpActionResult Get(int id)
        {
            IHttpActionResult ret;
            List<Product> list = new List<Product>();
            Product prod = new Product();

            list = CreateMockData();
            prod = list.Find(p => p.ProductId == id);
            if (prod == null)
            {
                ret = NotFound();
            }
            else
            {
                ret = Ok(prod);
            }

            return ret;
        }

        [HttpPost()]
        public IHttpActionResult Post(Product product)
        {
            IHttpActionResult ret = null;
            if (Add(product))
            {
                ret = Created<Product>(Request.RequestUri + product.ProductId.ToString(), product);
            }
            else
            {
                ret = NotFound();
            }
            return ret;
        }

        private bool Add(Product product)
        {
            int newId = 0;
            List<Product> list = new List<Product>();
            list = CreateMockData();

            newId = list.Max(p => p.ProductId);
            newId++;
            product.ProductId = newId;
            list.Add(product);
            return true;
        }

        [HttpPut()]
        public IHttpActionResult Put(int id, Product product)
        {
            IHttpActionResult ret = null;
            if (Update(product))
            {
                ret = Ok(product);
            }
            else
            {
                ret = NotFound();
            }
            return ret;
        }

        private bool Update(Product product)
        {
            return true;
        }

        [HttpDelete()]
        public IHttpActionResult Delete(int id)
        {
            IHttpActionResult ret = null;
            if (DeleteProduct(id))
            {
                ret = Ok(true);
            }
            else
            {
                ret = NotFound();
            }
            return ret;
        }

        private bool DeleteProduct(int id)
        {
            return true;
        }

        private List<Product> CreateMockData()
        {
            List<Product> ret = new List<Product>();
            ret.Add(new Product()
            {
                ProductId = 1,
                ProductName = "Google",
                Email = "Google@123.com",
                Url = "https://www.google.com/"
            });

            ret.Add(new Product()
            {
                ProductId = 2,
                ProductName = "Bing",
                Email = "Bing@123.com",
                Url = "https://www.bing.com/"
            });

            ret.Add(new Product()
            {
                ProductId = 3,
                ProductName = "Duck Duck Go",
                Email = "Duckduck@123.com",
                Url = "https://duckduckgo.com/"
            });

            ret.Add(new Product()
            {
                ProductId = 4,
                ProductName = "Microsoft",
                Email = "Microsoft@123.com",
                Url = "https://Microsoft.com/"
            });

            return ret;
        }
    }
}