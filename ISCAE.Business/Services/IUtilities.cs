using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ISCAE.Business.Services
{
    public interface IUtilities
    {
        List<Etudiant> ReadExcel(string path);
        void InsertEtudiants(List<Etudiant> etudiants);
        XmlDocument ConvertHtmlToXml(string path);
        string Hash(string input);
    }
}
