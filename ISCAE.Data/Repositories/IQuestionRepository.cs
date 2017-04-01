﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
        IEnumerable<Question> GetQuestionsByEtudiant(int EtudiantId, int pageIndex, int pageSize);
    }
}