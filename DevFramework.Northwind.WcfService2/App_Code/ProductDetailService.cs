using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.DependencyResolvers.Ninject;
using DevFramework.Northwind.Business.ServiceContracts.WCF;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevFramework.Northwind.WcfService2.App_Code
{
    public class ProductDetailService : IProductDetailService
    {

        IProductService _productService = InstanceFactory.GetInstance<IProductService>();
        public ProductDetailService()
        {
        }

        public List<Product> GetAll()
        {
            return _productService.GetAll();
        }
    }
}