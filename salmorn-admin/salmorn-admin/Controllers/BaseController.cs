using salmorn_admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace salmorn_admin.Controllers
{
    public class BaseController : Controller
    {
        protected virtual new UserModel User
        {
            get { return HttpContext.User as UserModel; }
        }

        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if (!filterContext.HttpContext.Request.IsAuthenticated)
        //    {
        //        filterContext.HttpContext.Response.StatusCode = 403;
        //        filterContext.Result = new JsonResult
        //        {
        //            Data = "You are not authorized to perform the action",
        //            JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //        };
        //    }
        //    else
        //        base.OnActionExecuting(filterContext);

        //    //Logger.Info(string.Format("{0}, {1}, {2}, {3}",
        //    //    filterContext.RouteData.GetRequiredString("controller"),
        //    //    filterContext.RouteData.GetRequiredString("action"),
        //    //    CurrentUserid(),
        //    //    filterContext.HttpContext.Request.UserHostAddress));
        //}
    }
}