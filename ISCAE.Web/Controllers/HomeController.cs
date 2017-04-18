using ISCAE.Business.Services;
using ISCAE.Data;
using ISCAE.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISCAE.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.session = false;
            if(Session["user"] != null)
                ViewBag.session = true;
            return View();
        }
        public ActionResult Directeur()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            IEtudiantService _service = new EtudiantService(new EtudiantRepository(), new SpecialiteRepository());
            var user = _service.GetUserByAuth(login,password);
            if(user != null)
            {
                Session["user"] = user;
                return RedirectToAction("Index", "Etudiant");
            }

            return null;
        }
    }
}