using ISCAE.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISCAE.Web.Controllers
{
    [SessionFilter()]
    public class ProfesseurController : Controller
    {
        // GET: Professeur
        public ActionResult Index()
        {
            return View();
        }
    }
}