using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public class ProfesseurRepository : Repository<IscaeEntities, Professeur>, IProfesseurRepository
    {
        public IEnumerable<Professeur> GetActiveUsers()
        {
            return Context.Set<Professeur>().Where(o => o.isActive == 1).AsEnumerable();
        }

        public IEnumerable<Professeur> GetNonActiveUsers()
        {
            return Context.Set<Professeur>().Where(o => o.isActive == 0).AsEnumerable();
        }

        public Professeur GetUserByAuth(string login, string password)
        {
            return Context.Set<Professeur>().FirstOrDefault(o => o.Login.Equals(login) && o.Password.Equals(password));
        }

        public Professeur GetUserByEmail(string email)
        {
            return Context.Set<Professeur>().FirstOrDefault(o => o.Email.Equals(email));
        }

        public Professeur GetUserByLogin(string login)
        {
            return Context.Set<Professeur>().FirstOrDefault(o => o.Login.Equals(login));
        }

        public Professeur GetUserByTelephone(string telephone)
        {
            return Context.Set<Professeur>().FirstOrDefault(o => o.Telephone.Equals(telephone));
        }
    }
}
