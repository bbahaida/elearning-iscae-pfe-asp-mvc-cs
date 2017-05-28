using ISCAE.Business.Services;
using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ISCAE.Web.Controllers
{
    public class AnnonceApiController : ApiController
    {
        private IAnnonceService _annonceService;
        
        public AnnonceApiController(IAnnonceService annonceService)
        {
            _annonceService = annonceService;
        }

        // GET: api/AnnonceApi/5
        public Annonce Get(int id)
        {
            return _annonceService.Get(id);
        }
        
    }
}
