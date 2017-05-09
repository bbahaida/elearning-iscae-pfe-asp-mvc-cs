using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public class SpecialiteRepository : Repository<IscaeEntities, Specialite>, ISpecialiteRepository
    {
        public Specialite GetByDesignation(string designation)
        {
            try
            {
                return Context.Set<Specialite>().FirstOrDefault(o => o.Designation.ToLower().Equals(designation.ToLower()));
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }
    }
}
