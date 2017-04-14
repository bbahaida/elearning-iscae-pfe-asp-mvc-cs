using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISCAE.Data;
using ISCAE.Data.Repositories;

namespace ISCAE.Business.Services
{
    public class DocumentNonOfficieService : CommonService<DocumentNonOfficiel>, IDocumentNonOfficieService
    {
        private IDocumentNonOfficielRepository _documentNonOfficielRepository;
        private IEtudiantRepository _etudiantRepository;
        private IModuleRepository _moduleRepository;
        public DocumentNonOfficieService(IDocumentNonOfficielRepository repository, IEtudiantRepository etudiantRepository, IModuleRepository moduleRepository) : base(repository)
        {
            _documentNonOfficielRepository = repository;
            _etudiantRepository = etudiantRepository;
            _moduleRepository = moduleRepository;
        }

        public IEnumerable<DocumentNonOfficiel> GetDocumentByModule(int ModuleId, int Niveau, int pageIndex, int pageSize)
        {
            if (ModuleId < 1 || _moduleRepository.Get(ModuleId) ==null || Niveau < 1 || Niveau > 3 || pageIndex < 1 || pageSize < 1)
                return null;
            return _documentNonOfficielRepository.GetDocumentByModule(ModuleId,Niveau,pageIndex,pageSize);
        }

        public IEnumerable<DocumentNonOfficiel> GetDocumentByUser(int EtudiantId, int pageIndex, int pageSize)
        {
            if (EtudiantId < 1 || _etudiantRepository.Get(EtudiantId) == null || pageIndex < 1 || pageSize < 1)
                return null;
            return _documentNonOfficielRepository.GetDocumentByUser(EtudiantId,pageIndex,pageSize);
        }

        public IEnumerable<DocumentNonOfficiel> GetNonValidDocument(int pageIndex, int pageSize)
        {
            if (pageIndex < 1 || pageSize < 1)
                return null;
            return _documentNonOfficielRepository.GetNonValidDocument(pageIndex,pageSize);
        }
    }
}
