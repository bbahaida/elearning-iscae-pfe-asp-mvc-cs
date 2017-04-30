using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISCAE.Data;
using ISCAE.Data.Repositories;

namespace ISCAE.Business.Services
{
    public class DocumentNonOfficielService : CommonService<DocumentNonOfficiel>, IDocumentNonOfficielService
    {
        private IDocumentNonOfficielRepository _documentNonOfficielRepository;
        private IEtudiantRepository _etudiantRepository;
        private IModuleRepository _moduleRepository;
        public DocumentNonOfficielService(IUnitOfWork unit) : base(unit.DocumentsNonOfficiel)
        {
            _documentNonOfficielRepository = unit.DocumentsNonOfficiel;
            _etudiantRepository = unit.Etudiants;
            _moduleRepository = unit.Modules;
        }

        public IEnumerable<DocumentNonOfficiel> GetDocumentByModule(int ModuleId)
        {
            if (ModuleId < 1 || _moduleRepository.Get(ModuleId) == null)
                return null;
            return _documentNonOfficielRepository.GetDocumentByModule(ModuleId);
        }

        public IEnumerable<DocumentNonOfficiel> GetDocumentByModule(int ModuleId, int Niveau, int pageIndex, int pageSize)
        {
            if (ModuleId < 1 || _moduleRepository.Get(ModuleId) ==null || Niveau < 1 || Niveau > 3 || pageIndex < 1 || pageSize < 1)
                return null;
            return _documentNonOfficielRepository.GetDocumentByModule(ModuleId,Niveau,pageIndex,pageSize);
        }

        public IEnumerable<DocumentNonOfficiel> GetDocumentByUser(int EtudiantId)
        {
            if (EtudiantId < 1 || _etudiantRepository.Get(EtudiantId) == null)
                return null;
            return _documentNonOfficielRepository.GetDocumentByUser(EtudiantId);
        }

        public IEnumerable<DocumentNonOfficiel> GetDocumentByUser(int EtudiantId, int pageIndex, int pageSize)
        {
            if (EtudiantId < 1 || _etudiantRepository.Get(EtudiantId) == null || pageIndex < 1 || pageSize < 1)
                return null;
            return _documentNonOfficielRepository.GetDocumentByUser(EtudiantId,pageIndex,pageSize);
        }
        

        public Dictionary<Etudiant, int> GetTopUsers(int SpecialiteId, int Niveau)
        {
            Dictionary<Etudiant, int> list = new Dictionary<Etudiant, int>();
            List<Etudiant> etudiants = _etudiantRepository.GetEtudiantsBySpecialite(SpecialiteId,Niveau).ToList();
            foreach (Etudiant e in etudiants)
            {
                int count = _documentNonOfficielRepository.GetAll().Where(o=>o.EtudiantId == e.EtudiantId).Count();
                if(count > 0)
                    list.Add(e, count);
            }
            return list.OrderByDescending(o => o.Value).Take(3).ToDictionary(pair => pair.Key, pair => pair.Value);
        }
        

        
    }
}
