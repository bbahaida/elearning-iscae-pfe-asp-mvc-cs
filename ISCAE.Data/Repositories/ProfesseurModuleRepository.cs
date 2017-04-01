using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public class ProfesseurModuleRepository : Repository<IscaeEntities, ProfesseurModule>, IProfesseurModuleRepository
    {
        public IEnumerable<ProfesseurModule> GetModulesByProfesseur(int ProfesseurId)
        {
            return Context.Set<ProfesseurModule>().Where(o => o.ProfesseurId == ProfesseurId).AsEnumerable();
        }

        public IEnumerable<ProfesseurModule> GetProfesseursByModule(int ModuleId)
        {
            return Context.Set<ProfesseurModule>().Where(o => o.ModuleId == ModuleId).AsEnumerable();
        }
    }
}
