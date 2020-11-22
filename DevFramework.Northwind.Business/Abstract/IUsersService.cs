using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFramework.Northwind.Business.Abstract
{
    public interface IUsersService
    {

        User GetByUserNameAndPassword(string username, string pass);
        List<UserRoleItem> GetUserRoles(User user);
    }
}
