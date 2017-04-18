using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Business.Services
{
    public interface IMessageService :ICommonService<Message>
    {
        IEnumerable<Message> GetMessagesByProfesseur(int ProfesseurId, int pageIndex, int pageSize);
        IEnumerable<Message> GetMessagesByProfesseurAndSpecialite(int ProfesseurId ,int SpecialiteId ,int Niveau ,int pageIndex,int pageSize);
        IEnumerable<Message> GetMessagesBySpecialiteAndNiveau(int SpecialiteId, int Niveau, int pageIndex, int pageSize);

    }
}
