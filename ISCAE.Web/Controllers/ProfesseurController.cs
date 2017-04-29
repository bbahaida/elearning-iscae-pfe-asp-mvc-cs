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
    [ProfesseurFilter()]
    public class ProfesseurController : Controller
    {
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

        public ProfesseurController(IEtudiantService etudiantService, IDocumentNonOfficielService documentNonOfficielService,
               IDocumentOfficielService documentOfficielService, IMessageService messageService, IModuleService moduleService,
               IAnnonceService annonceService, INotificationService notificationService, ISpecialiteService specialiteService,
               IProfesseurService professeurService, IProfesseurModuleService professeurModuleService)
        {
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
    }
}