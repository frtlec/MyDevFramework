using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace DevFramework.Northwind.Business.Abstract
{
    [ServiceContract] //wcf için gerekli
    public interface IProductService
    {
        [OperationContract]//her bir methodun operasyon kontratı
        List<Product> GetAll();
        [OperationContract]
        Product GetById(int id);
        [OperationContract]
        Product Add(Product product);
        [OperationContract]
        Product Update(Product product);
        [OperationContract]
        void TransactionalOperation(Product product1,Product product2);

    }
}
