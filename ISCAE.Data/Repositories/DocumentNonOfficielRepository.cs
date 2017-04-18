using System;
using System.Collections.Generic;
using System.Linq;

namespace ISCAE.Data.Repositories
{
    public class DocumentNonOfficielRepository : Repository<IscaeEntities, DocumentNonOfficiel>, IDocumentNonOfficielRepository
    {
        
        public IEnumerable<DocumentNonOfficiel> GetDocumentByModule(int ModuleId, int Niveau, int pageIndex, int pageSize)
        {
            try
            {
                return Context.Set<DocumentNonOfficiel>().Where(o => o.ModuleId == ModuleId && o.Etudiant.Niveau == Niveau).OrderBy(o => o.DocumentNonOfficielId).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            catch (Exception e)
            {
                //Logger.Error(e.Message);
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
                //Logger.Error(e.Message);
                return null;
            }
            
        }

        public IEnumerable<DocumentNonOfficiel> GetNonValidDocument(int pageIndex, int pageSize)
        {
            try
            {
                return Context.Set<DocumentNonOfficiel>().Where(o => o.isValid == 0).OrderByDescending(o => o.DocumentNonOfficielId).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            catch (Exception e)
            {
                //Logger.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<DocumentNonOfficiel> GetValidDocument(int pageIndex, int pageSize)
        {
            try
            {
                return Context.Set<DocumentNonOfficiel>().Where(o => o.isValid == 1).OrderByDescending(o => o.DocumentNonOfficielId).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            catch (Exception e)
            {
                //Logger.Error(e.Message);
                return null;
            }
        }
    }
}
