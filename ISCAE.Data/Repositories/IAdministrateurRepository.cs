using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public interface IAdministrateurRepository : IRepository<Administrateur>
    {
        Administrateur GetUserByAuth(string login, string password);
        Administrateur GetUserByLogin(string login);
        Administrateur GetUserByEmail(string login);
        Administrateur GetUserByTelephone(string login);
        IEnumerable<Administrateur> GetActiveUsers();
        IEnumerable<Administrateur> GetNonActiveUsers();


    }
}
