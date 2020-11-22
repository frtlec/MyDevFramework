﻿using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.DependencyResolvers.Ninject;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace DevFramework.Northwind.WebApi6.MessageHandlers
{
    public class AuthenticationHandler:DelegatingHandler
    {

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = request.Headers.GetValues("Authorization").FirstOrDefault();
                if (token!=null)
                {
                    byte[] data = Convert.FromBase64String(token);
                    string decodedString = Encoding.UTF8.GetString(data);
                    string[] tokenValues = decodedString.Split(':');

                    IUsersService usersService = InstanceFactory.GetInstance<IUsersService>();
                    

                    User user= usersService.GetByUserNameAndPassword(tokenValues[0], tokenValues[1]);
                    if (user!= null)
                    {
                        IPrincipal principal = new GenericPrincipal(
                            new GenericIdentity(tokenValues[0]), usersService.GetUserRoles(user).Select(f=>f.RoleName).ToArray());
                        Thread.CurrentPrincipal = principal;
                        HttpContext.Current.User = principal;
                    }
                }
            }
            catch 
            {

               
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}