using ISCAE.Business.Services;
using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ISCAE.Web.Filters;

namespace ISCAE.Web.Controllers
{
    [SessionFilter]
    public class DocumentController : Controller
    {
        private IDocumentNonOfficielService _documentNonOfficielService;
        private IDocumentOfficielService _documentOfficielService;
        private ISpecialiteModuleService _specialiteModuleService;
        private IModuleService _moduleService;
        private IEtudiantService _etudiantService;
        private IProfesseurSpecialiteService _professeurSpecialiteService;
        private IProfesseurModuleService _professeurModuleService;
        private ISpecialiteService _specialiteService;
        private IProfesseurService _professeurService;
        public DocumentController(IDocumentNonOfficielService documentNonOfficielService, IDocumentOfficielService documentOfficielService,
            ISpecialiteModuleService specialiteModuleService, IModuleService moduleService, IEtudiantService etudiantService, IProfesseurModuleService professeurModuleService,
            IProfesseurSpecialiteService professeurSpecialiteService, ISpecialiteService specialiteService, IProfesseurService professeurService)
        {
            _documentNonOfficielService = documentNonOfficielService;
            _documentOfficielService = documentOfficielService;
            _specialiteModuleService = specialiteModuleService;
            _moduleService = moduleService;
            _etudiantService = etudiantService;
            _professeurSpecialiteService = professeurSpecialiteService;
            _professeurModuleService = professeurModuleService;
            _specialiteService = specialiteService;
            _professeurService = professeurService;
        }

