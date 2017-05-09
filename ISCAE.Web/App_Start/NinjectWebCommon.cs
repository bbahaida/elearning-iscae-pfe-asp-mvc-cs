[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ISCAE.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ISCAE.Web.App_Start.NinjectWebCommon), "Stop")]

namespace ISCAE.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Data.Repositories;
    using Business.Services;
    using Data;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                // ISCAE Dependencies
                // ISCAE.Data
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
                kernel.Bind<IAdministrateurRepository>().To<AdministrateurRepository>();
                kernel.Bind<IAnnonceRepository>().To<AnnonceRepository>();
                kernel.Bind<IDocumentNonOfficielRepository>().To<DocumentNonOfficielRepository>();
                kernel.Bind<IDocumentOfficielRepository>().To<DocumentOfficielRepository>();
                kernel.Bind<IEtudiantRepository>().To<EtudiantRepository>();
                kernel.Bind<IMessageRepository>().To<MessageRepository>();
                kernel.Bind<IModuleRepository>().To<ModuleRepository>();
                kernel.Bind<INotificationRepository>().To<NotificationRepository>();
                kernel.Bind<IProfesseurModuleRepository>().To<ProfesseurModuleRepository>();
                kernel.Bind<IProfesseurRepository>().To<ProfesseurRepository>();
                kernel.Bind<IProfesseurSpecialiteRepository>().To<ProfesseurSpecialiteRepository>();
                kernel.Bind<IQuestionRepository>().To<QuestionRepository>();
                kernel.Bind<IReponseRepository>().To<ReponseRepository>();
                kernel.Bind<IResultatRepository>().To<ResultatRepository>();
                kernel.Bind<ISpecialiteModuleRepository>().To<SpecialiteModuleRepository>();
                kernel.Bind<ISpecialiteRepository>().To<SpecialiteRepository>();

                // ISCAE.Business.Services
                kernel.Bind<IAdministrateurService>().To<AdministrateurService>();
                kernel.Bind<IAnnonceService>().To<AnnonceService>();
                kernel.Bind<IDocumentNonOfficielService>().To<DocumentNonOfficielService>();
                kernel.Bind<IDocumentOfficielService>().To<DocumentOfficielService>();
                kernel.Bind<IEtudiantService>().To<EtudiantService>();
                kernel.Bind<IMessageService>().To<MessageService>();
                kernel.Bind<IModuleService>().To<ModuleService>();
                kernel.Bind<INotificationService>().To<NotificationService>();
                kernel.Bind<IProfesseurModuleService>().To<ProfesseurModuleService>();
                kernel.Bind<IProfesseurService>().To<ProfesseurService>();
                kernel.Bind<IProfesseurSpecialiteService>().To<ProfesseurSpecialiteService>();
                kernel.Bind<IQuestionService>().To<QuestionService>();
                kernel.Bind<IReponseService>().To<ReponseService>();
                kernel.Bind<IResultatService>().To<ResultatService>();
                kernel.Bind<ISpecialiteModuleService>().To<SpecialiteModuleService>();
                kernel.Bind<ISpecialiteService>().To<SpecialiteService>();
                kernel.Bind<IUtilities>().To<Utilities>();

                //ISCAE.Web


                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
        }        
    }
}
