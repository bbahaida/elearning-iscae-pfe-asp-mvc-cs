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
        Etudiant GetUserByEmail(string email);
        Etudiant GetUserByTelephone(string telephone);
        Etudiant GetUserByNNI(string NNI);
        IEnumerable<Etudiant> GetActiveUsers();
        IEnumerable<Etudiant> GetNonActiveUsers();
        IEnumerable<Etudiant> GetEtudiantsBySpecialite(int SpecialiteId, int Niveau);
        IEnumerable<Etudiant> GetEtudiantsByNiveau(int Niveau);
    }
}
