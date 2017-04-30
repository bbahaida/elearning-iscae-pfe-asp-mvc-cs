using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISCAE.Data.Repositories;

namespace ISCAE.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAdministrateurRepository _administrateurRepository;
        private IAnnonceRepository _annonceRepository;
        private IDocumentNonOfficielRepository _documentNonOfficielRepository;
        private IDocumentOfficielRepository _documentOfficielRepository;
        private IEtudiantRepository _etudiantRepository;
        private IMessageRepository _messageRepository;
        private IModuleRepository _moduleRepository;
        private INotificationRepository _notificationRepository;
        private IProfesseurModuleRepository _professeurModuleRepository;
        private IProfesseurRepository _professeurRepository;
        private IProfesseurSpecialiteRepository _professeurSpecialiteRepository;
        private IQuestionRepository _questionRepository;
        private IReponseRepository _reponseRepository;
        private IResultatRepository _resultatRepository;
        private ISpecialiteModuleRepository _specialiteModuleRepository;
        private ISpecialiteRepository _specialiteRepository;
        private IEmploiRepository _emploiRepository;

        public IAdministrateurRepository Administarteurs
        {
            get
            {
                if(_administrateurRepository == null)
                {
                    _administrateurRepository = new AdministrateurRepository();
                }
                return _administrateurRepository;
            }
        }

        public IAnnonceRepository Annonces
        {
            get
            {
                if (_annonceRepository == null)
                {
                    _annonceRepository = new AnnonceRepository();
                }
                return _annonceRepository;
            }
        }

        public IDocumentNonOfficielRepository DocumentsNonOfficiel
        {
            get
            {
                if (_documentNonOfficielRepository == null)
                {
                    _documentNonOfficielRepository = new DocumentNonOfficielRepository();

                }
                return _documentNonOfficielRepository;
                
            }
        }

        public IDocumentOfficielRepository DocumentsOfficiel
        {
            get
            {
                if (_documentOfficielRepository == null)
                    _documentOfficielRepository = new DocumentOfficielRepository();
                return _documentOfficielRepository;
            }
           
        }

        public IEmploiRepository Emploi
        {
            get
            {
                if (_emploiRepository == null)
                    _emploiRepository = null;
                return _emploiRepository;
            }
        }

        public IEtudiantRepository Etudiants
        {
            get
            {
                if (_etudiantRepository == null)
                    _etudiantRepository = new EtudiantRepository();
                return _etudiantRepository;
            }
        }

        public IMessageRepository Messages
        {
            get
            {
                if (_messageRepository == null)
                    _messageRepository = new MessageRepository();
                return _messageRepository;
            }
        }

        public IModuleRepository Modules
        {
            get
            {
                if (_moduleRepository == null)
                    _moduleRepository = new ModuleRepository();
                return _moduleRepository;
            }
        }

        public INotificationRepository Notifications
        {
            get
            {
                if (_notificationRepository == null)
                    _notificationRepository = new NotificationRepository();
                return _notificationRepository;
            }
        }

        public IProfesseurModuleRepository ProfesseurModules
        {
            get
            {
                if (_professeurModuleRepository == null)
                    _professeurModuleRepository = new ProfesseurModuleRepository();
                return _professeurModuleRepository;
            }
        }

        public IProfesseurRepository Professeurs
        {
            get
            {
                if (_professeurRepository == null)
                    _professeurRepository = new ProfesseurRepository();
                return _professeurRepository;
            }
        }

        public IProfesseurSpecialiteRepository ProfesseurSpecialites
        {
            get
            {
                if (_professeurSpecialiteRepository == null)
                    _professeurSpecialiteRepository = new ProfesseurSpecialiteRepository();
                return _professeurSpecialiteRepository;
            }
        }

        public IQuestionRepository Questions
        {
            get
            {
                if (_questionRepository == null)
                    _questionRepository = new QuestionRepository();
                return _questionRepository;
            }
        }

        public IReponseRepository Reponses
        {
            get
            {
                if (_reponseRepository == null)
                    _reponseRepository = new ReponseRepository();
                return _reponseRepository;
            }
        }

        public IResultatRepository Resultats
        {
            get
            {
                if (_resultatRepository == null)
                    _resultatRepository = new ResultatRepository();
                return _resultatRepository;
            }
        }

        public ISpecialiteModuleRepository SpecialiteModules
        {
            get
            {
                if (_specialiteModuleRepository == null)
                    _specialiteModuleRepository = new SpecialiteModuleRepository();
                return _specialiteModuleRepository;
            }
        }

        public ISpecialiteRepository Specialites
        {
            get
            {
                if (_specialiteRepository == null)
                    _specialiteRepository = new SpecialiteRepository();
                return _specialiteRepository;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
