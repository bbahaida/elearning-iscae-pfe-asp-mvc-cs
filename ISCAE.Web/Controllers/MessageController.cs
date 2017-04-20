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
    public class MessageController : Controller
    {
        private IMessageService _messageService;
        private IProfesseurService _professeurService;
        public MessageController(IMessageService messageService, IProfesseurService professeurService)
        {
            _messageService = messageService;
            _professeurService = professeurService;
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
                ViewBag.pageSize = (int)pageSize;
                ViewBag.pageIndex = (int)pageIndex;
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
                if(message == null)
                {
                    return RedirectToAction("Index","Message");
                }
                return View(message);
            }
            return null;
            
        }
    }
}