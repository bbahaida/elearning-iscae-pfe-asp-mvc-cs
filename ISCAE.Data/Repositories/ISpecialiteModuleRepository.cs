using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public interface ISpecialiteModuleRepository : IRepository<SpecialiteModule>
    {
        IEnumerable<SpecialiteModule> GetSpecialiteModulesByNiveau(int SpecialiteId, int Niveau);
        IEnumerable<SpecialiteModule> GetSpecialiteModulesBySpecialite(int SpecialiteId);
        IEnumerable<SpecialiteModule> GetSpecialiteModulesByModule(int ModuleId);
    }
}
