using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISCAE.Data.Repositories;

namespace ISCAE.Business.Services
{
    public class AdministrateurService : CommonService<Administrateur>, IAdministrateurService
    {
        IAdministrateurRepository _administrateurRepository;
        public AdministrateurService(IAdministrateurRepository repository) : base(repository)
        {
            _administrateurRepository = repository;
        }

        public IEnumerable<Administrateur> GetActiveUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Administrateur> GetNonActiveUsers()
        {
            throw new NotImplementedException();
        }

        public Administrateur GetUserByAuth(string login, string password)
        {
            throw new NotImplementedException();
        }

        public Administrateur GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Administrateur GetUserByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public Administrateur GetUserByTelephone(string telephone)
        {
            throw new NotImplementedException();
        }
    }
}
