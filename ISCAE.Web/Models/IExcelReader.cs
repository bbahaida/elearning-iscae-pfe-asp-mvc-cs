using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Web.Models
{
    public interface IExcelReader
    {
        List<Etudiant> Read(string path);
        void Insert(List<Etudiant> etudiants);
    }
}
