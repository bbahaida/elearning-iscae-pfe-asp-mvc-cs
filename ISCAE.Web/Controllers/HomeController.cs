using ISCAE.Business.Services;
using ISCAE.Data;
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
        private INotificationService _notificationService;
        private ISpecialiteService _specialiteService;
        private IProfesseurService _professeurService;
        private IProfesseurSpecialiteService _professeurSpecialiteService;
        public HomeController(IEtudiantService etudiantService, INotificationService notificationService,
                ISpecialiteService specialiteService, IProfesseurService professeurService, IProfesseurSpecialiteService professeurSpecialiteService)
        {
            _etudiantService = etudiantService;
            _notificationService = notificationService;
            _specialiteService = specialiteService;
            _professeurService = professeurService;
            _professeurSpecialiteService = professeurSpecialiteService;
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
                // Notifications
                List<Notification> notifications = _notificationService.GetUnreadNotifications(user.EtudiantId).ToList();
                int notificationCount = notifications.Count();
                Session["notifications"] = notifications;
                Session["notificationCount"] = notificationCount;
                Session["specialite"] = _specialiteService.Get(user.SpecialiteId).Designation;
                return RedirectToAction("Index", "Etudiant");
            }

            return View("Index");
        }
        public ActionResult Avis()
        {
            return View();
        }
        public ActionResult Formations()
        {
            return View();
        }
        public ActionResult Etudiants()
        {
            return View();
        }
        public ActionResult Professeurs()
        {
            ViewBag.Professeurs = _professeurService.GetActiveUsers().ToList();
            ViewBag.Specialites = _specialiteService.GetAll().ToList();
            return View(_professeurSpecialiteService.GetAll());
        }
    }
}