using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;
using ISCAE.Data;
using ISCAE.Business.Services;

namespace ISCAE.Web.Models
{
    public class ExcelReader : IExcelReader
    {
        private ISpecialiteService _specialiteService;
        private IEtudiantService _etudiantService;
        public ExcelReader(ISpecialiteService specialiteService, IEtudiantService etudiantService)
        {
            _specialiteService = specialiteService;
            _etudiantService = etudiantService;
        }

        public void Insert(List<Etudiant> etudiants)
        {
            List<Etudiant> allEtudiant = _etudiantService.GetAll().ToList();
            
            foreach (Etudiant etudiant in etudiants)
            {
                if (_etudiantService.GetUserByMatricule(etudiant.Matricule) == null)
                {
                    _etudiantService.Add(etudiant);
                }
                else 
                {
                    _etudiantService.Edit(etudiant);
                }
            }

            foreach (Etudiant etudiant in allEtudiant)
            {
                if (etudiants.Find(o => o.Matricule == etudiant.Matricule) == null)
                {
                    etudiant.isActive = 0;
                    _etudiantService.Edit(etudiant);
                }
            }
        }

        public List<Etudiant> Read(string path)
        {
            
            List<Etudiant> etudiants = new List<Etudiant>();

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 1; i <= rowCount; i++)
            {
                Etudiant e = new Etudiant
                {
                    isActive = 0,
                    Matricule = xlRange.Cells[i, 1].Value2.ToString(),
                    Nom = xlRange.Cells[i, 2].Value2,
                    SpecialiteId = (_specialiteService.GetByDesignation(xlRange.Cells[i, 3].Value2)).SpecialiteId,
                    Niveau = (byte)xlRange.Cells[i, 4].Value2
                };

                etudiants.Add(e);
            }

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();
            

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            return etudiants;
        }
    }
}