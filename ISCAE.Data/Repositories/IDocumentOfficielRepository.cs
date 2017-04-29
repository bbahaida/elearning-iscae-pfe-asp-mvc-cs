using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public interface IDocumentOfficielRepository : IRepository<DocumentOfficiel>
    {
        IEnumerable<DocumentOfficiel> GetDocumentByUser(int ProfesseurId, int pageIndex, int pageSize);
        IEnumerable<DocumentOfficiel> GetDocumentByModule(int ModuleId, int pageIndex, int pageSize);
        IEnumerable<DocumentOfficiel> GetDocumentByUser(int ProfesseurId);
        IEnumerable<DocumentOfficiel> GetDocumentByModule(int ModuleId);
    }
}
