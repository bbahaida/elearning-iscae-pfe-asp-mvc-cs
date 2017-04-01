using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public class SpecialiteModuleRepository : Repository<IscaeEntities, SpecialiteModule>, ISpecialiteModuleRepository
    {
        public IEnumerable<SpecialiteModule> GetSpecialiteModulesByNiveau(int SpecialiteId, int Niveau)
        {
            return Context.Set<SpecialiteModule>().Where(o => o.SpecialiteId == SpecialiteId && o.Niveau == Niveau).AsEnumerable();
        }
    }
}
