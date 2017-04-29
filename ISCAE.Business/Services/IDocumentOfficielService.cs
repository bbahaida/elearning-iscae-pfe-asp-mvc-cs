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
        IEnumerable<DocumentOfficiel> GetDocumentsByUser(int ProfesseurId, int pageIndex, int pageSize);
        IEnumerable<DocumentOfficiel> GetDocumentsByModule(int ModuleId, int pageIndex, int pageSize);
        IEnumerable<DocumentOfficiel> GetDocumentsByUser(int ProfesseurId);
        IEnumerable<DocumentOfficiel> GetDocumentsByModule(int ModuleId);
        Dictionary<Professeur, int> GetTopUsers(List<Professeur> profs);
    }
}
