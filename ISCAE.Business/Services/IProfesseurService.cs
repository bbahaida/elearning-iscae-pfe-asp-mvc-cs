﻿using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Business.Services
{
    public interface  IProfesseurService :ICommonService<Professeur>
    {
        Professeur GetUserByAuth(String login ,String password);
        Professeur GetUserByLogin(string login);
        Professeur GetUserByEmail(string email);
        Professeur GetUserByTelephone(string telephone);
        Professeur GetUserByNNI(int NNI);
        IEnumerable<Professeur> GetActiveUsers();
        IEnumerable<Professeur> GetNonActiveUsers();
    }
}
