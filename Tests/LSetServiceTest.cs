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
        Mock<IRepository<Korisnik>> korisnikRepository = new Mock<IRepository<Korisnik>>();
        Mock<IRepository<UserSet>> inventroyRepository = new Mock<IRepository<UserSet>>();
        Mock<IRepository<SetoviDijelovi>> dijeloviRepository = new Mock<IRepository<SetoviDijelovi>>();

        private void IniData()
        {
            var kategorija1 = new Kategorija()
            {
                Id = 1,
                Ime = "kat 1"
            };

            var kockica1 = new Kockica()
            {
                Ime = "Kockica 1",
                Kategorija = kategorija1
            };
            var kockica2 = new Kockica()
            {
                Ime = "Kockica 2",
                Kategorija = kategorija1
            };
            var kockica3 = new Kockica()
            {
                Ime = "Kockica 3",
                Kategorija = kategorija1
            };
            var kockica4 = new Kockica()
            {
                Ime = "Kockica 4",
                Kategorija = kategorija1
            };

            var boja1 = new Boja()
            {
                Id = 1,
                Ime = "Plava"
            };

            var boja2 = new Boja()
            {
                Id = 2,
                Ime = "Zelena"
            };

            var tema1 = new Tema()
            {
                ImeTema = "Tema 1"
            };
            var tema2 = new Tema()
            {
                ImeTema = "Tema 2"
            };
            var tema3 = new Tema()
            {
                ImeTema = "Tema 3",
                NadTema = tema1
            };

            var set1 = new LSet()
            {
                Id = 1,
                Ime = "Set 1",
                DijeloviBroj = 5,
                Tema = tema3
            };


            var dijelovi1 = new List<SetoviDijelovi>() {  new SetoviDijelovi()
            {
                Boja = boja1,
                Kockica = kockica1,
                Broj = 1,
                Set = set1
            },
             new SetoviDijelovi()
            {
                Boja = boja1,
                Kockica = kockica2,
                Broj = 1,
                Set = set1
            }};

            set1.Dijelovi = dijelovi1;

            var set2 = new LSet()
            {
                Id = 2,
                Ime = "Set 2",
                Dijelovi = new List<SetoviDijelovi>(),
                DijeloviBroj = 35,
                Tema = tema2
            };

            set2.Dijelovi = new List<SetoviDijelovi>() {
                new SetoviDijelovi()
            {
                Boja = boja1,
                Kockica = kockica2,
                Broj = 1,
                Set = set2
            }};

            var set3 = new LSet()
            {
                Id = 3,
                Ime = "Set 3",
                DijeloviBroj = 100,
                Tema = tema2
            };

            var dijelovi3 = new List<SetoviDijelovi>() {  new SetoviDijelovi()
            {
                Boja = boja2,
                Kockica = kockica1,
                Broj = 1,
                Set = set3
            },
             new SetoviDijelovi()
            {
                Boja = boja2,
                Kockica = kockica2,
                Broj = 1,
                Set = set3
            }};

            set3.Dijelovi = dijelovi3;

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
            korisnikRepository.Setup(s => s.GetById(1)).Returns(new Korisnik()
            {
                Id = 1,
                Setovi = new List<UserSet>()
                {
                    new UserSet()
                    {
                        Set = setovi.First(),
                        Komada = 1,
                        Slozeno = 0
                    }
                }
            });
            var sets = setService.BuilderAssistent(1);
            Assert.AreEqual(2, sets.Count);
        }

        [TestMethod]
        public void BuilderAssistentTestCount0()
        {
            korisnikRepository.Setup(s => s.GetById(1)).Returns(new Korisnik()
            {
                Id = 1
            });
            var sets = setService.BuilderAssistent(1);
            Assert.AreEqual(0, sets.Count);
        }

        [TestMethod]
        public void BuilderAssistentTestBricksNumber()
        {
            korisnikRepository.Setup(s => s.GetById(1)).Returns(new Korisnik()
            {
                Setovi = new List<UserSet>()
                {
                    new UserSet()
                    {
                        Set = setovi.First(),
                        Komada = 1,
                        Slozeno = 0
                    }
                }
            });
            setovi.First(s => s.Id == 2).Dijelovi.First().Broj = 2;
            var sets = setService.BuilderAssistent(1);
            Assert.AreEqual(1, sets.Count);
        }

        [TestMethod]
        public void BuilderAssistentTestBuilded()
        {
            korisnikRepository.Setup(s => s.GetById(1)).Returns(new Korisnik()
            {
                Setovi = new List<UserSet>()
                {
                    new UserSet()
                    {
                        Set = setovi.First(),
                        Komada = 1,
                        Slozeno = 1
                    }
                }
            });

            var sets = setService.BuilderAssistent(1);
            Assert.AreEqual(0, sets.Count);
        }

        [TestMethod]
        public void BuilderAssistentColor()
        {
            korisnikRepository.Setup(s => s.GetById(1)).Returns(new Korisnik()
            {
                Id = 1,
                Setovi = new List<UserSet>()
                {
                    new UserSet()
                    {
                        Set = setovi.First(x => x.Id == 3),
                        Komada = 1,
                        Slozeno = 0
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
