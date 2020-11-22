using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.Concrete.Managers;
using DevFramework.Northwind.Business.DependencyResolvers.Ninject;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevFramework.Northwind.WcfService2.App_Code
{
    public class ProductService:IProductService
    {
        private IProductService _productService = InstanceFactory.GetInstance<IProductService>();
        public Product Add(Product product)
        {
            return _productService.Add(product);
        }

        public List<Product> GetAll()
        {
            return _productService.GetAll();
        }

        public Product GetById(int id)
        {
            return _productService.GetById(id);
        }

        public void TransactionalOperation(Product product1, Product product2)
        { 
            
            _productService.TransactionalOperation(product1, product2);
        }

        public Product Update(Product product)
        {
            return _productService.Update(product);
        }
    }
}