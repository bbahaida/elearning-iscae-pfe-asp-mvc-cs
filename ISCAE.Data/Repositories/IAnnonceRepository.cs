using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public interface IAnnonceRepository : IRepository<Annonce>
    {
        IEnumerable<Annonce> GetAnnoncesByAdministrateur(int AdministrateurId, int pageIndex, int pageSize);
    }
}
