using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISCAE.Data.Repositories;

namespace ISCAE.Business.Services
{
    public class DocumentOfficieService : CommonService<DocumentOfficiel>, IDocumentOfficieService
    {
        private IDocumentOfficielRepository _documentOfficielRepository;
        private IProfesseurRepository _professeurRepository;
        private IModuleRepository _moduleRepository;
        public DocumentOfficieService(IDocumentOfficielRepository repository, IProfesseurRepository professeurRepository, IModuleRepository moduleRepository) : base(repository)
        {
            _documentOfficielRepository = repository;
            _professeurRepository = professeurRepository;
            _moduleRepository = moduleRepository;
        }

        public IEnumerable<DocumentOfficiel> GetDocumentByModule(int ModuleId, int pageIndex, int pageSize)
        {
            if (ModuleId < 1 || _moduleRepository.Get(ModuleId) == null || pageIndex < 1 || pageSize < 1)
                return null;
            return _documentOfficielRepository.GetDocumentByModule(ModuleId, pageIndex, pageSize);
        }

        public IEnumerable<DocumentOfficiel> GetDocumentByUser(int ProfesseurId, int pageIndex, int pageSize)
        {
            if (ProfesseurId < 1 || _professeurRepository.Get(ProfesseurId) == null || pageIndex < 1 || pageSize < 1)
                return null;
            return _documentOfficielRepository.GetDocumentByUser(ProfesseurId, pageIndex, pageSize);
        }
    }
}
