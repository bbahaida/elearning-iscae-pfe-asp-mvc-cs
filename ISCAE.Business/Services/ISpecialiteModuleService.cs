using ISCAE.Data;
using System;
using System.Collections.Generic;

namespace ISCAE.Business.Services
{
    public interface ISpecialiteModuleService : ICommonService<SpecialiteModule>
    {
        IEnumerable<SpecialiteModule> GetSpecialiteModulesByNiveau(int SpecialiteId, int Niveau);
    }
}
