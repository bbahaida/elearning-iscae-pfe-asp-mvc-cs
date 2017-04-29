using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public interface ISpecialiteRepository : IRepository<Specialite>
    {
        Specialite GetByDesignation(string designation);
    }
}
