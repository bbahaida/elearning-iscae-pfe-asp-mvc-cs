using ISCAE.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISCAE.Web.Controllers
{
    public class EmploiController : Controller
    {
        // GET: Emploi
        [SessionFilter()]
        [AdministrateurFilter()]
        public ActionResult Index(int? id)
        {
            if(id == null)
            {
                
            }
            return View();
        }
    }
}