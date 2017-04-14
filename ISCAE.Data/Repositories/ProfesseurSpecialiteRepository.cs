using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public class ProfesseurSpecialiteRepository : Repository<IscaeEntities, ProfesseurSpecialite>, IProfesseurSpecialiteRepository
    {
        public IEnumerable<ProfesseurSpecialite> GetProfesseursBySpecialite(int SpecialiteId)
        {
            try
            {
                return Context.Set<ProfesseurSpecialite>().Where(o => o.SpecialiteId == SpecialiteId).AsEnumerable();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<ProfesseurSpecialite> GetSpecialitesByProfesseur(int ProfesseurId)
        {
            try
            {
                return Context.Set<ProfesseurSpecialite>().Where(o => o.ProfesseurId == ProfesseurId).AsEnumerable();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }
    }
}