        // GET: Document
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Officiel(int? pageIndex, int? pageSize)
        {
            if (pageIndex == null || pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (pageSize == null || pageSize < 1)
            {
                pageSize = 10;
            }
            if (Session["user"] is Etudiant)
            {
                var user = (Etudiant)Session["user"];
                List<DocumentOfficiel> documents = _documentOfficielService.GetAll().OrderByDescending(o => o.DocumentOfficielId).Skip(((int)pageIndex - 1) * (int)pageSize).Take((int)pageSize).ToList();
                ViewBag.professeurs = _professeurService.GetProfesseursBySpecialiteAndNiveau(user.SpecialiteId,user.Niveau);
                ViewBag.pageIndex = (int)pageIndex;
                ViewBag.TopUsers = _documentOfficielService.GetTopUsers(_professeurService.GetProfesseursBySpecialiteAndNiveau(((Etudiant)Session["user"]).SpecialiteId, ((Etudiant)Session["user"]).Niveau).Values.ToList());
                return View(documents);
            }
            else if (Session["user"] is Professeur)
            {
                var user = (Professeur)Session["user"];
                List<ProfesseurSpecialite> professeurSpecialites = _professeurSpecialiteService.GetSpecialitesByProfesseur(user.ProfesseurId).ToList();
                List<Specialite> specialites = new List<Specialite>();
                List<ProfesseurModule> professeurModules = _professeurModuleService.GetModulesByProfesseur(user.ProfesseurId).ToList();
                List<Module> modules = new List<Module>();
                foreach (ProfesseurSpecialite specialite in professeurSpecialites)
                {
                    specialites.Add(_specialiteService.Get(specialite.SpecialiteId));
                }
                foreach (ProfesseurModule professeurModule in professeurModules)
                {
                    modules.Add(_moduleService.Get(professeurModule.ModuleId));
                }

                List<DocumentOfficiel> documents = _documentOfficielService.GetDocumentsByUser(user.ProfesseurId,(int)pageIndex,(int)pageSize).ToList();
                ViewBag.modules = modules;
                ViewBag.specialites = specialites;
                ViewBag.pageIndex = (int)pageIndex;
                ViewBag.maxPage = (int)Math.Ceiling(_documentOfficielService.GetAll().Where(o=>o.ProfesseurId == user.ProfesseurId).Count()/(decimal)pageSize);
                return View(documents);
            }
            else 
            {
                
            }

            return null;
        }
        public ActionResult NonOfficiel(int? pageIndex, int? pageSize)
        {
            if (pageIndex == null || pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (pageSize == null || pageSize < 1)
            {
                pageSize = 10;
            }
            if (Session["user"] is Etudiant)
            {
                List<DocumentNonOfficiel> documents = _documentNonOfficielService.GetAll().OrderByDescending(o=>o.DocumentNonOfficielId).Skip(((int)pageIndex -1)*(int)pageSize).Take((int)pageSize).ToList();
                var data = _specialiteModuleService.GetSpecialiteModulesByNiveau(((Etudiant)Session["user"]).SpecialiteId, ((Etudiant)Session["user"]).Niveau);
                List<Module> modules = new List<Module>();
                foreach (SpecialiteModule sm in data)
                {
                    modules.Add(_moduleService.Get(sm.ModuleId));
                }
                ViewBag.maxPage = (int)Math.Ceiling(_documentNonOfficielService.GetAll().Count()/(decimal)pageSize);
                ViewBag.pageIndex = (int)pageIndex;
                ViewBag.Modules = modules;
                ViewBag.TopUsers = _documentNonOfficielService.GetTopUsers(((Etudiant)Session["user"]).SpecialiteId, ((Etudiant)Session["user"]).Niveau);
                ViewBag.Etudiants = _etudiantService.GetEtudiantsBySpecialite(((Etudiant)Session["user"]).SpecialiteId, ((Etudiant)Session["user"]).Niveau).ToList();
                return View(documents);

            }
            else if (Session["user"] is Professeur)
            {
                var user = (Professeur)Session["user"];
                List<DocumentNonOfficiel> documents = new List<DocumentNonOfficiel>();
                List<Etudiant> etudiants = new List<Etudiant>();
                List<Specialite> specialites = new List<Specialite>();
                List<Module> modules = _moduleService.GetAll().ToList();

                List<ProfesseurSpecialite> ps = _professeurSpecialiteService.GetSpecialitesByProfesseur(user.ProfesseurId).ToList();
                List<ProfesseurModule> professeurModules = _professeurModuleService.GetModulesByProfesseur(user.ProfesseurId).ToList();
                var specialiteWithNiveau = _professeurService.GetSpecialiteWithNiveau(user.ProfesseurId);

                foreach (ProfesseurModule module in professeurModules)
                {
                    modules.Add(_moduleService.Get(module.ModuleId));
                    documents.AddRange(_documentNonOfficielService.GetDocumentByModule(module.ModuleId));
                }
                foreach (int specialite in specialiteWithNiveau.Keys)
                {
                    specialites.Add(_specialiteService.Get(specialite));
                    foreach (int niveau in specialiteWithNiveau[specialite])
                    {
                        etudiants.AddRange(_etudiantService.GetEtudiantsBySpecialite(specialite, niveau).ToList());
                    }
                }
                
                ViewBag.specialites = specialites;
                ViewBag.etudiants = etudiants;
                ViewBag.modules = modules;
                ViewBag.pageIndex = (int)pageIndex;
                ViewBag.maxPage = (int)Math.Ceiling(documents.Count / (decimal)pageSize);
                return View(documents.OrderByDescending(o=>o.ModuleId).Skip(((int)pageIndex - 1) * (int)pageSize).Take((int)pageSize).ToList());
            }
            else
            {

            }

            return null;
            
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
        public ActionResult AddDocument(HttpPostedFileBase document, int module)
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
                if(Session["user"] is Etudiant)
                {
                    DocumentNonOfficiel documentNonOfficiel = new DocumentNonOfficiel
                    {
                        Titre = titre,
                        Emplacement = path,
                        Type = type,
                        DateAjoutNonOfficiel = DateTime.Now,
                        ModuleId = module,
                        EtudiantId = ((Etudiant)Session["user"]).EtudiantId

                    };
                    documentNonOfficiel = _documentNonOfficielService.Add(documentNonOfficiel);
                    string targetPath = Server.MapPath("~/Resources/Documents");
                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }
                    if (documentNonOfficiel != null)
                        document.SaveAs(Path.Combine(targetPath, Path.GetFileName(document.FileName)));
                    return RedirectToAction("NonOfficiel", "Document");
                }
                else if (Session["user"] is Professeur)
                {
                    DocumentOfficiel documentOfficiel = new DocumentOfficiel
                    {
                        Titre = titre,
                        Emplacement = path,
                        Type = type,
                        DateAjoutOfficiel = DateTime.Now,
                        ModuleId = module,
                        ProfesseurId = ((Professeur)Session["user"]).ProfesseurId

                    };
                    documentOfficiel = _documentOfficielService.Add(documentOfficiel);
                    if (documentOfficiel != null)
                        document.SaveAs(Path.Combine(Server.MapPath("~/Resources/Documents"), Path.GetFileName(document.FileName)));
                    return RedirectToAction("Officiel", "Document");
                }
                

            }
            return new HttpNotFoundResult();
        }
        public FileResult Download(int documentId)
        {
            DocumentNonOfficiel document = _documentNonOfficielService.Get(documentId);
            if(document == null)
            {
                throw new HttpException(404,"Document n'existe pas");
            }
            return File(Server.MapPath(document.Emplacement), System.Net.Mime.MediaTypeNames.Application.Octet,document.Titre+"."+document.Type);
        }
    
    }
}