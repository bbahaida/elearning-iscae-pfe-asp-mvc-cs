using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public interface IProfesseurRepository : IRepository<Professeur>
    {
        Professeur GetUserByAuth(string login, string password);
        Professeur GetUserByLogin(string login);
        Professeur GetUserByEmail(string login);
        Professeur GetUserByTelephone(string login);
        IEnumerable<Professeur> GetActiveUsers();
        IEnumerable<Professeur> GetNonActiveUsers();
    }
}
