using ISCAE.Data;
using System.Collections.Generic;
using ISCAE.Data.Repositories;

namespace ISCAE.Business.Services
{
    public class EtudiantService : CommonService<Etudiant>, IEtudiantService
    {
        private IEtudiantRepository _etudiantRepository;
        private ISpecialiteRepository _specialiteRepository;
        public EtudiantService(IEtudiantRepository repository, ISpecialiteRepository specialiteRepository) : base(repository)
        {
            _etudiantRepository = repository;
            _specialiteRepository = specialiteRepository;
        }

        public IEnumerable<Etudiant> GetActiveUsers()
        {
            return _etudiantRepository.GetActiveUsers();
        }

        public IEnumerable<Etudiant> GetEtudiantsByNiveau(int Niveau, int pageIndex, int pageSize)
        {
            if (Niveau <= 0 || Niveau > 3 || pageIndex <= 0 || pageSize <= 0)
                return null;
            return _etudiantRepository.GetEtudiantsByNiveau(Niveau,pageIndex,pageSize);
        }

        public IEnumerable<Etudiant> GetEtudiantsBySpecialite(int SpecialiteId, int pageIndex, int pageSize, int Niveau)
        {
            if (SpecialiteId<=0 || _specialiteRepository.Get(SpecialiteId) == null || Niveau <= 0 || Niveau > 3 || pageIndex <= 0 || pageSize <= 0)
                return null;
            return _etudiantRepository.GetEtudiantsBySpecialite(SpecialiteId, pageIndex, pageSize,Niveau);
        }

        public IEnumerable<Etudiant> GetNonActiveUsers()
        {
            return _etudiantRepository.GetNonActiveUsers();
        }

        public Etudiant GetUserByAuth(string login, string password)
        {
            if (login.Equals("") || password.Equals(""))
                return null;
            return _etudiantRepository.GetUserByAuth(login, password);
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

        public Etudiant GetUserByNNI(int NNI)
        {
            if (NNI < 1)
                return null;
            return _etudiantRepository.GetUserByNNI(NNI);
        }

        public Etudiant GetUserByTelephone(string telephone)
        {
            if (telephone.Equals(""))
                return null;
            return _etudiantRepository.GetUserByTelephone(telephone);
        }
    }
}
