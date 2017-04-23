using ISCAE.Business.Services;
using ISCAE.Data;
using ISCAE.Web.Filters;
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
        private IAdministrateurService _administrateurService;
        public HomeController(IEtudiantService etudiantService, INotificationService notificationService,
                ISpecialiteService specialiteService, IProfesseurService professeurService, 
                IAdministrateurService administrateurService, IProfesseurSpecialiteService professeurSpecialiteService)
        {
            _administrateurService = administrateurService;
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
            Administrateur admin = null;
            if (login.Equals("admin") && password.Equals("admin"))
            {
                admin = new Administrateur
                {
                    AdministrateurId = 1,
                    Email = "admin@iscae.mr",
                    Login = "admin",
                    Password = "admin",
                    Nom = "Administrateur",
                    isActive = 1,
                    Telephone = "34565656"

                };
            }
            
            
            if(admin != null)
            {
                Session["user"] = admin;
                // Notifications
                List<Notification> notifications = _notificationService.GetUnreadNotifications(admin.AdministrateurId).ToList();
                int notificationCount = notifications.Count();
                Session["notifications"] = notifications;
                Session["notificationCount"] = notificationCount;
             
                return RedirectToAction("index","Administrateur");
            }
            else
            {
                var prof = _professeurService.GetUserByAuth(login, password);
                if(prof != null)
                {
                    Session["user"] = prof;
                    // Notifications
                    List<Notification> notifications = _notificationService.GetUnreadNotifications(prof.ProfesseurId).ToList();
                    int notificationCount = notifications.Count();
                    Session["notifications"] = notifications;
                    Session["notificationCount"] = notificationCount;
                    return RedirectToAction("Index", "Professeur");
                }
                else
                {
                    var etudiant = _etudiantService.GetUserByAuth(login,password);
                    if (etudiant != null)
                    {
                        Session["user"] = etudiant;
                        List<Notification> notifications = _notificationService.GetUnreadNotifications(etudiant.EtudiantId).ToList();
                        int notificationCount = notifications.Count();
                        Session["notifications"] = notifications;
                        Session["notificationCount"] = notificationCount;
                        Session["specialite"] = _specialiteService.Get(etudiant.SpecialiteId).Designation;
                        return RedirectToAction("Index", "Etudiant");
                    }
                }
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
        [SessionFilter()]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }
}