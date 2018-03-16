using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISCAE.Web.Controllers
{
    
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Http404()
        {
            if(Session["user"] != null)
            {
                return View("Session404");
            }
            return View("Guest404");
        }
        public ActionResult Http500()
        {
            if (Session["user"] != null)
            {
                return View("Session500");
            }
            return View("Guest500");
        }
    }
}