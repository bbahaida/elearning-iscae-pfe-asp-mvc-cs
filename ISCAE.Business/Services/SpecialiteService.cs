using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISCAE.Data.Repositories;

namespace ISCAE.Business.Services
{
    public class SpecialiteService : CommonService<Specialite>, ISpecialiteService
    {
        private ISpecialiteRepository _specialiteRepository;
        public SpecialiteService(IUnitOfWork unit) : base(unit.Specialites)
        {
            _specialiteRepository = unit.Specialites;
        }

        public Specialite GetByDesignation(string designation)
        {
            if (designation == null || designation.Equals(""))
                return null;
            return _specialiteRepository.GetByDesignation(designation);
        }
    }
}
