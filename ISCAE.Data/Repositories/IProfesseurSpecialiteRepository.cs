using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public interface IProfesseurSpecialiteRepository : IRepository<ProfesseurSpecialite>
    {
        IEnumerable<ProfesseurSpecialite> GetSpecialitesByProfesseur(int ProfesseurId);
        IEnumerable<ProfesseurSpecialite> GetProfesseursBySpecialite(int SpecialiteId);
        int GetId(int ProfesseurId, int SpecialiteId);
    }
}
