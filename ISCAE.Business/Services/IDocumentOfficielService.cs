using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ISCAE.Business.Services
{
    public interface IDocumentOfficielService :ICommonService<DocumentOfficiel>
    {
        IEnumerable<DocumentOfficiel> GetDocumentByUser(int ProfesseurId, int pageIndex, int pageSize);
        IEnumerable<DocumentOfficiel> GetDocumentByModule(int ModuleId, int pageIndex, int pageSize);

    }
}
