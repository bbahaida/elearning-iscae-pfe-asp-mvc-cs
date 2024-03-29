﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public interface IModuleRepository : IRepository<Module>
    {
        Module GetByDesignation(string designation);
    }
}
