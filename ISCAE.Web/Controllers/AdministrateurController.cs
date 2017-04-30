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
        private IExcelReader _excelReader;
        private IAdministrateurService _administrateurService;
        private IEtudiantService _etudiantService;
        private ISpecialiteService _specialiteService;
        private IAnnonceService _annonceService;
        public AdministrateurController(IExcelReader excelReader, IEtudiantService etudiantService,
            ISpecialiteService specialiteService, IAnnonceService annonceService, IAdministrateurService administrateurService)
        {
            _administrateurService = administrateurService;
            _etudiantService = etudiantService;
            _excelReader = excelReader;
            _specialiteService = specialiteService;
            _annonceService = annonceService;
        }
        // GET: Administrateur
        public ActionResult Index()
        {
            return View();
        }
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
        public ActionResult Close(int id)
        {
            Etudiant e = _etudiantService.Get(id);
            e.isActive = 0;
            e = _etudiantService.Edit(e);

            return RedirectToAction("Etudiants","Administrateur");
        }
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
            return View("Avis");
        }

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
    }
}