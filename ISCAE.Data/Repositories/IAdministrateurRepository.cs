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
        Administrateur GetUserByEmail(string email);
        Administrateur GetUserByTelephone(string telephone);
        IEnumerable<Administrateur> GetActiveUsers();
        IEnumerable<Administrateur> GetNonActiveUsers();


    }
}
