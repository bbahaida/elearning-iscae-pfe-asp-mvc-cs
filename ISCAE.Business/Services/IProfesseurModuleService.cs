using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Business.Services
{
    public interface IProfesseurModuleService :ICommonService<ProfesseurModule>
    {
       
        IEnumerable<ProfesseurModule> GetModulesByProfesseur(int ProfesseurId);

        IEnumerable<ProfesseurModule> GetProfesseursByModule(int ModuleId);

    }
}
