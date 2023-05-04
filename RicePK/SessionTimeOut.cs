using RicePK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace RicePK
{
    public class SessionTimeOutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (HttpContext.Current.Session["UserType"] == null)
            {
                filterContext.Result = new RedirectResult("/DailyRateList/Index");
            }

        }
    }
}