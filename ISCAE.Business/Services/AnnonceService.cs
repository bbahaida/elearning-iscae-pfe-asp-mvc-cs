using ISCAE.Data;
using ISCAE.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Business.Services
{
    public class AnnonceService : CommonService<Annonce>, IAnnonceService
    {
        IAnnonceRepository _annonceRepository;
        IAdministrateurRepository _administrateurRepository;
        public AnnonceService(IUnitOfWork unit) : base(unit.Annonces)
        {
            _annonceRepository = unit.Annonces;
            _administrateurRepository = unit.Administarteurs;
        }
        public IEnumerable<Annonce> GetAnnoncesByAdministrateur(int AdministrateurId, int pageIndex, int pageSize)
        {
            if(_administrateurRepository.Get(AdministrateurId) == null)
            {
                return null;
            }

            return _annonceRepository.GetAnnoncesByAdministrateur(AdministrateurId, pageIndex, pageSize);

        }
    }
}
