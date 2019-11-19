using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pesagem_Industrial.Util
{
    public class SessionADM : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            Controller controller = filterContext.Controller as Controller;

            //string usuario = session["UserID"].ToString();
            string perfil = session["Perfil"].ToString();

            if (controller != null)
            {
                if (session != null && session["Perfil"].ToString() != "Administrador")
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary { { "controller", "Usuarios" }, { "Usuarios", "Login" } });
                }
            }


            base.OnActionExecuted(filterContext);
        }
    }
}