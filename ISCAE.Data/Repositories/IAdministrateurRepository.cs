
using System.Collections.Generic;
namespace ISCAE.Data.Repositories
{
    public interface IAdministrateurRepository : IRepository<Administrateur>
    {
        Administrateur GetUserByAuth(string login, string password);
        Administrateur GetUserByLogin(string login);
        Administrateur GetUserByEmail(string email);
        Administrateur GetUserByTelephone(string telephone);
        Administrateur GetUserByNNI(int NNI);
        IEnumerable<Administrateur> GetActiveUsers();
        IEnumerable<Administrateur> GetNonActiveUsers();


    }
}
