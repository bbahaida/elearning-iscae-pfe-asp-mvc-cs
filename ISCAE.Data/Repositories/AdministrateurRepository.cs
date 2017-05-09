using System;
using System.Collections.Generic;
using System.Linq;

namespace ISCAE.Data.Repositories
{
    public class AdministrateurRepository : Repository<IscaeEntities, Administrateur>, IAdministrateurRepository
    {
        public IEnumerable<Administrateur> GetActiveUsers()
        {
            try
            {
                return Context.Set<Administrateur>().Where(o => o.isActive == 1).AsEnumerable();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<Administrateur> GetNonActiveUsers()
        {
            try
            {
                return Context.Set<Administrateur>().Where(o => o.isActive == 0).AsEnumerable();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public Administrateur GetUserByAuth(string login, string password)
        {
            try
            {
                return Context.Set<Administrateur>().FirstOrDefault(o => o.Login.Equals(login) && o.Password.Equals(password) && o.isActive == 1);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
            
        }

        public Administrateur GetUserByEmail(string email)
        {
            try
            {
                return Context.Set<Administrateur>().FirstOrDefault(o => o.Email.Equals(email) );
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
            
        }

        public Administrateur GetUserByLogin(string login)
        {
            try
            {
                return Context.Set<Administrateur>().FirstOrDefault(o => o.Login.Equals(login));
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public Administrateur GetUserByTelephone(string telephone)
        {
            try
            {
                return Context.Set<Administrateur>().FirstOrDefault(o => o.Telephone.Equals(telephone));
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
            
        }
    }
}
