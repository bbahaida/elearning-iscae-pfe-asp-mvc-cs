using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ISCAE.Business.Services
{
    public interface IDocumentNonOfficielService : ICommonService<DocumentNonOfficiel>
    {
        IEnumerable<DocumentNonOfficiel> GetDocumentByUser(int EtudiantId, int pageIndex, int pageSize);
        IEnumerable<DocumentNonOfficiel> GetDocumentByModule(int ModuleId, int Niveau, int pageIndex, int pageSize);
        Dictionary<Etudiant, int> GetTopUsers(int SpecialiteId, int Niveau);
        IEnumerable<DocumentNonOfficiel> GetDocumentByModule(int ModuleId);
        IEnumerable<DocumentNonOfficiel> GetDocumentByUser(int EtudiantId);
    }
}
