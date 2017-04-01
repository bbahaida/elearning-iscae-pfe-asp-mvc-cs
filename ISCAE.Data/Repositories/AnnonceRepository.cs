using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    class AnnonceRepository : Repository<IscaeEntities, Annonce>, IAnnonceRepository
    {
        public IEnumerable<Annonce> GetAnnoncesByAdministrateur(int AdministrateurId, int pageIndex, int pageSize)
        {
            return Context.Set<Annonce>().Where(o => o.AdministrateurId == AdministrateurId).OrderByDescending(o => o.AnnonceId).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}
