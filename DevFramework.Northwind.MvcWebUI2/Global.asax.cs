﻿using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using DevFramework.Core.Utilities.Mvc.Infrastructure;
using DevFramework.Northwind.Business.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace DevFramework.Northwind.MvcWebUI2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));
        }
        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;

            base.Init();
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                {
                    return;
                }
                var encTicket = authCookie.Value;
                if (String.IsNullOrEmpty(encTicket))
                {
                    return;
                }

                var ticket = FormsAuthentication.Decrypt(encTicket);
                var securityUtlities = new SecurityUtilities();
                var identity = securityUtlities.FormAuthTicketToIdentity(ticket);
                var principal = new GenericPrincipal(identity, identity.Roles);
                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            catch (Exception)
            {
            }
     
        }
    }
}
