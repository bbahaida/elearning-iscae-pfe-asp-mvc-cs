using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISCAE.Data.Repositories;

namespace ISCAE.Business.Services
{
    public class ProfesseurSpecialiteService : CommonService<ProfesseurSpecialite>, IProfesseurSpecialiteService
    {
        private IProfesseurSpecialiteRepository _professeurSpecialiteRepository;
        private IProfesseurRepository _professeurRepository;
        private ISpecialiteRepository _specialiteRepository;
        public ProfesseurSpecialiteService(IProfesseurSpecialiteRepository repository, IProfesseurRepository professeurRepository, ISpecialiteRepository specialiteRepository) : base(repository)
        {
            _professeurSpecialiteRepository = repository;
            _professeurRepository = professeurRepository;
            _specialiteRepository = specialiteRepository;
        }

        public IEnumerable<ProfesseurSpecialite> GetProfesseursBySpecialite(int SpecialiteId)
        {
            if (SpecialiteId < 1 || _specialiteRepository.Get(SpecialiteId) == null)
                return null;
            return _professeurSpecialiteRepository.GetProfesseursBySpecialite(SpecialiteId);
        }

        public IEnumerable<ProfesseurSpecialite> GetSpecialitesByProfesseur(int ProfesseurId)
        {
            if (ProfesseurId < 1 || _professeurRepository.Get(ProfesseurId) == null)
                return null;
            return _professeurSpecialiteRepository.GetSpecialitesByProfesseur(ProfesseurId);
        }
    }
}
