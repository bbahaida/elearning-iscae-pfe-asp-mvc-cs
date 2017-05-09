using System;
using System.Collections.Generic;
using System.Linq;

namespace ISCAE.Data.Repositories
{
    public class DocumentNonOfficielRepository : Repository<IscaeEntities, DocumentNonOfficiel>, IDocumentNonOfficielRepository
    {
        public IEnumerable<DocumentNonOfficiel> GetDocumentByModule(int ModuleId)
        {
            try
            {
                return Context.Set<DocumentNonOfficiel>().Where(o => o.ModuleId == ModuleId).OrderBy(o => o.DocumentNonOfficielId);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<DocumentNonOfficiel> GetDocumentByModule(int ModuleId, int Niveau, int pageIndex, int pageSize)
        {
            try
            {
                return Context.Set<DocumentNonOfficiel>().Where(o => o.ModuleId == ModuleId && o.Etudiant.Niveau == Niveau).OrderBy(o => o.DocumentNonOfficielId).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<DocumentNonOfficiel> GetDocumentByUser(int EtudiantId)
        {
            try
            {
                return Context.Set<DocumentNonOfficiel>().Where(o => o.EtudiantId == EtudiantId).OrderBy(o => o.ModuleId);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<DocumentNonOfficiel> GetDocumentByUser(int EtudiantId, int pageIndex, int pageSize)
        {
            try
            {
                return Context.Set<DocumentNonOfficiel>().Where(o => o.EtudiantId == EtudiantId).OrderBy(o => o.ModuleId).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
            
        }
        
    }
}
