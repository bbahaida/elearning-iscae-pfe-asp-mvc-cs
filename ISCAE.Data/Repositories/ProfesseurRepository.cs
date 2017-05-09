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
            try
            {
                return Context.Set<Professeur>().Where(o => o.isActive == 1).AsEnumerable();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<Professeur> GetNonActiveUsers()
        {
            try
            {
                return Context.Set<Professeur>().Where(o => o.isActive == 0).AsEnumerable();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public Professeur GetUserByAuth(string login, string password)
        {
            try
            {
                return Context.Set<Professeur>().FirstOrDefault(o => o.Login.Equals(login) && o.Password.Equals(password) && o.isActive == 1);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public Professeur GetUserByEmail(string email)
        {
            try
            {
                return Context.Set<Professeur>().FirstOrDefault(o => o.Email.Equals(email));
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public Professeur GetUserByLogin(string login)
        {
            try
            {
                return Context.Set<Professeur>().FirstOrDefault(o => o.Login.Equals(login));
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public Professeur GetUserByTelephone(string telephone)
        {
            try
            {
                return Context.Set<Professeur>().FirstOrDefault(o => o.Telephone.Equals(telephone));
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }
    }
}
