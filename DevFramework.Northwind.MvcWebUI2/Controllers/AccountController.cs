using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using DevFramework.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI2.Controllers
{
    public class AccountController : Controller
    {
        private IUsersService _usersService;
        public AccountController(IUsersService usersService)
        {
            _usersService = usersService;
        }




        // GET: Account
        public string Login(string userName,string password)
        {

            var user = _usersService.GetByUserNameAndPassword(userName, password);
            if (user!=null)
            {
                AuthenticationHelper.CreateAuthCookie(
                new Guid(),
                user.UserName,
                user.Email,
                DateTime.Now.AddDays(15),
                _usersService.GetUserRoles(user).Select(f=>f.RoleName).ToArray(),
                false,
                user.FirstName,
                user.LastName);
                return "User is authenticated!";
            }
            return "User is not authenticated!";
        }
    }
}