using ISCAE.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IAdministrateurRepository Administarteurs { get; }
        IAnnonceRepository Annonces { get; }
    }
}
