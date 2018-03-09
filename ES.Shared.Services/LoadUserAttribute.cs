using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ES.Shared.Services
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class LoadUserAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            if (filterContext != null)
            {
                if (filterContext.Request.Properties["UserSession"] != null)
                {
                    var user = filterContext.Request.Properties["UserSession"] as UserSession;                    
                    filterContext.ActionContext.Request.Properties["UserSession"] = user;
                }

                //if (HttpContext.Current.Session[ConstantValues.UserSession] == null)
                //{
                //    HttpContext.Current.Session.Clear();
                //    HttpContext.Current.Session.Abandon();
                //    filterContext.Result = new RedirectResult("~/Account/Home");
                //    return;
                //}

                base.OnActionExecuted(filterContext);
            }
        }

        public override void OnActionExecuting(HttpActionContext filterContext)
        {

        }
    }
}