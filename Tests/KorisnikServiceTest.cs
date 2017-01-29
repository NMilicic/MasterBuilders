using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Data.Domain;
using Business.Services;
using Moq;
using Data;
using System.Linq;
using Business.Exceptions;

namespace Tests
{
    [TestClass]
    public class KorisnikServiceTest
    {
        private KorisnikServices korisnikService;
        Mock<IRepository<Korisnik>> korisnikRepository = new Mock<IRepository<Korisnik>>();

        [TestInitialize]
        public void CreateInstances()
        {
            var user1 = new Korisnik()
            {
                Email = "prvi@prvi.com",
                Zaporka = "test"
            };
            var user2 = new Korisnik()
            {
                Email = "drugi@prvi.com",
                Zaporka = "test"
            };

            var userList = new List<Korisnik>() { user1, user2 };
            korisnikRepository.Setup(s => s.Query()).Returns(userList.AsQueryable);
            korisnikService = new KorisnikServices(korisnikRepository.Object);
        }

        [TestMethod]
        public void Register()
        {
            var newUser = new Korisnik()
            {
                Email = "novi@emai.com",
                Zaporka = "test"
            };
           var response =  korisnikService.Register(newUser);
            Assert.AreEqual(newUser.Email, response.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(KorisnikException))]
        public void RegisterExistingEmail()
        {
            var newUser = new Korisnik()
            {
                Email = "prvi@prvi.com",
                Zaporka = "test"
            };
            var response = korisnikService.Register(newUser);
        }

        [TestMethod]
        public void Login()
        {
            var newUser = new Korisnik()
            {
                Email = "prvi@prvi.com",
                Zaporka = "test"
            };
            var response = korisnikService.Login(newUser.Email,newUser.Zaporka);
            Assert.AreEqual(newUser.Email, response.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(KorisnikException))]
        public void LoginFail()
        {
            var newUser = new Korisnik()
            {
                Email = "prvi@prvi.com",
                Zaporka = "test"
            };
            var response = korisnikService.Register(newUser);
        }
    }
}
