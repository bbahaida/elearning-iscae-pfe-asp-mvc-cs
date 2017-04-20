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
    [EtudiantFilter()]
    public class DiscussionController : Controller
    {
        private IQuestionService _questionService;
        private IReponseService _reponseService;
        private IEtudiantService _etudiantService;
        public DiscussionController(IQuestionService questionService, IReponseService reponseService, IEtudiantService etudiantService)
        {
            _questionService = questionService;
            _reponseService = reponseService;
            _etudiantService = etudiantService;
        }
        // GET: Discussion
        public ActionResult Index()
        {
            var user = (Etudiant)Session["user"];
            ViewBag.etudiants = _etudiantService.GetEtudiantsBySpecialite(user.SpecialiteId, user.Niveau).ToList();
            List<Question> questions = _questionService.GetQuestionsBySpecialite(user.SpecialiteId,user.Niveau).OrderByDescending(o=>o.QuestionId).Take(10).ToList();
            
            return View(questions);
        }
        [HttpPost]
        public ActionResult Add(string titre, string contenu)
        {
            Question question = new Question
            {
                Titre = titre,
                Contenu = contenu,
                DateQuestion = DateTime.Now,
                EtudiantId = ((Etudiant)Session["user"]).EtudiantId
            };
            question = _questionService.Add(question);
            if (question == null)
            {
                throw new HttpException(500,"Votre Question a rencontre un probleme");
            }
            return RedirectToAction("Index","Discussion");
        }
        public ActionResult Discussion(int? id,int? pageIndex, int? pageSize)
        {
            
            if (id == null)
            {
                return RedirectToAction("Index", "Discussion");
            }
            var user = (Etudiant)Session["user"];
            if (pageIndex == null || pageIndex < 1)
                pageIndex = 1;
            if (pageSize == null || pageSize < 1)
                pageSize = 10;
            Question question = _questionService.Get((int)id);
            ViewBag.etudiants = _etudiantService.GetEtudiantsBySpecialite(user.SpecialiteId,user.Niveau).ToList();
            ViewBag.reponses = _reponseService.GetReponsesByQuestion(question.QuestionId, (int) pageIndex, (int)pageSize).ToList();
            return View(question);
        }
        [HttpPost]
        public ActionResult AddReponse(int id, string reponse)
        {
            if (reponse.Equals("") || id < 1 || _questionService.Get(id) == null)
            {
                return RedirectToAction("Index","Etudiant");
            }
            if (reponse.Equals(""))
            {
                return RedirectToAction("Discussion", "Discussion",new { id = id});
            }
            var user = (Etudiant)Session["user"];
            Repons repons = new Repons
            {
                Contenu = reponse,
                QuestionId = id,
                DateReponse = DateTime.Now,
                EtudiantId = user.EtudiantId
            };
            repons = _reponseService.Add(repons);
            if (repons == null)
            {
                throw new HttpException(500,"Erreur Interne");
            }
            return RedirectToAction("Discussion", "Discussion", new { id = id });
        }
    }
}