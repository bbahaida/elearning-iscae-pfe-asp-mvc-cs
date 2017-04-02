using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ISCAE.Data.Repositories;
using System.Collections;
using ISCAE.Data;
using System.Collections.Generic;

namespace ISCAE.Tests
{
    [TestClass]
    public class AdministrateurTests
    {
        public readonly IAdministrateurRepository AdministrateurRepository;
        public AdministrateurTests()
        {
            IEnumerable<Administrateur> administrateurs = new List<Administrateur>
            {
                new Administrateur { AdministrateurId=1, Email="a@b.c", isActive=1, Login="ab", Nom="cd", Password="abcd", Telephone="3640" },
                new Administrateur { AdministrateurId=2, Email="b@c.d", isActive=1, Login="bc", Nom="de", Password="bcde", Telephone="3653" },
                new Administrateur { AdministrateurId=3, Email="c@d.e", isActive=1, Login="cd", Nom="ef", Password="cdef", Telephone="3643" },
                new Administrateur { AdministrateurId=4, Email="d@e.f", isActive=1, Login="de", Nom="fg", Password="defg", Telephone="3645" }
            };
            Mock<IAdministrateurRepository> mockAdministrateur = new Mock<IAdministrateurRepository>();
            
        }
        

        [TestMethod]
        public void Is_GetUserByAuth_Return_Single()
        {
            // eywe la5bar chnhi
        }
    }
}
