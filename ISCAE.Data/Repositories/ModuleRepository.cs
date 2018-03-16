using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public class ModuleRepository : Repository<IscaeEntities, Module>, IModuleRepository
    {
        public Module GetByDesignation(string designation)
        {
            try
            {
                return Context.Set<Module>().FirstOrDefault(o => o.Designation.ToLower().Equals(designation.ToLower()));
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }
    }
}
