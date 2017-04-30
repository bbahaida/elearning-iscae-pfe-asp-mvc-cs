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
        public ModuleService(IUnitOfWork unit ) : base(unit.Modules)
        {
            _moduleRepository = unit.Modules;
        }
    }
}
