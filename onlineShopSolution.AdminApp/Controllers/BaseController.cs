using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using onlineShopSolution.Utilities.Constants;

namespace onlineShopSolution.AdminApp.Controllers
{
    //base check session cho tat ca dang nhap hoac action

    public class BaseController : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var sessions = context.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            if (sessions == null)
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
            base.OnActionExecuted(context);
        }

    }
}