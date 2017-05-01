using ISCAE.Business.Services;
using ISCAE.Data;
using ISCAE.Web.Filters;
using ISCAE.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISCAE.Web.Controllers
{
    [SessionFilter()]
    [AdministrateurFilter()]
    public class AdministrateurController : Controller
    {
        #region Dependencies

        private IExcelReader _excelReader;
        private IAdministrateurService _administrateurService;
        private IEtudiantService _etudiantService;
        private IProfesseurService _professeurService;
        private ISpecialiteService _specialiteService;
        private IAnnonceService _annonceService;
        private IResultatService _resultatService;
        private IModuleService _moduleService;
        private IProfesseurSpecialiteService _professeurSpecialiteService;
        private IProfesseurModuleService _professeurModuleService;
        public AdministrateurController(IExcelReader excelReader, IEtudiantService etudiantService,
            ISpecialiteService specialiteService, IAnnonceService annonceService, IProfesseurService professeurService,
            IAdministrateurService administrateurService, IResultatService resultatService, IProfesseurModuleService professeurModuleService,
            IModuleService moduleService, IProfesseurSpecialiteService professeurSpecialiteService)
        {
            _administrateurService = administrateurService;
            _etudiantService = etudiantService;
            _professeurService = professeurService;
            _excelReader = excelReader;
            _specialiteService = specialiteService;
            _annonceService = annonceService;
            _resultatService = resultatService;
            _moduleService = moduleService;
            _professeurSpecialiteService = professeurSpecialiteService;
            _professeurModuleService = professeurModuleService;
        }
        #endregion Dependencies

        #region Index
        // GET: Administrateur
        public ActionResult Index()
        {
            return View();
        }
        #endregion Index

        #region Etudiant

        public ActionResult AddEtudiants()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEtudiants(HttpPostedFileBase document, string year)
        {
            string extension = System.IO.Path.GetExtension(document.FileName);
            if (document == null || !extension.ToLower().Equals(".xls") && !extension.ToLower().Equals(".xlsx"))
            {
                return RedirectToAction("AddEtudiants", "Administrateur");
            }
            string targetpath = Server.MapPath("~/Resources/Etudiants/");
            string pathToExcelFile = targetpath+"Annee_"+ year.Substring(0,4)+"_"+ year.Substring(5, 4)+ "" +extension;
            document.SaveAs(pathToExcelFile);
            
            List<Etudiant> etudiants = _excelReader.Read(pathToExcelFile);
            _excelReader.Insert(etudiants);
            return View();
        }
        public ActionResult Etudiants()
        {
            ViewBag.etudiants = _etudiantService.GetAll().Where(o=>o.isActive == 1).ToList();
            return View(_specialiteService.GetAll().ToList());
        }
        public ActionResult CloseEtudiant(int id)
        {
            Etudiant e = _etudiantService.Get(id);
            e.isActive = 0;
            e = _etudiantService.Edit(e);

            return RedirectToAction("Etudiants","Administrateur");
        }
        #endregion Etudiant

        #region Annonces
        public ActionResult AddAvis()
        {
            return View(_specialiteService.GetAll().ToList());
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddAvis(string titre, string avis)
        {
            Administrateur user = (Administrateur)Session["user"];
            Annonce annonce = new Annonce
            {
                Titre = titre,
                AdministrateurId = user.AdministrateurId,
                DateAjout = DateTime.Now,
                Contenu = avis
            };
            annonce = _annonceService.Add(annonce);
            if(annonce == null)
            {
                return RedirectToAction("Index", "Administrateur");
            }
            return RedirectToAction("Index","Annonce");
        }
        [HttpPost]
        public ActionResult AddResultats(HttpPostedFileBase resultat, int specialite, string semester, string year)
        {
            Administrateur user = (Administrateur)Session["user"];
            if (resultat != null && resultat.ContentLength > 0)
            {
                var extension = Path.GetExtension(resultat.FileName);
                if (!extension.ToLower().Equals(".pdf"))
                {
                    return RedirectToAction("UserProfile");
                }
                var path = "~/Resources/Resultats/" + "Resultats_" + _specialiteService.Get(specialite).Designation + "_" + semester + "_" + year.Substring(0, 4) + "_" + year.Substring(5, 4) + extension.ToLower();
                Resultat result = new Resultat
                {
                    AdministrateurId = user.AdministrateurId,
                    Annee = year,
                    Path = path,
                    Semestre = byte.Parse(semester.Last().ToString()),
                    SpecialiteId = specialite
                };
                result = _resultatService.Add(result);
                if (result != null)
                {
                    resultat.SaveAs(Path.Combine(Server.MapPath("~/Resources/Resultats"), "Resultats_" + _specialiteService.Get(specialite).Designation + "_" + semester + "_" + year.Substring(0, 4) + "_" + year.Substring(5, 4) + extension.ToLower()));
                    return RedirectToAction("Index", "Annonce");
                }
            }
            return RedirectToAction("AddAvis", "Administrateur");
        }

        #endregion Annonces

        #region Profile
        public ActionResult UserProfile()
        {

            return View((Administrateur)Session["user"]);
        }
        [HttpPost]
        public ActionResult UserProfile(string email, string telephone)
        {
            Administrateur user = (Administrateur)Session["user"];
            if (email == null || email.Equals(""))
            {
                return View(user);
            }

            user.Email = email;
            user.Telephone = telephone;
            user = _administrateurService.Edit(user);
            if (user == null)
            {
                user = _administrateurService.Get(user.AdministrateurId);
                Session["user"] = user;
                return View(user);
            }
            Session["user"] = user;
            return View(user);
        }
        [HttpPost]
        public ActionResult Avatar(HttpPostedFileBase image)
        {
            Administrateur user = (Administrateur)Session["user"];
            if (image != null && image.ContentLength > 0)
            {
                var extension = Path.GetExtension(image.FileName);
                if (!extension.ToLower().Equals(".jpg") && !extension.ToLower().Equals(".jpeg") && !extension.ToLower().Equals(".png"))
                {
                    return RedirectToAction("UserProfile");
                }
                var path = "~/Resources/Profiles/" + user.Login.ToLower() + extension.ToLower();
                user.ProfilePath = path;
                user = _administrateurService.Edit(user);
                if (user != null)
                    image.SaveAs(Path.Combine(Server.MapPath("~/Resources/Profiles"), user.Login.ToLower() + extension.ToLower()));
            }
            Session["user"] = _administrateurService.Get(user.AdministrateurId);
            return RedirectToAction("UserProfile");
        }
        [HttpPost]
        public ActionResult ChangePassword(string oldpass, string newpass, string renewpass)
        {
            Administrateur user = (Administrateur)Session["user"];
            if (!user.Password.Equals(oldpass) || !renewpass.Equals(newpass))
            {
                return RedirectToAction("UserProfile");
            }
            user.Password = newpass;
            user = _administrateurService.Edit(user);
            return RedirectToAction("UserProfile");
        }
        #endregion Profile

        #region Professeur
        public ActionResult Professeurs()
        {
            return View(_professeurService.GetAll().Where(o => o.isActive == 1).OrderBy(o=>o.Nom).ToList());
        }
        public ActionResult AddProfesseur()
        {
            ViewBag.specialites = _specialiteService.GetAll().ToList();
            ViewBag.professeurs = _professeurService.GetAll().Where(o=>o.isActive == 1).OrderBy(o=>o.Nom).ToList();
            ViewBag.modules = _moduleService.GetAll().ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddProfesseur(string nom, string email, string login,string password, string tel, string nni)
        {
            if (nom == null || nom.Equals("") || email == null || email.Equals("") || login == null || login.Equals("")
                || password == null || password.Equals("") || nni == null || nni.Equals("") 
                || _professeurService.GetUserByLogin(login) != null || _professeurService.GetUserByEmail(email) != null
                || _professeurService.GetUserByTelephone(tel) != null)
            {
                return RedirectToAction("AddProfesseur","Administrateur");
            }
            
            Professeur prof = new Professeur
            {
                isActive = 1,
                Email = email,
                Login = login,
                Nom = nom,
                ProfilePath = "~/Resources/Profiles/avatar.png",
                Password = password,
                Telephone = tel
            };
            prof = _professeurService.Add(prof);
            if(prof == null)
                return RedirectToAction("AddProfesseur", "Administrateur");
            return RedirectToAction("Professeurs","Administrateur");
        }
        [HttpPost]
        public ActionResult AddProfesseurSpecialite(int professeur, int specialite)
        {
            ProfesseurSpecialite profs = new ProfesseurSpecialite
            {
                ProfesseurId = professeur,
                SpecialiteId = specialite
            };
            profs = _professeurSpecialiteService.Add(profs);
            if(profs == null)
                return RedirectToAction("AddProfesseur", "Administrateur");
            return RedirectToAction("Professeurs", "Administrateur");
        }
        [HttpPost]
        public ActionResult AddProfesseurModule(int professeur, int module)
        {
            ProfesseurModule profs = new ProfesseurModule
            {
                ProfesseurId = professeur,
                ModuleId = module
            };
            profs = _professeurModuleService.Add(profs);
            if (profs == null)
                return RedirectToAction("AddProfesseur", "Administrateur");
            return RedirectToAction("Professeurs", "Administrateur");
        }

        #endregion Professeur
    }
}