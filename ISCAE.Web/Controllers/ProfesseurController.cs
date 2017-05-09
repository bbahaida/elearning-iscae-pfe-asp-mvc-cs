using ISCAE.Business.Services;
using ISCAE.Data;
using ISCAE.Web.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISCAE.Web.Controllers
{
    [SessionFilter()]
    [ProfesseurFilter()]
    public class ProfesseurController : Controller
    {
        #region Dependencies

        private IUtilities _utilities;
        private IEtudiantService _etudiantService;
        private IDocumentNonOfficielService _documentNonOfficielService;
        private IDocumentOfficielService _documentOfficielService;
        private IMessageService _messageService;
        private IAnnonceService _annonceService;
        private IProfesseurService _professeurService;
        private INotificationService _notificationService;
        private ISpecialiteService _specialiteService;
        private IModuleService _moduleService;
        private IProfesseurModuleService _professeurModuleService;

        public ProfesseurController(IUtilities utilities, IEtudiantService etudiantService, IDocumentNonOfficielService documentNonOfficielService,
               IDocumentOfficielService documentOfficielService, IMessageService messageService, IModuleService moduleService,
               IAnnonceService annonceService, INotificationService notificationService, ISpecialiteService specialiteService,
               IProfesseurService professeurService, IProfesseurModuleService professeurModuleService)
        {
            _utilities = utilities;
            _etudiantService = etudiantService;
            _documentNonOfficielService = documentNonOfficielService;
            _documentOfficielService = documentOfficielService;
            _messageService = messageService;
            _annonceService = annonceService;
            _notificationService = notificationService;
            _specialiteService = specialiteService;
            _moduleService = moduleService;
            _professeurService = professeurService;
            _professeurModuleService = professeurModuleService;
        }
        #endregion Dependencies

        #region Index

        // GET: Professeur
        public ActionResult Index()
        {

            Professeur user = (Professeur)Session["user"];
            // Notifications
            List<Notification> notifications = _notificationService.GetUnreadNotifications(user.ProfesseurId).ToList();
            int notificationCount = notifications.Count();
            List<Etudiant> etudiants = new List<Etudiant>();
            // Documents
            List<DocumentOfficiel> mesDocuments = _documentOfficielService.GetDocumentsByUser(user.ProfesseurId, 1, 10).ToList();
            List<DocumentNonOfficiel> documents = new List<DocumentNonOfficiel>();
            List<Module> modules = new List<Module>();
            List<ProfesseurModule> professeurModules = _professeurModuleService.GetModulesByProfesseur(user.ProfesseurId).ToList();
            foreach (ProfesseurModule module in professeurModules)
            {
                modules.Add(_moduleService.Get(module.ModuleId));
                documents.AddRange(_documentNonOfficielService.GetDocumentByModule(module.ModuleId));
            }
            
            documents = documents.OrderByDescending(o => o.DocumentNonOfficielId).Take(10).ToList();
            // Messages
            List<Message> messages = _messageService.GetMessagesByProfesseur(user.ProfesseurId, 1, 5).ToList();
            // Specialites
            List<Specialite> specialites = new List<Specialite>();
            // Annonces
            List<Annonce> annonces = _annonceService.GetAll().OrderByDescending(o => o.AnnonceId).Take(5).ToList();

            //Etudiants
            var specialiteWithNiveau = _professeurService.GetSpecialiteWithNiveau(user.ProfesseurId);
            foreach (int specialite in specialiteWithNiveau.Keys)
            {
                specialites.Add(_specialiteService.Get(specialite));
                foreach (int niveau in specialiteWithNiveau[specialite])
                {
                    etudiants.AddRange(_etudiantService.GetEtudiantsBySpecialite(specialite,niveau).ToList());
                }
            }
            
            // Model
            Session["notifications"] = notifications;
            Session["notificationCount"] = notificationCount;
            ViewBag.documents = documents;
            ViewBag.messages = messages;
            ViewBag.annonces = annonces;
            ViewBag.specialites = specialites;
            ViewBag.modules = modules;
            ViewBag.etudiants = etudiants;
            return View(mesDocuments);
        }
        #endregion Index

        #region Profile

        public ActionResult UserProfile()
        {

            return View((Professeur)Session["user"]);
        }
        [HttpPost]
        public ActionResult UserProfile(string email, string telephone)
        {
            Professeur user = (Professeur)Session["user"];
            if (email == null || email.Equals(""))
            {
                return View(user);
            }

            user.Email = email;
            user.Telephone = telephone;
            user = _professeurService.Edit(user);
            if (user == null)
            {
                user = _professeurService.Get(((Professeur)Session["user"]).ProfesseurId);
                Session["user"] = user;
                return View(user);
            }
            Session["user"] = user;
            return View(user);
        }
        [HttpPost]
        public ActionResult Avatar(HttpPostedFileBase image)
        {
            Professeur user = (Professeur)Session["user"];
            if (image != null && image.ContentLength > 0)
            {
                var extension = Path.GetExtension(image.FileName);
                if (!extension.ToLower().Equals(".jpg") && !extension.ToLower().Equals(".jpeg") && !extension.ToLower().Equals(".png"))
                {
                    return RedirectToAction("UserProfile");
                }
                var path = "~/Resources/Profiles/" +user.Login.ToLower() + extension.ToLower();
                user.ProfilePath = path;
                user = _professeurService.Edit(user);
                if (user != null)
                    image.SaveAs(Path.Combine(Server.MapPath("~/Resources/Profiles"), user.Login.ToLower() + extension.ToLower()));
            }
            Session["user"] = _professeurService.Get(user.ProfesseurId);
            return RedirectToAction("UserProfile");
        }
        [HttpPost]
        public ActionResult ChangePassword(string oldpass, string newpass, string renewpass)
        {
            Professeur user = (Professeur)Session["user"];
            if (!user.Password.Equals(_utilities.Hash("iscae" + oldpass)) || !renewpass.Equals(newpass))
            {
                return RedirectToAction("UserProfile");
            }
            user.Password = _utilities.Hash("iscae" + newpass);
            user = _professeurService.Edit(user);
            return RedirectToAction("UserProfile");
        }

        #endregion Profile
    }
}