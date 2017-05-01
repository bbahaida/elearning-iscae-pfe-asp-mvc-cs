using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ISCAE.Business.Services;
using ISCAE.Data.Repositories;
using ISCAE.Data;

namespace ISCAE.Tests
{
    [TestClass]
    public class SpecialiteModuleTests
    {
        [TestMethod]
        public void Should_GetNiveauBySpecialiteAndModule_Return_int()
        {
            ISpecialiteModuleService sut = new SpecialiteModuleService(new UnitOfWork());
            int n = sut.GetNiveauBySpecialiteAndModule(4,5);
            Assert.AreEqual(2,n);
        }
    }
}
