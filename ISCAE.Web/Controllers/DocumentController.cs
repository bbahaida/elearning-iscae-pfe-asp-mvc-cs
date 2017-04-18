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
            
            IDocumentNonOfficielService _service = new DocumentNonOfficielService(new DocumentNonOfficielRepository(), new EtudiantRepository(), new ModuleRepository());
            IEtudiantService _etudiantService = new EtudiantService(new EtudiantRepository(), new SpecialiteRepository());
            List<DocumentNonOfficiel> documents = _service.GetNonValidDocument(1,10).ToList();
            
            return View(documents);
        }
        public ActionResult Add()
        {
            var user = Session["user"];
            if(user is Etudiant)
            {
                
                ISpecialiteModuleService _service = new SpecialiteModuleService(new SpecialiteModuleRepository(),new SpecialiteRepository());
                IModuleService _moduleservice = new ModuleService(new ModuleRepository());
                var data = _service.GetSpecialiteModulesByNiveau(((Etudiant)user).SpecialiteId, ((Etudiant)user).Niveau);
                List<Module> modules = new List<Module>();
                foreach (SpecialiteModule sm in data)
                {
                    modules.Add(_moduleservice.Get(sm.ModuleId));
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
                
                var path = Path.Combine(Server.MapPath("~/Resources/Documents"),Path.GetFileName(document.FileName));
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
                IDocumentNonOfficielService _service = new DocumentNonOfficielService(new DocumentNonOfficielRepository(), new EtudiantRepository(), new ModuleRepository());
                documentNonOfficiel = _service.Add(documentNonOfficiel);
                if(documentNonOfficiel != null)
                    document.SaveAs(path);
            }
            return RedirectToAction("NonOfficiel","Document");
        }
        public FileResult Download(int documentId)
        {
            IDocumentNonOfficielService _service = new DocumentNonOfficielService(new DocumentNonOfficielRepository(), new EtudiantRepository(), new ModuleRepository());
            DocumentNonOfficiel document = _service.Get(documentId);
            return File(AppDomain.CurrentDomain.BaseDirectory+"/Resources/Documents/"+document.Titre+"."+document.Type, System.Net.Mime.MediaTypeNames.Application.Octet,document.Titre+"."+document.Type);
        }
    
    }
}