using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISCAE.Data.Repositories;

namespace ISCAE.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAdministrateurRepository _administrateurRepository;
        private IAnnonceRepository _annonceRepository;

        public IAdministrateurRepository Administarteurs
        {
            get
            {
                if(_administrateurRepository == null)
                {
                    _administrateurRepository = new AdministrateurRepository();
                }
                return _administrateurRepository;
            }
        }

        public IAnnonceRepository Annonces
        {
            get
            {
                if (_annonceRepository == null)
                {
                    _annonceRepository = new AnnonceRepository();
                }
                return _annonceRepository;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
