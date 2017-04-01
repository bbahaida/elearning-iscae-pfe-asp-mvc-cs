using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public class DocumentOfficielRepository : Repository<IscaeEntities, DocumentOfficiel>, IDocumentOfficielRepository
    {
        public IEnumerable<DocumentOfficiel> GetDocumentByModule(int ModuleId, int pageIndex, int pageSize)
        {
            return Context.Set<DocumentOfficiel>().Where(o => o.ModuleId == ModuleId).OrderBy(o => o.ProfesseurId).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<DocumentOfficiel> GetDocumentByUser(int ProfesseurId, int pageIndex, int pageSize)
        {
            return Context.Set<DocumentOfficiel>().Where(o => o.ProfesseurId == ProfesseurId).OrderBy(o => o.ModuleId).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}
