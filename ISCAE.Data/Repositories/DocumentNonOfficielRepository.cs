using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public class DocumentNonOfficielRepository : Repository<IscaeEntities, DocumentNonOfficiel>, IDocumentNonOfficielRepository
    {
        public IEnumerable<DocumentNonOfficiel> GetDocumentByModule(int ModuleId, int pageIndex, int pageSize)
        {
            return Context.Set<DocumentNonOfficiel>().Where(o=>o.ModuleId == ModuleId).OrderBy(o=>o.ModuleId).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<DocumentNonOfficiel> GetDocumentByUser(int EtudiantId, int pageIndex, int pageSize)
        {
            return Context.Set<DocumentNonOfficiel>().Where(o => o.EtudiantId == EtudiantId).OrderBy(o => o.ModuleId).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<DocumentNonOfficiel> GetNonValidDocument(int pageIndex, int pageSize)
        {
            return Context.Set<DocumentNonOfficiel>().Where(o=>o.isValid == 0).OrderByDescending(o=>o.DocumentNonOfficielId).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}
