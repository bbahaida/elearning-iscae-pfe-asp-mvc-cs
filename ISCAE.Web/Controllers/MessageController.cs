using ISCAE.Business.Services;
using ISCAE.Data;
using ISCAE.Web.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISCAE.Web.Controllers
{
    [SessionFilter()]
    public class MessageController : Controller
    {
        private IMessageService _messageService;
        private IProfesseurService _professeurService;
        private IProfesseurSpecialiteService _professeurSpecialiteService;
        private IProfesseurModuleService _professeurModuleService;
        private ISpecialiteService _specialiteService;
        private ISpecialiteModuleService _specialiteModuleService;
        public MessageController(IMessageService messageService, IProfesseurService professeurService, IProfesseurModuleService professeurModuleService,
                IProfesseurSpecialiteService professeurSpecialiteService, ISpecialiteService specialiteService, ISpecialiteModuleService specialiteModuleService)
        {
            _messageService = messageService;
            _professeurService = professeurService;
            _professeurSpecialiteService = professeurSpecialiteService;
            _specialiteService = specialiteService;
            _specialiteModuleService = specialiteModuleService;
            _professeurModuleService = professeurModuleService;
        }
        // GET: Message
        public ActionResult Index(int? pageIndex, int? pageSize)
        {
            if (pageIndex == null)
            {
                pageIndex = 1;
            }
            if (pageSize == null)
            {
                pageSize = 10;
            }
            if (Session["user"] is Etudiant)
            {
                var user = (Etudiant)Session["user"];
                List<Message> messages = _messageService.GetMessagesBySpecialiteAndNiveau(user.SpecialiteId, user.Niveau, (int)pageIndex, (int)pageSize).ToList();
                ViewBag.professeurs = _professeurService.GetProfesseursBySpecialiteAndNiveau(user.SpecialiteId, user.Niveau);
                ViewBag.maxPage = (int)Math.Ceiling(_messageService.GetAll().Where(o => o.SpecialiteId == user.SpecialiteId && o.Niveau == user.Niveau).Count() / (decimal)pageSize);
                ViewBag.pageIndex = (int)pageIndex;
                return View(messages);
            }
            else if(Session["user"] is Professeur)
            {
                var user = (Professeur)Session["user"];
                List<Message> messages = _messageService.GetMessagesByProfesseur(user.ProfesseurId, (int)pageIndex, (int)pageSize).ToList();
                List<ProfesseurSpecialite> professeurSpecialites = _professeurSpecialiteService.GetSpecialitesByProfesseur(user.ProfesseurId).ToList();
                Dictionary<string, List<int>> niveauBySpecialite = new Dictionary<string, List<int>>();
                List<Specialite> specialites = new List<Specialite>();
                List<ProfesseurModule> professeurModules = _professeurModuleService.GetModulesByProfesseur(user.ProfesseurId).ToList();

                foreach (ProfesseurSpecialite p in professeurSpecialites)
                {
                    bool uTeach = false;
                    List<int> niveau = new List<int>();
                    List<SpecialiteModule> sm = _specialiteModuleService.GetSpecialiteModulesBySpecialite(p.SpecialiteId).ToList();
                    specialites.Add(_specialiteService.Get(p.SpecialiteId));
                    foreach (ProfesseurModule m in professeurModules)
                    {
                        foreach (SpecialiteModule s in sm)
                        {
                            if (s.ModuleId == m.ModuleId)
                            {
                                uTeach = true;
                                niveau.Add(_specialiteModuleService.GetNiveauBySpecialiteAndModule(p.SpecialiteId, s.ModuleId));
                            }
                        }
                    }
                    if(uTeach)
                        niveauBySpecialite.Add(p.SpecialiteId.ToString(), niveau);
                }
                ViewBag.specialites = specialites;
                ViewBag.niveauBySpecialite = JsonConvert.SerializeObject(niveauBySpecialite, Formatting.Indented);

                return View(messages);
            }
            return null;
        }

        public ActionResult Boites(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index","Message");
            }
            if(Session["user"] is Etudiant)
            {
                var user = (Etudiant)Session["user"];
                ViewBag.professeurs = _professeurService.GetProfesseursBySpecialiteAndNiveau(user.SpecialiteId, user.Niveau);
                Message message = _messageService.Get((int)id);
                
                if (message == null)
                {
                    return RedirectToAction("Index","Message");
                }
                return View(message);
            }
            if (Session["user"] is Professeur)
            {
                var user = (Professeur)Session["user"];
                List<Specialite> specialites = new List<Specialite>();
                List<ProfesseurSpecialite> ps = _professeurSpecialiteService.GetSpecialitesByProfesseur(user.ProfesseurId).ToList();
                foreach (ProfesseurSpecialite s in ps)
                {
                    specialites.Add(_specialiteService.Get(s.SpecialiteId));
                }
                Message message = _messageService.Get((int)id);

                if (message == null)
                {
                    return RedirectToAction("Index", "Message");
                }
                ViewBag.specialites = specialites;
                return View(message);
            }
            return null;
            
        }
        [HttpPost]
        public ActionResult Add(int? specialite, int? first, int? second, int? third, string titre, string contenu)
        {
            if(_specialiteService.Get((int)specialite) == null || titre.Equals("") || contenu.Equals(""))
            {
                return RedirectToAction("Index","Message");
            }
            Message message = new Message
            {
                SpecialiteId = (int)specialite,
                Titre = titre,
                Contenu = contenu,
                DateEnvoiMessage = DateTime.Now,
                ProfesseurId = ((Professeur)Session["user"]).ProfesseurId
            };
            if (first != null && first == 1)
            {
                message.Niveau = 1;
                if(_messageService.Add(message) == null)
                {
                    return RedirectToAction("Index","Message");
                }
            }
            if (second != null && second == 2)
            {
                message.Niveau = 2;
                if (_messageService.Add(message) == null)
                {
                    return RedirectToAction("Index", "Message");
                }
            }
            if (third != null && third == 3)
            {
                message.Niveau = 3;
                if (_messageService.Add(message) == null)
                {
                    return RedirectToAction("Index", "Message");
                }
            }
            
            return RedirectToAction("Index", "Message");
        }
    }
}