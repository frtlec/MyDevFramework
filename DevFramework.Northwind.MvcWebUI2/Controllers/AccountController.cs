using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI2.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public string Index()
        {

            AuthenticationHelper.CreateAuthCookie(
                 new Guid(),
                 "engindemirog",
                 "xx@gmail.com",
                 DateTime.Now.AddDays(15),
                 new[] { "Student"},
                 false,
                 "zafer",
                 "kırık");
            return "User is authenticated!";
        }
    }
}