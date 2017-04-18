using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISCAE.Web.Controllers
{
    public class EtudiantController : Controller
    {
        // GET: Etudiant

        public ActionResult Index()
        {
            if (Session["user"] == null)
                RedirectToAction("Index","Home");
            Etudiant user = (Etudiant)Session["user"];
            return View(user);
        }
    }
}