using ISCAE.Data;
using System.Collections.Generic;
using ISCAE.Data.Repositories;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace ISCAE.Business.Services
{
    public class EtudiantService : CommonService<Etudiant>, IEtudiantService
    {
        private IEtudiantRepository _etudiantRepository;
        private ISpecialiteRepository _specialiteRepository;
        public EtudiantService(IUnitOfWork unit) : base(unit.Etudiants)
        {
            _etudiantRepository = unit.Etudiants;
            _specialiteRepository = unit.Specialites;
        }

        public IEnumerable<Etudiant> GetActiveUsers()
        {
            return _etudiantRepository.GetActiveUsers();
        }

        public IEnumerable<Etudiant> GetEtudiantsByNiveau(int Niveau)
        {
            if (Niveau <= 0 || Niveau > 3)
                return null;
            return _etudiantRepository.GetEtudiantsByNiveau(Niveau);
        }

        public IEnumerable<Etudiant> GetEtudiantsBySpecialite(int SpecialiteId, int Niveau)
        {
            if (SpecialiteId<=0 || _specialiteRepository.Get(SpecialiteId) == null || Niveau <= 0 || Niveau > 3)
                return null;
            return _etudiantRepository.GetEtudiantsBySpecialite(SpecialiteId, Niveau);
        }

        public IEnumerable<Etudiant> GetNonActiveUsers()
        {
            return _etudiantRepository.GetNonActiveUsers();
        }

        public Etudiant GetUserByAuth(string login, string password)
        {
            if (login.Equals("") || password.Equals("") || login == null || password == null)
                return null;
            return _etudiantRepository.GetUserByAuth(login, Hash("iscae" +password));
        }

        public Etudiant GetUserByEmail(string email)
        {
            if (email.Equals(""))
                return null;
            return _etudiantRepository.GetUserByEmail(email);
        }

        public Etudiant GetUserByLogin(string login)
        {
            if (login.Equals(""))
                return null;
            return _etudiantRepository.GetUserByLogin(login);
        }

        public Etudiant GetUserByMatricule(string matricule)
        {
            if (matricule.Equals(""))
                return null;
            return _etudiantRepository.GetUserByMatricule(matricule);
        }

        public Etudiant GetUserByNNI(string NNI)
        {
            if (NNI.Equals(""))
                return null;
            return _etudiantRepository.GetUserByNNI(NNI);
        }

        public Etudiant GetUserByTelephone(string telephone)
        {
            if (telephone.Equals(""))
                return null;
            return _etudiantRepository.GetUserByTelephone(telephone);
        }
        private static string Hash(string input)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }
    }
}
