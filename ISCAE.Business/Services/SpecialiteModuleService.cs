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
        public SpecialiteModuleService(ISpecialiteModuleRepository repository, ISpecialiteRepository specialiteRepository) : base(repository)
        {
            _specialiteModuleRepository = repository;
            _specialiteRepository = specialiteRepository;
        }

        public IEnumerable<SpecialiteModule> GetSpecialiteModulesByNiveau(int SpecialiteId, int Niveau)
        {
            if (SpecialiteId < 1 || Niveau < 1 || Niveau > 3 || _specialiteRepository.Get(SpecialiteId) == null)
                return null;
            return _specialiteModuleRepository.GetSpecialiteModulesByNiveau(SpecialiteId,Niveau);
        }
    }
}
