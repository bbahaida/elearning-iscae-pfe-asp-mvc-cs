using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public class SpecialiteModuleRepository : Repository<IscaeEntities, SpecialiteModule>, ISpecialiteModuleRepository
    {
        public IEnumerable<SpecialiteModule> GetSpecialiteModulesByModule(int ModuleId)
        {
            try
            {
                return Context.Set<SpecialiteModule>().Where(o => o.ModuleId == ModuleId);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<SpecialiteModule> GetSpecialiteModulesByNiveau(int SpecialiteId, int Niveau)
        {
            try
            {
                return Context.Set<SpecialiteModule>().Where(o => o.SpecialiteId == SpecialiteId && o.Niveau == Niveau);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<SpecialiteModule> GetSpecialiteModulesBySpecialite(int SpecialiteId)
        {
            try
            {
                return Context.Set<SpecialiteModule>().Where(o => o.SpecialiteId == SpecialiteId);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }
    }
}
