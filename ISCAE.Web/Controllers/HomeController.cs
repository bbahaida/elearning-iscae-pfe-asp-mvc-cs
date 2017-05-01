using ISCAE.Business.Services;
using ISCAE.Data;
using ISCAE.Web.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ISCAE.Web.Controllers
{
    public class HomeController : Controller
    {

        #region Dependencies

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
        #endregion Dependencies

        #region Index
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.session = false;
            if(Session["user"] != null)
                ViewBag.session = true;
            return View();
        }
        #endregion Index

        #region Membre
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string login, string password)
        {
            Administrateur admin = _administrateurService.GetUserByAuth(login,password);
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
        [SessionFilter()]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Register()
        {
            ViewBag.error = false;
            ViewBag.done = false;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(string nni, string matricule, string login, string tel, string email, string password, string repassword)
        {
            ViewBag.error = false;
            ViewBag.done = false;
            if (nni == null || nni.Equals("") || matricule == null
                || matricule.Equals("") || email == null || email.Equals("")
                || password == null || password.Equals("") || repassword.Equals("")
                || !password.Equals(repassword)
                )
            {
                ViewBag.error = true;
                return View();
            }
            Etudiant etudiant = _etudiantService.GetUserByNNI(nni);
            if (etudiant.Matricule.ToLower().Equals(matricule.ToLower()))
            {
                if (etudiant.isActive == 0 && (etudiant.Password == null || etudiant.Password.Equals("")))
                {
                    etudiant.Email = email;
                    etudiant.Login = login;
                    etudiant.Password = password;
                    etudiant.isActive = 1;
                    etudiant.ProfilePath = "~/Resources/Profiles/avatar.png";
                    _etudiantService.Edit(etudiant);
                    ViewBag.done = true;
                    return View();

                }
            }
            ViewBag.error = true;
            return View();
        }
        #endregion Membre

        public ActionResult Directeur()
        {
            return View();
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