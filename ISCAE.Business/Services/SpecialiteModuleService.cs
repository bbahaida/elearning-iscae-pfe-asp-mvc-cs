using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISCAE.Data.Repositories;

namespace ISCAE.Business.Services
{
    public class SpecialiteModuleService : CommonService<SpecialiteModule>, ISpecialiteModuleService
    {
        private ISpecialiteModuleRepository _specialiteModuleRepository;
        private ISpecialiteRepository _specialiteRepository;
        public SpecialiteModuleService(IUnitOfWork unit) : base(unit.SpecialiteModules)
        {
            _specialiteModuleRepository = unit.SpecialiteModules;
            _specialiteRepository = unit.Specialites;
        }

        public int GetNiveauBySpecialiteAndModule(int SpecialiteId, int ModuleId)
        {
            int Niveau = 0;
            var module = _specialiteModuleRepository.GetSpecialiteModulesByModule(ModuleId).ToList().Find(o=>o.SpecialiteId == SpecialiteId);

            if (module != null)
            {
                Niveau = module.Niveau;
            }
            return Niveau;
        }

        public IEnumerable<SpecialiteModule> GetSpecialiteModulesByNiveau(int SpecialiteId, int Niveau)
        {
            if (SpecialiteId < 1 || Niveau < 1 || Niveau > 3 || _specialiteRepository.Get(SpecialiteId) == null)
                return null;
            return _specialiteModuleRepository.GetSpecialiteModulesByNiveau(SpecialiteId,Niveau);
        }

        public IEnumerable<SpecialiteModule> GetSpecialiteModulesBySpecialite(int SpecialiteId)
        {
            if (SpecialiteId < 1 || _specialiteRepository.Get(SpecialiteId) == null)
                return null;
            return _specialiteModuleRepository.GetSpecialiteModulesBySpecialite(SpecialiteId);
        }
    }
}
