using ISCAE.Business.Services;
using ISCAE.Data;
using ISCAE.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace ISCAE.Web.Controllers
{
    public class DocumentController : Controller
    {
        private IDocumentNonOfficielService _documentNonOfficielService;
        private IDocumentOfficielService _documentOfficielService;
        private ISpecialiteModuleService _specialiteModuleService;
        private IModuleService _moduleService;
        private IEtudiantService _etudiantService;
        public DocumentController(IDocumentNonOfficielService documentNonOfficielService, IDocumentOfficielService documentOfficielService,
            ISpecialiteModuleService specialiteModuleService, IModuleService moduleService, IEtudiantService etudiantService)
        {
            _documentNonOfficielService = documentNonOfficielService;
            _documentOfficielService = documentOfficielService;
            _specialiteModuleService = specialiteModuleService;
            _moduleService = moduleService;
            _etudiantService = etudiantService;
        }

        // GET: Document
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Officiel()
        {
            return View();
        }
        public ActionResult NonOfficiel()
        {
            
            List<DocumentNonOfficiel> documents = _documentNonOfficielService.GetNonValidDocument(1,10).ToList();
            var data = _specialiteModuleService.GetSpecialiteModulesByNiveau(((Etudiant)Session["user"]).SpecialiteId, ((Etudiant)Session["user"]).Niveau);
            List<Module> modules = new List<Module>();
            foreach (SpecialiteModule sm in data)
            {
                modules.Add(_moduleService.Get(sm.ModuleId));
            }
            ViewBag.Modules = modules;
            ViewBag.ModuleService = _moduleService;
            ViewBag.EtudiantService = _etudiantService;
            return View(documents);
        }
        public ActionResult Add()
        {
            var user = Session["user"];
            if(user is Etudiant)
            {
                
                
                var data = _specialiteModuleService.GetSpecialiteModulesByNiveau(((Etudiant)user).SpecialiteId, ((Etudiant)user).Niveau);
                List<Module> modules = new List<Module>();
                foreach (SpecialiteModule sm in data)
                {
                    modules.Add(_moduleService.Get(sm.ModuleId));
                }
                return View("AddEtudiant",modules);
            }
            if (user is Professeur)
            {
                return View("AddProfesseur");
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddEtudiant(HttpPostedFileBase document, int module)
        {
            if(document != null && document.ContentLength > 0)
            {
                var extension = Path.GetExtension(document.FileName);
                var type = "";
                if (extension.ToLower().Equals(".pdf") || extension.ToLower().Equals(".doc") || extension.ToLower().Equals(".docx") ||
                    extension.ToLower().Equals(".ppt") || extension.ToLower().Equals(".pptx") || extension.ToLower().Equals(".xls") ||
                    extension.ToLower().Equals(".xlsx") || extension.ToLower().Equals(".xml")
                    )
                {
                    type = extension.Substring(1).ToLower();
                }
                else
                {
                    return View("Add");
                }
                var titre = Path.GetFileNameWithoutExtension(document.FileName);
                
                var path = "~/Resources/Documents/"+Path.GetFileName(document.FileName);
                DocumentNonOfficiel documentNonOfficiel = new DocumentNonOfficiel
                {
                    Titre = titre,
                    Emplacement = path,
                    Type = type,
                    isValid = 0,
                    DateAjoutNonOfficiel = DateTime.Now,
                    ModuleId = module,
                    EtudiantId = ((Etudiant)Session["user"]).EtudiantId

                };
                documentNonOfficiel = _documentNonOfficielService.Add(documentNonOfficiel);
                if(documentNonOfficiel != null)
                    document.SaveAs(Path.Combine(Server.MapPath("~/Resources/Documents"), Path.GetFileName(document.FileName)));
            }
            return RedirectToAction("NonOfficiel","Document");
        }
        public FileResult Download(int documentId)
        {
            DocumentNonOfficiel document = _documentNonOfficielService.Get(documentId);
            return File(Server.MapPath(document.Emplacement), System.Net.Mime.MediaTypeNames.Application.Octet,document.Titre+"."+document.Type);
        }
    
    }
}