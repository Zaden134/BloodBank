using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Gửi thông tin người dùng qua ViewBag cho layout/header
            ViewBag.UserName = Session["UserName"];
            base.OnActionExecuting(filterContext);
        }
    }
}