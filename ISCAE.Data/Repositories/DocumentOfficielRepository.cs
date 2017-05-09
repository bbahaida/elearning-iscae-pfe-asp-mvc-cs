using System;
using System.Collections.Generic;
using System.Linq;

namespace ISCAE.Data.Repositories
{
    public class DocumentOfficielRepository : Repository<IscaeEntities, DocumentOfficiel>, IDocumentOfficielRepository
    {
        public IEnumerable<DocumentOfficiel> GetDocumentByModule(int ModuleId)
        {
            try
            {
                return Context.Set<DocumentOfficiel>().Where(o => o.ModuleId == ModuleId).OrderBy(o => o.ProfesseurId);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<DocumentOfficiel> GetDocumentByModule(int ModuleId, int pageIndex, int pageSize)
        {
            try
            {
                return Context.Set<DocumentOfficiel>().Where(o => o.ModuleId == ModuleId).OrderBy(o => o.ProfesseurId).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<DocumentOfficiel> GetDocumentByUser(int ProfesseurId)
        {
            try
            {
                return Context.Set<DocumentOfficiel>().Where(o => o.ProfesseurId == ProfesseurId).OrderBy(o => o.ModuleId);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<DocumentOfficiel> GetDocumentByUser(int ProfesseurId, int pageIndex, int pageSize)
        {
            try
            {
                return Context.Set<DocumentOfficiel>().Where(o => o.ProfesseurId == ProfesseurId).OrderBy(o => o.ModuleId).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }
    }
}
