using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISCAE.Data.Repositories;

namespace ISCAE.Business.Services
{
    public class ProfesseurModuleService : CommonService<ProfesseurModule>, IProfesseurModuleService
    {
        private IProfesseurModuleRepository _professeurModuleRepository;
        private IProfesseurRepository _professeurRepository;
        private IModuleRepository _moduleRepository;
        public ProfesseurModuleService(IUnitOfWork unit) : base(unit.ProfesseurModules)
        {
            _professeurModuleRepository = unit.ProfesseurModules;
            _professeurRepository = unit.Professeurs;
            _moduleRepository = unit.Modules;
        }

        public IEnumerable<ProfesseurModule> GetModulesByProfesseur(int ProfesseurId)
        {
            if (ProfesseurId < 1 || _professeurRepository.Get(ProfesseurId) == null)
                return null;
            return _professeurModuleRepository.GetModulesByProfesseur(ProfesseurId);
        }

        public IEnumerable<ProfesseurModule> GetProfesseursByModule(int ModuleId)
        {
            if (ModuleId < 1 || _moduleRepository.Get(ModuleId) == null)
                return null;
            return _professeurModuleRepository.GetProfesseursByModule(ModuleId);
        }
    }
}
