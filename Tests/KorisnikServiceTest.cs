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
        private UserServices korisnikService;
        Mock<IRepository<User>> korisnikRepository = new Mock<IRepository<User>>();

        [TestInitialize]
        public void CreateInstances()
        {
            var user1 = new User()
            {
                Email = "prvi@prvi.com",
                Password = "test"
            };
            var user2 = new User()
            {
                Email = "drugi@prvi.com",
                Password = "test"
            };

            var userList = new List<User>() { user1, user2 };
            korisnikRepository.Setup(s => s.Query()).Returns(userList.AsQueryable);
            korisnikService = new UserServices(korisnikRepository.Object);
        }

        [TestMethod]
        public void Register()
        {
            var newUser = new User()
            {
                Email = "novi@emai.com",
                Password = "test"
            };
           var response =  korisnikService.Register(newUser);
            Assert.AreEqual(newUser.Email, response.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void RegisterExistingEmail()
        {
            var newUser = new User()
            {
                Email = "prvi@prvi.com",
                Password = "test"
            };
            var response = korisnikService.Register(newUser);
        }

        [TestMethod]
        public void Login()
        {
            var newUser = new User()
            {
                Email = "prvi@prvi.com",
                Password = "test"
            };
            var response = korisnikService.Login(newUser.Email,newUser.Password);
            Assert.AreEqual(newUser.Email, response.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void LoginFail()
        {
            var newUser = new User()
            {
                Email = "prvi@prvi.com",
                Password = "test"
            };
            var response = korisnikService.Register(newUser);
        }
    }
}
