using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public interface IDocumentNonOfficielRepository : IRepository<DocumentNonOfficiel>
    {
        IEnumerable<DocumentNonOfficiel> GetDocumentByUser(int EtudiantId, int pageIndex, int pageSize);
        IEnumerable<DocumentNonOfficiel> GetDocumentByModule(int ModuleId, int Niveau, int pageIndex, int pageSize);
        IEnumerable<DocumentNonOfficiel> GetDocumentByModule(int ModuleId);
        IEnumerable<DocumentNonOfficiel> GetDocumentByUser(int EtudiantId);
    }
}
