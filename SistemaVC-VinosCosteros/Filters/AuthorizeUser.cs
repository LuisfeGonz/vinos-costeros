using System;
using System.Web;
using System.Web.Mvc;

namespace SistemaVC_VinosCosteros.Filters
{
    public class AuthorizeUser : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.Session["UsuarioId"] != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Login/AccessDenied");
        }
    }
}