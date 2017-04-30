using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISCAE.Data.Repositories;

namespace ISCAE.Business.Services
{
    public class MessageService : CommonService<Message>, IMessageService
    {
        private IMessageRepository _messageRepository;
        private IProfesseurRepository _professeurRepository;
        private ISpecialiteRepository _specialiteRepository;
        public MessageService(IUnitOfWork unit) : base(unit.Messages)
        {
            _messageRepository = unit.Messages;
            _professeurRepository = unit.Professeurs;
            _specialiteRepository = unit.Specialites;
        }

        public IEnumerable<Message> GetMessagesByProfesseur(int ProfesseurId, int pageIndex, int pageSize)
        {
            if (ProfesseurId <= 0 || _professeurRepository.Get(ProfesseurId) == null || pageIndex <= 0 || pageSize <= 0)
                return null;
            return _messageRepository.GetMessagesByProfesseur(ProfesseurId,pageIndex,pageSize);
        }

        public IEnumerable<Message> GetMessagesByProfesseurAndSpecialite(int ProfesseurId, int SpecialiteId, int Niveau, int pageIndex, int pageSize)
        {
            if (ProfesseurId <= 0 || _professeurRepository.Get(ProfesseurId) == null || SpecialiteId <= 0 || _specialiteRepository.Get(SpecialiteId) == null || Niveau < 1 || Niveau > 3 || pageIndex <= 0 || pageSize <= 0)
                return null;
            return _messageRepository.GetMessagesByProfesseurAndSpecialite(ProfesseurId,SpecialiteId,Niveau, pageIndex, pageSize);
        }

        public IEnumerable<Message> GetMessagesBySpecialiteAndNiveau(int SpecialiteId, int Niveau, int pageIndex, int pageSize)
        {
            if (SpecialiteId <= 0 || _specialiteRepository.Get(SpecialiteId) == null || Niveau < 1 || Niveau > 3 || pageIndex <= 0 || pageSize <= 0)
                return null;
            return _messageRepository.GetMessagesBySpecialiteAndNiveau(SpecialiteId, Niveau, pageIndex, pageSize);
        }
    }
}
