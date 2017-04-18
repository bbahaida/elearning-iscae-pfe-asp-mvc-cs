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
    [SessionFilter()]
    public class EtudiantController : Controller
    {
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

        public EtudiantController(IEtudiantService etudiantService, IDocumentNonOfficielService documentNonOfficielService,
               IDocumentOfficielService documentOfficielService, IMessageService messageService, IModuleService moduleService,
               IAnnonceService annonceService, INotificationService notificationService, IQuestionService questionService,
               IProfesseurService professeurService, ISpecialiteModuleService specialiteModuleService)
        {
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
        // GET: Etudiant

        public ActionResult Index()
        {
            
            Etudiant user = (Etudiant)Session["user"];
            // Notifications
            List<Notification> notifications = _notificationService.GetUnreadNotifications(user.EtudiantId).ToList();
            int notificationCount = notifications.Count();

            // Documents
            List<DocumentNonOfficiel> documents = _documentNonOfficielService.GetNonValidDocument(1, 10).ToList();

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
    }
}