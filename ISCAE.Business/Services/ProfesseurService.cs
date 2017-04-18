using ISCAE.Data;
using System.Collections.Generic;
using ISCAE.Data.Repositories;

namespace ISCAE.Business.Services
{
    public class ProfesseurService : CommonService<Professeur>, IProfesseurService
    {
        IProfesseurRepository _professeurRepository;
        public ProfesseurService(IProfesseurRepository repository) : base(repository)
        {
            _professeurRepository = repository;
        }

        public IEnumerable<Professeur> GetActiveUsers()
        {
            return _professeurRepository.GetActiveUsers();
        }

        public IEnumerable<Professeur> GetNonActiveUsers()
        {
            return _professeurRepository.GetNonActiveUsers();
        }

        public Professeur GetUserByAuth(string login, string password)
        {
            if (login.Equals("") || password.Equals(""))
                return null;
            return _professeurRepository.GetUserByAuth(login, password);
        }

        public Professeur GetUserByEmail(string email)
        {
            if (email.Equals(""))
                return null;
            return _professeurRepository.GetUserByEmail(email);
        }

        public Professeur GetUserByLogin(string login)
        {
            if (login.Equals(""))
                return null;
            return _professeurRepository.GetUserByLogin(login);
        }

        public Professeur GetUserByTelephone(string telephone)
        {
            if (telephone.Equals(""))
                return null;
            return _professeurRepository.GetUserByTelephone(telephone);
        }
    }
}
