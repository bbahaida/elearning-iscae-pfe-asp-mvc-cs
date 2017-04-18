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
        public HomeController(IEtudiantService etudiantService, INotificationService notificationService)
        {
            _etudiantService = etudiantService;
            _notificationService = notificationService;
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
                return RedirectToAction("Index", "Etudiant");
            }

            return View("Index");
        }
    }
}