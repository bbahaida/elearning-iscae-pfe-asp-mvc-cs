using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISCAE.Data.Repositories;

namespace ISCAE.Business.Services
{
    public class ResultatService : CommonService<Resultat>, IResultatService
    {

        private IResultatRepository _resultatRepository;
        public ResultatService(IUnitOfWork unit) : base(unit.Resultats)
        {
            _resultatRepository = unit.Resultats;
        }

        public IEnumerable<Resultat> GetResultatByAnnee(string Annee)
        {
            if (Annee.Equals(""))
                return null;
            return _resultatRepository.GetResultatByAnnee(Annee);
        }

        public IEnumerable<Resultat> GetResultatBySpecieliteAndAnnee(int SpecialiteId, string Annee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Resultat> GetResultatBySpecieliteAndSemestre(int SpecialiteId, string Semestre)
        {
            throw new NotImplementedException();
        }
    }
}
