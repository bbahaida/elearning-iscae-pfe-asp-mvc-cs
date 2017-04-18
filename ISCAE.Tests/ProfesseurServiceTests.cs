using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ISCAE.Business.Services;
using ISCAE.Data.Repositories;
using ISCAE.Data;
using System.Collections.Generic;

namespace ISCAE.Tests
{
    [TestClass]
    public class ProfesseurServiceTests
    {
        [TestMethod]
        public void Should_GetProfesseursBySpecialiteAndNiveau_Return_Specific_Profs()
        {
            IProfesseurService sut = new ProfesseurService(new ProfesseurRepository(), new ProfesseurModuleRepository(), new ModuleRepository(),new ProfesseurSpecialiteRepository(), new SpecialiteModuleRepository());
            Dictionary<Module, Professeur> profs = sut.GetProfesseursBySpecialiteAndNiveau(4,2);
            Assert.AreEqual(1, profs.Count);
        }
    }
}
