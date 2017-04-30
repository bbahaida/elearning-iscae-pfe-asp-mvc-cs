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
    public class AnnonceController : Controller
    {
        private IAnnonceService _annonceService;
        private IResultatService _resultatService;
        private ISpecialiteService _specialiteService;
        public AnnonceController(IAnnonceService annonceService, IResultatService resultatService, ISpecialiteService specialiteService)
        {
            _annonceService = annonceService;
            _resultatService = resultatService;
            _specialiteService = specialiteService;
        }
        // GET: Annonce
        public ActionResult Index()
        {
            ViewBag.Avis = _annonceService.GetAll().OrderByDescending(o=>o.AnnonceId).Take(10).ToList();
            ViewBag.Resultats = _resultatService.GetAll().OrderByDescending(o => o.ResultatId).Take(10).ToList();
            ViewBag.Specialites = _specialiteService.GetAll().ToList();
            return View();
        }
        public ActionResult Avis(int id)
        {
            Annonce avis = _annonceService.Get(id);
            if (avis == null)
                RedirectToAction("Index");
            return View(avis);
        }
    }
}