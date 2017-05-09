using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public class ResultatRepository : Repository<IscaeEntities, Resultat>, IResultatRepository
    {
        public IEnumerable<Resultat> GetResultatByAnnee(string Annee)
        {
            try
            {
                return Context.Set<Resultat>().Where(o=>o.Annee.Equals(Annee)).OrderBy(o => o.SpecialiteId);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<Resultat> GetResultatBySpecieliteAndAnnee(int SpecialiteId, string Annee)
        {
            try
            {
                return Context.Set<Resultat>().Where(o => o.SpecialiteId == SpecialiteId && o.Annee.Equals(Annee)).OrderBy(o => o.SpecialiteId);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<Resultat> GetResultatBySpecieliteAndSemestre(int SpecialiteId, string Semestre)
        {
            try
            {
                return Context.Set<Resultat>().Where(o => o.SpecialiteId == SpecialiteId && o.Semestre.Equals(Semestre)).OrderBy(o => o.SpecialiteId);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }
    }
}
