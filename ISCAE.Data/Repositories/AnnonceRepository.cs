using System;
using System.Collections.Generic;
using System.Linq;

namespace ISCAE.Data.Repositories
{
    public class AnnonceRepository : Repository<IscaeEntities, Annonce>, IAnnonceRepository
    {
        public IEnumerable<Annonce> GetAnnoncesByAdministrateur(int AdministrateurId, int pageIndex, int pageSize)
        {
            try
            {
                return Context.Set<Annonce>().Where(o => o.AdministrateurId == AdministrateurId).OrderByDescending(o => o.AnnonceId).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }
    }
}
