using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace DevFramework.Northwind.Business.ServiceContracts.WCF
{
    [ServiceContract] //wcf için gerekli
    public interface IProductDetailService
    {
        [OperationContract]//her bir methodun operasyon kontratı
        List<Product> GetAll();
    }
}
