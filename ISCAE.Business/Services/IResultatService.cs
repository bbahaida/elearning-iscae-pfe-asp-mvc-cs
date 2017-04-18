using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Business.Services
{
    public interface IResultatService : ICommonService<Resultat>
    {
        IEnumerable<Resultat> GetResultatBySpecieliteAndAnnee(int SpecialiteId, string Annee);
        IEnumerable<Resultat> GetResultatBySpecieliteAndSemestre(int SpecialiteId, string Semestre);
        IEnumerable<Resultat> GetResultatByAnnee(string Annee);
    }
}
