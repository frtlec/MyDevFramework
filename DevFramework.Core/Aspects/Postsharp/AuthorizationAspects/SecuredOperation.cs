using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.Postsharp.AuthorizationAspects
{
    [Serializable]
    public class SecuredOperation:OnMethodBoundaryAspect
    {
        public string Roles { get; set; }
        public override void OnEntry(MethodExecutionArgs args)
        {

            string[] roles = Roles.Split(',');
            bool isAuth = false;
            foreach (var item in roles)
            {
                if (System.Threading.Thread.CurrentPrincipal.IsInRole(item))
                {
                    isAuth = true;
                }
            }

            if (isAuth==false)
            {
                throw new SecurityException("You are not authorized!");
            }
        }
    }
}
