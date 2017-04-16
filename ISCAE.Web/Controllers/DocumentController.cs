using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISCAE.Web.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Document
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Officiel()
        {
            return View();
        }
        public ActionResult NonOfficiel()
        {
            return View();
        }
    }
}