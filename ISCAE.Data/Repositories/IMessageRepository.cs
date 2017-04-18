using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        IEnumerable<Message> GetMessagesByProfesseur(int ProfesseurId, int pageIndex, int pageSize);
        IEnumerable<Message> GetMessagesByProfesseurAndSpecialite(int ProfesseurId, int SpecialiteId,int Niveau,int pageIndex, int pageSize);
        IEnumerable<Message> GetMessagesBySpecialiteAndNiveau(int SpecialiteId, int Niveau, int pageIndex, int pageSize);
    }
}
