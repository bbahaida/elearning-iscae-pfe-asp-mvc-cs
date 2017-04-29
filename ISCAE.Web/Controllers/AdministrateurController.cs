using ISCAE.Business.Services;
using ISCAE.Data;
using ISCAE.Web.Filters;
using ISCAE.Web.Models;
using System;
using System.Collections.Generic;
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
        private IEtudiantService _etudiantService;
        private ISpecialiteService _specialiteService;
        public AdministrateurController(IExcelReader excelReader, IEtudiantService etudiantService, ISpecialiteService specialiteService)
        {
            _etudiantService = etudiantService;
            _excelReader = excelReader;
            _specialiteService = specialiteService;
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
    }
}