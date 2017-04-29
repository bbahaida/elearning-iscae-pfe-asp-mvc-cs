using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public interface IProfesseurModuleRepository : IRepository<ProfesseurModule>
    {
        IEnumerable<ProfesseurModule> GetModulesByProfesseur(int ProfesseurId);
        IEnumerable<ProfesseurModule> GetProfesseursByModule(int ModuleId);
        int GetId(int ProfesseurId, int ModuleId);
    }
}
