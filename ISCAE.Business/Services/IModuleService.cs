﻿using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Business.Services
{
    public interface IModuleService :ICommonService<Module>
    {
        Module GetByDesignation(string designation);
    }
}
