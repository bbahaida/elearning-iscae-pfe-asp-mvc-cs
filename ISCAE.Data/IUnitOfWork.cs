using ISCAE.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IAdministrateurRepository Administarteurs { get; }
        IAnnonceRepository Annonces { get; }
        IDocumentNonOfficielRepository DocumentsNonOfficiel { get; }
        IDocumentOfficielRepository DocumentsOfficiel { get; }
        IEtudiantRepository Etudiants { get; }
        IMessageRepository Messages { get; }
        IModuleRepository Modules { get; }
        INotificationRepository Notifications { get; }
        IProfesseurModuleRepository ProfesseurModules { get; }
        IProfesseurRepository Professeurs { get; }
        IProfesseurSpecialiteRepository ProfesseurSpecialites { get; }
        IQuestionRepository Questions { get; }
        IReponseRepository Reponses { get; }
        IResultatRepository Resultats { get; }
        ISpecialiteModuleRepository SpecialiteModules { get; }
        ISpecialiteRepository Specialites { get; }
        IEmploiRepository Emploi { get; }
        


    }
}
