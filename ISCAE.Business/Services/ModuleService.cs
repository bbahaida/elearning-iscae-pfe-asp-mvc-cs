using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISCAE.Data.Repositories;

namespace ISCAE.Business.Services
{
    public class ModuleService : CommonService<Module>, IModuleService
    {
        private IModuleRepository _moduleRepository;
        public ModuleService(IModuleRepository repository) : base(repository)
        {
            _moduleRepository = repository;
        }
    }
}
