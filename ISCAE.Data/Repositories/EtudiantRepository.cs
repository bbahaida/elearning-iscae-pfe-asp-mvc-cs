using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ISCAE.Data.Repositories
{
    public class EtudiantRepository : Repository<IscaeEntities, Etudiant>, IEtudiantRepository
    {
        
        public IEnumerable<Etudiant> GetEtudiantsByNiveau(int Niveau)
        {
            try
            {
                return Context.Set<Etudiant>().Where(o => o.Niveau == Niveau).OrderBy(o => o.Matricule);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<Etudiant> GetEtudiantsBySpecialite(int SpecialiteId, int Niveau)
        {
            try
            {
                return Context.Set<Etudiant>().Where(o => o.SpecialiteId == SpecialiteId && o.Niveau == Niveau).OrderBy(o => o.Matricule);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<Etudiant> GetActiveUsers()
        {
            try
            {
                return Context.Set<Etudiant>().Where(o => o.isActive == 1).AsEnumerable();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<Etudiant> GetNonActiveUsers()
        {
            try
            {
                return Context.Set<Etudiant>().Where(o => o.isActive == 0).AsEnumerable();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public Etudiant GetUserByAuth(string login, string password)
        {
            try
            {
                return Context.Set<Etudiant>().FirstOrDefault(o => o.Login.Equals(login) && o.Password.Equals(password) && o.isActive == 1);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public Etudiant GetUserByEmail(string email)
        {
            try
            {
                return Context.Set<Etudiant>().FirstOrDefault(o => o.Email.Equals(email));
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public Etudiant GetUserByLogin(string login)
        {
            try
            {
                return Context.Set<Etudiant>().FirstOrDefault(o => o.Login.Equals(login));
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public Etudiant GetUserByTelephone(string telephone)
        {
            try
            {
                return Context.Set<Etudiant>().FirstOrDefault(o => o.Telephone.Equals(telephone));
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public Etudiant GetUserByMatricule(string matricule)
        {
            try
            {
                return Context.Set<Etudiant>().FirstOrDefault(o => o.Matricule.Equals(matricule));
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public Etudiant GetUserByNNI(string NNI)
        {
            try
            {
                return Context.Set<Etudiant>().FirstOrDefault(o => o.NNI.Equals(NNI));
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }
    }
}
