using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISCAE.Data.Repositories;

namespace ISCAE.Business.Services
{
    public class DocumentOfficielService : CommonService<DocumentOfficiel>, IDocumentOfficielService
    {
        private IDocumentOfficielRepository _documentOfficielRepository;
        private IProfesseurRepository _professeurRepository;
        private IModuleRepository _moduleRepository;
        private ISpecialiteRepository _specialiteRepository;
        public DocumentOfficielService(IUnitOfWork unit) : base(unit.DocumentsOfficiel)
        {
            _documentOfficielRepository = unit.DocumentsOfficiel;
            _professeurRepository = unit.Professeurs;
            _moduleRepository = unit.Modules;
            _specialiteRepository = unit.Specialites; 
        }

        public IEnumerable<DocumentOfficiel> GetDocumentsByModule(int ModuleId, int pageIndex, int pageSize)
        {
            if (ModuleId < 1 || _moduleRepository.Get(ModuleId) == null || pageIndex < 0 || pageSize < 0)
                return null;
            if (pageIndex == 0 && pageSize == 0)
                return _documentOfficielRepository.GetAll().Where(o => o.ModuleId == ModuleId);
            return _documentOfficielRepository.GetDocumentByModule(ModuleId, pageIndex, pageSize);
        }

        public IEnumerable<DocumentOfficiel> GetDocumentsByUser(int ProfesseurId, int pageIndex, int pageSize)
        {
            if (ProfesseurId < 1 || _professeurRepository.Get(ProfesseurId) == null || pageIndex < 0 || pageSize < 0)
                return null;
            if (pageIndex == 0 && pageSize == 0)
                return _documentOfficielRepository.GetAll().Where(o => o.ProfesseurId == ProfesseurId);
            return _documentOfficielRepository.GetDocumentByUser(ProfesseurId, pageIndex, pageSize);
        }

        public Dictionary<Professeur, int> GetTopUsers(List<Professeur> profs)
        {
            if (profs.Count() == 0)
                return null;
            Dictionary<Professeur, int> list = new Dictionary<Professeur, int>();
            foreach (Professeur p in profs)
            {
                int count = _documentOfficielRepository.GetAll().Where(o => o.ProfesseurId == p.ProfesseurId).Count();
                if (count > 0)
                    list.Add(p,count);
            }
            return list.OrderByDescending(o => o.Value).Take(3).ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        public IEnumerable<DocumentOfficiel> GetDocumentsByUser(int ProfesseurId)
        {
            if (ProfesseurId < 1 || _professeurRepository.Get(ProfesseurId) == null)
                return null;
            
            return _documentOfficielRepository.GetDocumentByUser(ProfesseurId);
        }

        public IEnumerable<DocumentOfficiel> GetDocumentsByModule(int ModuleId)
        {
            if (ModuleId < 1 || _moduleRepository.Get(ModuleId) == null)
                return null;
            
            return _documentOfficielRepository.GetDocumentByModule(ModuleId);
        }
    }
}
