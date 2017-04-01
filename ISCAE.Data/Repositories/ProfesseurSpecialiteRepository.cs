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
            return Context.Set<ProfesseurSpecialite>().Where(o => o.SpecialiteId == SpecialiteId).AsEnumerable();
        }

        public IEnumerable<ProfesseurSpecialite> GetSpecialitesByProfesseur(int ProfesseurId)
        {
            return Context.Set<ProfesseurSpecialite>().Where(o => o.ProfesseurId == ProfesseurId).AsEnumerable();
        }
    }
}
