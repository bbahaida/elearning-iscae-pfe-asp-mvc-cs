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
            try
            {
                return Context.Set<ProfesseurModule>().Where(o => o.ProfesseurId == ProfesseurId).AsEnumerable();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<ProfesseurModule> GetProfesseursByModule(int ModuleId)
        {
            try
            {
                return Context.Set<ProfesseurModule>().Where(o => o.ModuleId == ModuleId).AsEnumerable();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }
    }
}
