using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public interface IEtudiantRepository : IRepository<Etudiant>
    {
        Etudiant GetUserByAuth(string login, string password);
        Etudiant GetUserByLogin(string login);
        Etudiant GetUserByMatricule(string matricule);
        Etudiant GetUserByEmail(string login);
        Etudiant GetUserByTelephone(string login);
        IEnumerable<Etudiant> GetActiveUsers();
        IEnumerable<Etudiant> GetNonActiveUsers();
        IEnumerable<Etudiant> GetEtudiantsBySpecialite(int SpecialiteId, int pageIndex, int pageSize, int Niveau=0);
        IEnumerable<Etudiant> GetEtudiantsByNiveau(int Niveau, int pageIndex, int pageSize);
    }
}
