using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public class AdministrateurRepository : Repository<IscaeEntities, Administrateur>, IAdministrateurRepository
    {
        public IEnumerable<Administrateur> GetActiveUsers()
        {
            return Context.Set<Administrateur>().Where(o => o.isActive == 1).AsEnumerable();
        }

        public IEnumerable<Administrateur> GetNonActiveUsers()
        {
            return Context.Set<Administrateur>().Where(o => o.isActive == 0).AsEnumerable();
        }

        public Administrateur GetUserByAuth(string login, string password)
        {
            return Context.Set<Administrateur>().FirstOrDefault(o => o.Login.Equals(login) && o.Password.Equals(password));
        }

        public Administrateur GetUserByEmail(string email)
        {
            return Context.Set<Administrateur>().FirstOrDefault(o => o.Email.Equals(email) );
        }

        public Administrateur GetUserByLogin(string login)
        {
            return Context.Set<Administrateur>().FirstOrDefault(o => o.Login.Equals(login));
        }

        public Administrateur GetUserByTelephone(string telephone)
        {
            return Context.Set<Administrateur>().FirstOrDefault(o => o.Telephone.Equals(telephone));
        }
    }
}
