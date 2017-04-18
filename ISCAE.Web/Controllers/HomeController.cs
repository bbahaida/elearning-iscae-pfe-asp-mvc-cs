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
        private IEtudiantService _etudiantService;

        public HomeController(IEtudiantService etudiantService)
        {
            _etudiantService = etudiantService;
        }
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
            var user = _etudiantService.GetUserByAuth(login,password);
            if(user != null)
            {
                Session["user"] = user;
                return RedirectToAction("Index", "Etudiant");
            }

            return View("Index");
        }
    }
}