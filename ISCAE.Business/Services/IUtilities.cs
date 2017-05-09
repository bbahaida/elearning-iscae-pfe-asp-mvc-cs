using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Business.Services
{
    public interface IUtilities
    {
        List<Etudiant> ReadExcel(string path);
        void InsertEtudiants(List<Etudiant> etudiants);
        string Hash(string input);
    }
}
