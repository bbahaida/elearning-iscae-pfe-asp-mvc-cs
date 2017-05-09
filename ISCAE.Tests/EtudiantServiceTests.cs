using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ISCAE.Business.Services;
using ISCAE.Data.Repositories;
using FakeItEasy;
using ISCAE.Data;

namespace ISCAE.Tests
{
    [TestClass]
    public class EtudiantServiceTests
    {
        [TestMethod]
        public void Should_Etudiant_GetUserByAuth_Return_Single()
        {
            //var etudiantRepositoryMock = A.Fake<IEtudiantRepository>();
            //A.CallTo(() => etudiantRepositoryMock.GetUserByAuth("aaa", "bbb")).Returns(new Data.Etudiant
            //{
            //    EtudiantId = 1
            //});
            //var specialiteRepositoryMock = A.Fake<ISpecialiteRepository>();
            //IEtudiantService sut = new EtudiantService(new UnitOfWork(), new Utilities());
            //var id = sut.GetUserByAuth("bbahieda","Br@h!m0304").EtudiantId;
            
            //Assert.AreEqual(1, id);
        }
    }
}
