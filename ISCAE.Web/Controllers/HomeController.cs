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

        private IUtilities _utilities;
        private IEtudiantService _etudiantService;
        private INotificationService _notificationService;
        private ISpecialiteService _specialiteService;
        private IModuleService _moduleService;
        private IProfesseurService _professeurService;
        private IAnnonceService _annonceService;
        private IProfesseurSpecialiteService _professeurSpecialiteService;
        private IAdministrateurService _administrateurService;
        public HomeController(IUtilities utilities, IEtudiantService etudiantService, INotificationService notificationService,
                ISpecialiteService specialiteService, IProfesseurService professeurService, IModuleService moduleService,
                IAdministrateurService administrateurService, IProfesseurSpecialiteService professeurSpecialiteService,
                IAnnonceService annonceService)
        {
            _utilities = utilities;
            _administrateurService = administrateurService;
            _etudiantService = etudiantService;
            _notificationService = notificationService;
            _specialiteService = specialiteService;
            _moduleService = moduleService;
            _professeurService = professeurService;
            _professeurSpecialiteService = professeurSpecialiteService;
            _annonceService = annonceService;
        }
        #endregion Dependencies
        
        #region Index
        // GET: Home
        [UnSessionFilter]
        public ActionResult Index()
        {
            ViewBag.etudiants = _etudiantService.GetAll().Where(o => o.isActive == 1).Count();
            ViewBag.graduates = _etudiantService.GetAll().Where(o => o.isActive == 0 && o.Niveau == 3).Count();
            ViewBag.professeurs = _professeurService.GetAll().Where(o => o.isActive == 1).Count();
            ViewBag.specialites = _specialiteService.GetAll().OrderBy(o=>o.Designation).ToList();
            ViewBag.directeur = _annonceService.GetAll().FirstOrDefault(o=>o.Titre.Equals("directeur"));
            ViewBag.modules = _moduleService.GetAll().Count();
            return View();
        }
        #endregion Index

        #region Membre
        [HttpPost]
        [UnSessionFilter]
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
        [UnSessionFilter]
        public ActionResult Register()
        {
            ViewBag.error = false;
            ViewBag.done = false;
            return View();
        }
        [HttpPost]
        [UnSessionFilter]
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
            if (etudiant != null && etudiant.Matricule.ToLower().Equals(matricule.ToLower()))
            {
                if (etudiant.isActive == 0 && (etudiant.Password == null || etudiant.Password.Equals("")))
                {
                    etudiant.Email = email;
                    etudiant.Login = login;
                    etudiant.Password = _utilities.Hash("iscae"+password);
                    etudiant.isActive = 1;
                    etudiant.ProfilePath = "~/Resources/Profiles/avatar.png";
                    _etudiantService.Edit(etudiant);
                    ViewBag.done = true;
                    return View("Index");

                }
            }
            ViewBag.error = true;
            return View();
        }
        #endregion Membre
        [UnSessionFilter]
        public ActionResult Directeur()
        {
            return View(_annonceService.GetAll().FirstOrDefault(o => o.Titre.Equals("directeur")));
        }
        [UnSessionFilter]
        public ActionResult Avis()
        {
            return View(_annonceService.GetAll().Where(o=>o.Titre != "directeur").OrderByDescending(o=>o.AnnonceId).Take(3).ToList());
        }

        [UnSessionFilter]
        public ActionResult Formations()
        {
            return View();
        }
        [UnSessionFilter]
        public ActionResult Etudiants()
        {
            return View();
        }
        [UnSessionFilter]
        public ActionResult Professeurs()
        {
            return View(_professeurService.GetActiveUsers().ToList());
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}