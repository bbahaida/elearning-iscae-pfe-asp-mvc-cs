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
    public class TestController : ApiController
    {
        private IAnnonceService _annonceService;

        public TestController(IAnnonceService annonceService)
        {
            _annonceService = annonceService;
        }

        // GET: api/Test

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        

        // GET: api/AnnonceApi/5
        public Annonce Get(int id)
        {
            return _annonceService.Get(id);
        }

        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
