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
        #region Dependencies

        private IAnnonceService _annonceService;
        private IResultatService _resultatService;
        private ISpecialiteService _specialiteService;
        public AnnonceController(IAnnonceService annonceService, IResultatService resultatService, ISpecialiteService specialiteService)
        {
            _annonceService = annonceService;
            _resultatService = resultatService;
            _specialiteService = specialiteService;
        }
        #endregion Dependencies

        #region Index
        // GET: Annonce
        public ActionResult Index()
        {
            ViewBag.Avis = _annonceService.GetAll().OrderByDescending(o=>o.AnnonceId).Take(10).ToList();
            ViewBag.Resultats = _resultatService.GetAll().OrderByDescending(o => o.ResultatId).Take(10).ToList();
            ViewBag.Specialites = _specialiteService.GetAll().ToList();
            return View();
        }
        #endregion Index

        #region Avis
        public ActionResult Avis(int id)
        {
            Annonce avis = _annonceService.Get(id);
            if (avis == null)
                RedirectToAction("Index");
            return View(avis);
        }
        #endregion Avis

        #region Resultat
        public FileResult Download(int id)
        {
            Resultat result = _resultatService.Get(id);
            if (result == null)
            {
                throw new HttpException(404, "Document n'existe pas");
            }
            return File(Server.MapPath(result.Path), System.Net.Mime.MediaTypeNames.Application.Octet, result.Path.Remove(0, 22));
        }
        #endregion Resultat

    }
}