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
    [EtudiantFilter()]
    public class EtudiantController : Controller
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
        private IQuestionService _questionService;
        private IModuleService _moduleService;
        private ISpecialiteModuleService _specialiteModuleService;

        public EtudiantController(IUtilities utilities, IEtudiantService etudiantService, IDocumentNonOfficielService documentNonOfficielService,
               IDocumentOfficielService documentOfficielService, IMessageService messageService, IModuleService moduleService,
               IAnnonceService annonceService, INotificationService notificationService, IQuestionService questionService,
               IProfesseurService professeurService, ISpecialiteModuleService specialiteModuleService)
        {
            _utilities = utilities;
            _etudiantService = etudiantService;
            _documentNonOfficielService = documentNonOfficielService;
            _documentOfficielService = documentOfficielService;
            _messageService = messageService;
            _annonceService = annonceService;
            _notificationService = notificationService;
            _questionService = questionService;
            _moduleService = moduleService;
            _professeurService = professeurService;
            _specialiteModuleService = specialiteModuleService;
        }
        #endregion Dependencies

        // GET: Etudiant
        #region Index
        public ActionResult Index()
        {
            
            Etudiant user = (Etudiant)Session["user"];
            // Notifications
            List<Notification> notifications = _notificationService.GetUnreadNotifications(user.EtudiantId).ToList();
            int notificationCount = notifications.Count();

            // Documents
            List<DocumentNonOfficiel> documents = new List<DocumentNonOfficiel>();
            List <SpecialiteModule> pecialiteModules = _specialiteModuleService.GetSpecialiteModulesByNiveau(user.SpecialiteId,user.Niveau).ToList();
            foreach (SpecialiteModule module in pecialiteModules)
            {
                documents.AddRange(_documentNonOfficielService.GetDocumentByModule(module.ModuleId, user.Niveau,1,10));
            }
            documents = documents.OrderByDescending(o => o.DocumentNonOfficielId).Take(10).ToList();
            // Messages
            List<Message> messages = _messageService.GetMessagesBySpecialiteAndNiveau(user.SpecialiteId, user.Niveau,1,5).ToList();
            int messageCount = messages.Count();

            // Annonces
            List<Annonce> annonces = _annonceService.GetAll().OrderByDescending(o => o.AnnonceId).Take(5).ToList();

            // Discussions
            List<Question> questions = _questionService.GetAll().OrderByDescending(o => o.QuestionId).Take(10).ToList();

            // Modules
            List<SpecialiteModule> data = _specialiteModuleService.GetSpecialiteModulesByNiveau(user.SpecialiteId, user.Niveau).ToList();
            List<Module> modules = new List<Module>();
            foreach (SpecialiteModule sm in data)
            {
                modules.Add(_moduleService.Get(sm.ModuleId));
            }
            // Model
            Session["notifications"] = notifications;
            Session["notificationCount"] = notificationCount;
            Session["messageCount"] = messageCount;
            ViewBag.documents = documents;
            ViewBag.messages = messages;
            ViewBag.messageCount = messageCount;
            ViewBag.annonces = annonces;
            ViewBag.questions = questions;
            ViewBag.modules = modules;
            ViewBag.professeurs = _professeurService.GetProfesseursBySpecialiteAndNiveau(user.SpecialiteId,user.Niveau);
            ViewBag.etudiants = _etudiantService.Find(o=>o.SpecialiteId==user.SpecialiteId && o.Niveau == user.Niveau).ToList();
            return View(user);
        }
        #endregion Index

        #region Profile
        public ActionResult UserProfile()
        {
            
            return View((Etudiant)Session["user"]);
        }
        [HttpPost]
        public ActionResult UserProfile(string email, string telephone)
        {
            Etudiant user = (Etudiant)Session["user"];
            if (email == null || email.Equals(""))
            {
                return View(user);
            }
            
            user.Email = email;
            user.Telephone = telephone;
            user = _etudiantService.Edit(user);
            if(user == null)
            {
                user = _etudiantService.Get(((Etudiant)Session["user"]).EtudiantId);
                Session["user"] = user;
                return View(user);
            }
            Session["user"] = user;
            return View(user);
        }
        [HttpPost]
        public ActionResult Avatar(HttpPostedFileBase image)
        {
            Etudiant user = (Etudiant)Session["user"];
            if (image != null && image.ContentLength > 0)
            {
                var extension = Path.GetExtension(image.FileName);
                if (!extension.ToLower().Equals(".jpg") && !extension.ToLower().Equals(".jpeg") && !extension.ToLower().Equals(".png"))
                {
                    return RedirectToAction("UserProfile");
                }
                var path = "~/Resources/Profiles/" + user.Login.ToLower() + extension.ToLower();
                user.ProfilePath = path;
                user = _etudiantService.Edit(user);
                if (user != null)
                    image.SaveAs(Path.Combine(Server.MapPath("~/Resources/Profiles"), user.Login.ToLower() + extension.ToLower()));
            }
            Session["user"] = _etudiantService.Get(((Etudiant)Session["user"]).EtudiantId);
            return RedirectToAction("UserProfile");
        }
        [HttpPost]
        public ActionResult ChangePassword(string oldpass, string newpass, string renewpass)
        {
            Etudiant user = (Etudiant)Session["user"];
            if (!user.Password.Equals(_utilities.Hash("iscae" + oldpass)) || !renewpass.Equals(newpass))
            {
                return RedirectToAction("UserProfile");
            }
            user.Password = _utilities.Hash("iscae" + newpass);
            user = _etudiantService.Edit(user);
            return RedirectToAction("UserProfile");
        }
        #endregion Profile

        #region Module
        public ActionResult Modules()
        {
            Etudiant user = (Etudiant)Session["user"];
            
            Dictionary<Module, Professeur> model = _professeurService.GetProfesseursBySpecialiteAndNiveau(user.SpecialiteId,user.Niveau);
            return View(model);
        }
        #endregion Module
    }

}