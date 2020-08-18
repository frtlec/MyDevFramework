using DevFramework.Northwind.Business.Concrete.Managers;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Mock<IProductDal> mock = new Mock<IProductDal>();
            //ProductManager productManager = new ProductManager(mock.Object);
            //productManager.Add(new Product());
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}