using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Domain;
using Business.Services;
using Data;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Business.Exceptions;

namespace Tests
{
    [TestClass]
    public class LSetServiceTest
    {
        private LSetService setService;
        private List<LSet> setovi;

        Mock<IRepository<LSet>> setRepository = new Mock<IRepository<LSet>>();
        Mock<IRepository<Wishlist>> wishlistRepository = new Mock<IRepository<Wishlist>>();
        Mock<IRepository<User>> korisnikRepository = new Mock<IRepository<User>>();
        Mock<IRepository<UserLSet>> inventroyRepository = new Mock<IRepository<UserLSet>>();
        Mock<IRepository<LSetPart>> dijeloviRepository = new Mock<IRepository<LSetPart>>();

        private void IniData()
        {
            var kategorija1 = new Category()
            {
                Id = 1,
                Name = "kat 1"
            };

            var kockica1 = new Part()
            {
                Name = "Kockica 1",
                Category = kategorija1
            };
            var kockica2 = new Part()
            {
                Name = "Kockica 2",
                Category = kategorija1
            };
            var kockica3 = new Part()
            {
                Name = "Kockica 3",
                Category = kategorija1
            };
            var kockica4 = new Part()
            {
                Name = "Kockica 4",
                Category = kategorija1
            };

            var boja1 = new Color()
            {
                Id = 1,
                Name = "Plava"
            };

            var boja2 = new Color()
            {
                Id = 2,
                Name = "Zelena"
            };

            var tema1 = new Theme()
            {
                Name = "Tema 1"
            };
            var tema2 = new Theme()
            {
                Name = "Tema 2"
            };
            var tema3 = new Theme()
            {
                Name = "Tema 3",
                BaseTheme = tema1
            };

            var set1 = new LSet()
            {
                Id = 1,
                Name = "Set 1",
                NumberOfParts = 5,
                Theme = tema3
            };


            var dijelovi1 = new List<LSetPart>() {  new LSetPart()
            {
                Color = boja1,
                Part = kockica1,
                Number = 1,
                LSet = set1
            },
             new LSetPart()
            {
                Color = boja1,
                Part = kockica2,
                Number = 1,
                LSet = set1
            }};

            set1.LSetParts = dijelovi1;

            var set2 = new LSet()
            {
                Id = 2,
                Name = "Set 2",
                LSetParts = new List<LSetPart>(),
                NumberOfParts = 35,
                Theme = tema2
            };

            set2.LSetParts = new List<LSetPart>() {
                new LSetPart()
            {
                Color = boja1,
                Part = kockica2,
                Number = 1,
                LSet = set2
            }};

            var set3 = new LSet()
            {
                Id = 3,
                Name = "Set 3",
                NumberOfParts = 100,
                Theme = tema2
            };

            var dijelovi3 = new List<LSetPart>() {  new LSetPart()
            {
                Color = boja2,
                Part = kockica1,
                Number = 1,
                LSet = set3
            },
             new LSetPart()
            {
                Color = boja2,
                Part = kockica2,
                Number = 1,
                LSet = set3
            }};

            set3.LSetParts = dijelovi3;

            setovi = new List<LSet>() { set1, set2, set3 };
        }

        [TestInitialize]
        public void CreateInstances()
        {
            IniData();

            setRepository.Setup(s => s.Query()).Returns(setovi.AsQueryable);

            setService = new LSetService(
                setRepository.Object,
                wishlistRepository.Object,
                korisnikRepository.Object,
                inventroyRepository.Object,
                dijeloviRepository.Object
                );
        }

        [TestMethod]
        public void BuilderAssistentTestCount1()
        {
            korisnikRepository.Setup(s => s.GetById(1)).Returns(new User()
            {
                Id = 1,
                LSets = new List<UserLSet>()
                {
                    new UserLSet()
                    {
                        LSet = setovi.First(),
                        Owned = 1,
                        Built = 0
                    }
                }
            });
            var sets = setService.BuilderAssistent(1);
            Assert.AreEqual(2, sets.Count);
        }

        [TestMethod]
        public void BuilderAssistentTestCount0()
        {
            korisnikRepository.Setup(s => s.GetById(1)).Returns(new User()
            {
                Id = 1
            });
            var sets = setService.BuilderAssistent(1);
            Assert.AreEqual(0, sets.Count);
        }

        [TestMethod]
        public void BuilderAssistentTestBricksNumber()
        {
            korisnikRepository.Setup(s => s.GetById(1)).Returns(new User()
            {
                LSets = new List<UserLSet>()
                {
                    new UserLSet()
                    {
                        LSet = setovi.First(),
                        Owned = 1,
                        Built = 0
                    }
                }
            });
            setovi.First(s => s.Id == 2).LSetParts.First().Number = 2;
            var sets = setService.BuilderAssistent(1);
            Assert.AreEqual(1, sets.Count);
        }

        [TestMethod]
        public void BuilderAssistentTestBuilded()
        {
            korisnikRepository.Setup(s => s.GetById(1)).Returns(new User()
            {
                LSets = new List<UserLSet>()
                {
                    new UserLSet()
                    {
                        LSet = setovi.First(),
                        Owned = 1,
                        Built = 1
                    }
                }
            });

            var sets = setService.BuilderAssistent(1);
            Assert.AreEqual(0, sets.Count);
        }

        [TestMethod]
        public void BuilderAssistentColor()
        {
            korisnikRepository.Setup(s => s.GetById(1)).Returns(new User()
            {
                Id = 1,
                LSets = new List<UserLSet>()
                {
                    new UserLSet()
                    {
                        LSet = setovi.First(x => x.Id == 3),
                        Owned = 1,
                        Built = 0
                    }
                }
            });
            var sets = setService.BuilderAssistent(1);
            Assert.AreEqual(1, sets.Count);
        }


        [TestMethod]
        [ExpectedException(typeof(KorisnikException))]
        public void BuilderAssistentTestExceptionUserNotFound()
        {
            var sets = setService.BuilderAssistent(5);
        }

        [TestMethod]
        public void SearchBrojKockicaFound()
        {
            var searchPattern = "BrojKockica:0-30";
            var sets = setService.Search(searchPattern).ToList();
            Assert.AreEqual(1, sets.Count);
        }

        [TestMethod]
        public void SearchBrojKockicaNotFound()
        {
            var searchPattern = "BrojKockica:200-400";
            var sets = setService.Search(searchPattern).ToList();
            Assert.AreEqual(0, sets.Count);
        }

        [TestMethod]
        public void SearchNameFound()
        {
            var searchPattern = "Name:Set 1";
            var sets = setService.Search(searchPattern).ToList();
            Assert.AreEqual(1, sets.Count);
        }

        [TestMethod]
        public void SearchNameNotFound()
        {
            var searchPattern = "Name:Niti jedan set";
            var sets = setService.Search(searchPattern).ToList();
            Assert.AreEqual(0, sets.Count);
        }

        [TestMethod]
        public void SearchTemaFound()
        {
            var searchPattern = "Tema:Tema 3;";
            var sets = setService.Search(searchPattern).ToList();
            Assert.AreEqual(1, sets.Count);
        }

        [TestMethod]
        public void SearchTemaNotFound()
        {
            var searchPattern = "Tema:Star Wars";
            var sets = setService.Search(searchPattern).ToList();
            Assert.AreEqual(0, sets.Count);
        }

        [TestMethod]
        public void SearcMultipleParams()
        {
            var searchPattern = "Name:Set 1;Tema:Tema 3;BrojKockica:0-50";
            var sets = setService.Search(searchPattern).ToList();
            Assert.AreEqual(1, sets.Count);
        }
    }
}
