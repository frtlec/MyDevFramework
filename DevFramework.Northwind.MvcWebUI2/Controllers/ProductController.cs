using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Northwind.MvcWebUI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI2.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Product
        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }
        public string Add()
        {
            _productService.Add(new Product
            {

                CategoryId = 1,
                ProductName = "Gsm",
                QuantityPerUnit = "1",
                UnitPrice = 21,
                Discontinued=true
            });
            var item = _productService.GetById(10);
            item.ProductName = "qqqqxqqfqwf";
            _productService.Update(item);

            return "Added";

        }
        public string AddUpdate()
        {
            _productService.TransactionalOperation(new Product
            {

                CategoryId = 1,
                ProductName = "new1",
                QuantityPerUnit = "323",
                UnitPrice = 11,
                Discontinued = true
            }, new Product
            {
                ProductId=2,
                CategoryId = 1,
                ProductName = "update1",
                QuantityPerUnit = "1",
                UnitPrice = 30,
                Discontinued = true
            });
            return "done";

        }
    }
}