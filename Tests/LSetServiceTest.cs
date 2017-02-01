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
        private List<LSet> lSets;

        Mock<IRepository<LSet>> lSetRepository = new Mock<IRepository<LSet>>();
        Mock<IRepository<Wishlist>> wishlistRepository = new Mock<IRepository<Wishlist>>();
        Mock<IRepository<User>> userRepository = new Mock<IRepository<User>>();
        Mock<IRepository<UserLSet>> inventoryRepository = new Mock<IRepository<UserLSet>>();
        Mock<IRepository<LSetPart>> lSetPartRepository = new Mock<IRepository<LSetPart>>();

        private void IniData()
        {
            var category1 = new Category()
            {
                Id = 1,
                Name = "kat 1"
            };

            var part1 = new Part()
            {
                Name = "part 1",
                Category = category1
            };
            var part2 = new Part()
            {
                Name = "part 2",
                Category = category1
            };
            var part3 = new Part()
            {
                Name = "part 3",
                Category = category1
            };
            var part4 = new Part()
            {
                Name = "part 4",
                Category = category1
            };

            var color1 = new Color()
            {
                Id = 1,
                Name = "Plava"
            };

            var color2 = new Color()
            {
                Id = 2,
                Name = "Zelena"
            };

            var theme1 = new Theme()
            {
                Name = "theme 1"
            };
            var theme2 = new Theme()
            {
                Name = "theme 2"
            };
            var theme3 = new Theme()
            {
                Name = "theme 3",
                BaseTheme = theme1
            };

            var set1 = new LSet()
            {
                Id = 1,
                Name = "Set 1",
                NumberOfParts = 5,
                Theme = theme3
            };


            var lSetParts1 = new List<LSetPart>() {  new LSetPart()
            {
                Color = color1,
                Part = part1,
                Number = 1,
                LSet = set1
            },
             new LSetPart()
            {
                Color = color1,
                Part = part2,
                Number = 1,
                LSet = set1
            }};

            set1.LSetParts = lSetParts1;

            var set2 = new LSet()
            {
                Id = 2,
                Name = "Set 2",
                LSetParts = new List<LSetPart>(),
                NumberOfParts = 35,
                Theme = theme2
            };

            set2.LSetParts = new List<LSetPart>() {
                new LSetPart()
            {
                Color = color1,
                Part = part2,
                Number = 1,
                LSet = set2
            }};

            var set3 = new LSet()
            {
                Id = 3,
                Name = "Set 3",
                NumberOfParts = 100,
                Theme = theme2
            };

            var lSetParts3 = new List<LSetPart>() {  new LSetPart()
            {
                Color = color2,
                Part = part1,
                Number = 1,
                LSet = set3
            },
             new LSetPart()
            {
                Color = color2,
                Part = part2,
                Number = 1,
                LSet = set3
            }};

            set3.LSetParts = lSetParts3;

            lSets = new List<LSet>() { set1, set2, set3 };
        }

        [TestInitialize]
        public void CreateInstances()
        {
            IniData();

            lSetRepository.Setup(s => s.Query()).Returns(lSets.AsQueryable);

            setService = new LSetService(
                lSetRepository.Object,
                wishlistRepository.Object,
                userRepository.Object,
                inventoryRepository.Object,
                lSetPartRepository.Object
                );
        }

        [TestMethod]
        public void BuilderAssistentTestCount1()
        {
            userRepository.Setup(s => s.GetById(1)).Returns(new User()
            {
                Id = 1,
                LSets = new List<UserLSet>()
                {
                    new UserLSet()
                    {
                        LSet = lSets.First(),
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
            userRepository.Setup(s => s.GetById(1)).Returns(new User()
            {
                Id = 1
            });
            var sets = setService.BuilderAssistent(1);
            Assert.AreEqual(0, sets.Count);
        }

        [TestMethod]
        public void BuilderAssistentTestBricksNumber()
        {
            userRepository.Setup(s => s.GetById(1)).Returns(new User()
            {
                LSets = new List<UserLSet>()
                {
                    new UserLSet()
                    {
                        LSet = lSets.First(),
                        Owned = 1,
                        Built = 0
                    }
                }
            });
            lSets.First(s => s.Id == 2).LSetParts.First().Number = 2;
            var sets = setService.BuilderAssistent(1);
            Assert.AreEqual(1, sets.Count);
        }

        [TestMethod]
        public void BuilderAssistentTestBuilded()
        {
            userRepository.Setup(s => s.GetById(1)).Returns(new User()
            {
                LSets = new List<UserLSet>()
                {
                    new UserLSet()
                    {
                        LSet = lSets.First(),
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
            userRepository.Setup(s => s.GetById(1)).Returns(new User()
            {
                Id = 1,
                LSets = new List<UserLSet>()
                {
                    new UserLSet()
                    {
                        LSet = lSets.First(x => x.Id == 3),
                        Owned = 1,
                        Built = 0
                    }
                }
            });
            var sets = setService.BuilderAssistent(1);
            Assert.AreEqual(1, sets.Count);
        }


        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void BuilderAssistentTestExceptionUserNotFound()
        {
            var sets = setService.BuilderAssistent(5);
        }

        [TestMethod]
        public void SearchNumberOfPartsFound()
        {
            var searchPattern = "NumberOfParts:0-30";
            var sets = setService.Search(searchPattern).ToList();
            Assert.AreEqual(1, sets.Count);
        }

        [TestMethod]
        public void SearchNumberOfPartsNotFound()
        {
            var searchPattern = "NumberOfParts:200-400";
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
        public void SearchthemeFound()
        {
            var searchPattern = "Theme:theme 3;";
            var sets = setService.Search(searchPattern).ToList();
            Assert.AreEqual(1, sets.Count);
        }

        [TestMethod]
        public void SearchthemeNotFound()
        {
            var searchPattern = "BaseTheme:Star Wars";
            var sets = setService.Search(searchPattern).ToList();
            Assert.AreEqual(0, sets.Count);
        }

        [TestMethod]
        public void SearcMultipleParams()
        {
            var searchPattern = "Name:Set 1;theme:theme 3;NumberOfParts:0-50";
            var sets = setService.Search(searchPattern).ToList();
            Assert.AreEqual(1, sets.Count);
        }
    }
}
