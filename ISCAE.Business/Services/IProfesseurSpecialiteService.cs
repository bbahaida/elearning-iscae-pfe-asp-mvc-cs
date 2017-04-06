﻿using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Business.Services
{
    public interface IProfesseurSpecialiteService : ICommonService<ProfesseurSpecialite>
    {
        IEnumerable<SpecialiteModule> GetSpecialiteModuleByNiveau(int specialiteId ,int Niveau);
    }
}
