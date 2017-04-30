using ISCAE.Data;
using System.Collections.Generic;
using ISCAE.Data.Repositories;

namespace ISCAE.Business.Services
{
    public class AdministrateurService : CommonService<Administrateur>, IAdministrateurService
    {
        IAdministrateurRepository _administrateurRepository;
        public AdministrateurService(IUnitOfWork unit) : base(unit.Administarteurs)
        {
            _administrateurRepository = unit.Administarteurs;
        }

        public IEnumerable<Administrateur> GetActiveUsers()
        {
            return _administrateurRepository.GetActiveUsers();
        }

        public IEnumerable<Administrateur> GetNonActiveUsers()
        {
            return _administrateurRepository.GetNonActiveUsers();
        }

        public Administrateur GetUserByAuth(string login, string password)
        {
            if (login.Equals("") || password.Equals(""))
                return null;
            return _administrateurRepository.GetUserByAuth(login, password);
        }

        public Administrateur GetUserByEmail(string email)
        {
            if (email.Equals(""))
                return null;
            return _administrateurRepository.GetUserByEmail(email);
        }

        public Administrateur GetUserByLogin(string login)
        {
            if (login.Equals(""))
                return null;
            return _administrateurRepository.GetUserByLogin(login);
        }

        public Administrateur GetUserByTelephone(string telephone)
        {
            if (telephone.Equals(""))
                return null;
            return _administrateurRepository.GetUserByTelephone(telephone);
        }
    }
}
