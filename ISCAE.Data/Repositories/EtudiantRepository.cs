using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public class EtudiantRepository : Repository<IscaeEntities, Etudiant>, IEtudiantRepository
    {
        public IEnumerable<Etudiant> GetEtudiantsByNiveau(int Niveau, int pageIndex, int pageSize)
        {
            return Context.Set<Etudiant>().Where(o => o.Niveau == Niveau).OrderBy(o => o.Matricule).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Etudiant> GetEtudiantsBySpecialite(int SpecialiteId, int pageIndex, int pageSize, int Niveau)
        {
            return Context.Set<Etudiant>().Where(o => o.SpecialiteId == SpecialiteId && o.Niveau == Niveau).OrderBy(o => o.Matricule).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Etudiant> GetActiveUsers()
        {
            return Context.Set<Etudiant>().Where(o => o.isActive == 1).AsEnumerable();
        }

        public IEnumerable<Etudiant> GetNonActiveUsers()
        {
            return Context.Set<Etudiant>().Where(o => o.isActive == 0).AsEnumerable();
        }

        public Etudiant GetUserByAuth(string login, string password)
        {
            return Context.Set<Etudiant>().FirstOrDefault(o => o.Login.Equals(login) && o.Password.Equals(password));
        }

        public Etudiant GetUserByEmail(string email)
        {
            return Context.Set<Etudiant>().FirstOrDefault(o => o.Email.Equals(email));
        }

        public Etudiant GetUserByLogin(string login)
        {
            return Context.Set<Etudiant>().FirstOrDefault(o => o.Login.Equals(login));
        }

        public Etudiant GetUserByTelephone(string telephone)
        {
            return Context.Set<Etudiant>().FirstOrDefault(o => o.Telephone.Equals(telephone));
        }

        public Etudiant GetUserByMatricule(string matricule)
        {
            return Context.Set<Etudiant>().FirstOrDefault(o => o.Matricule.Equals(matricule));
        }
    }
}
