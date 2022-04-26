using GYUZZ6_HFT_2021222.Logic;
using GYUZZ6_HFT_2021222.Logic.Classes;
using GYUZZ6_HFT_2021222.Models;
using GYUZZ6_HFT_2021222.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GYUZZ6_HFT_2021222.Test
{
    [TestFixture]
    public class LogicTester
    {
        BrandLogic brandLogic;
        CarLogic carLogic;
        RentLogic rentLogic;

        Mock<IRepository<Brand>> mockBrandRepository;
        Mock<IRepository<Car>> mockCarRepository;
        Mock<IRepository<Rent>> mockRentRepository;

        [SetUp]
        public void Init()
        {
            mockBrandRepository = new Mock<IRepository<Brand>>();
            mockBrandRepository.Setup(mb => mb.ReadAll()).Returns(new List<Brand>()
            {
                new Brand(){ Id = 1, Name = "Tesla"},
                new Brand(){ Id = 2, Name = "Mercedes"},
            }.AsQueryable());
            brandLogic = new BrandLogic(mockBrandRepository.Object);

            mockCarRepository = new Mock<IRepository<Car>>();
            mockCarRepository.Setup(mc => mc.ReadAll()).Returns(new List<Car>()
            {
                new Car(){ Id = 1, Model = "Tesla Model S", BasePrice = 95000, BrandId = 1},
                new Car(){ Id = 2, Model = "Eqs", BasePrice = 105000, BrandId = 2},
            }.AsQueryable());
            carLogic = new CarLogic(mockCarRepository.Object);

            mockRentRepository = new Mock<IRepository<Rent>>();
            mockRentRepository.Setup(mr => mr.ReadAll()).Returns(new List<Rent>()
            {
                new Rent(){ Id = 1, CarId = 1, Date = new DateTime(2021,04,20), RenterName = "Drew", RentTime = 1.5, Rating = 4.5 },
                new Rent(){ Id = 2, CarId = 2, Date = new DateTime(2021,04,21), RenterName = "Nick", RentTime = 1.8, Rating = 3.5 },
            }.AsQueryable());
            rentLogic = new RentLogic(mockRentRepository.Object, mockCarRepository.Object, mockBrandRepository.Object);
        }

        [Test]
        public void BrandCreateTest()
        {
            var brand = new Brand() { Name = "Bmw"};

            //act
            brandLogic.Create(brand);

            //assert
            mockBrandRepository.Verify(b => b.Create(brand), Times.Once);
        }

        [Test]
        public void BasePriceAverageByBrandTest()
        {
            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Tesla",95000),
                new KeyValuePair<string, double>("Mercedes",105000),
            };

            //act
            var actual = rentLogic.BasePriceAverageByBrand().ToList();

            //asset
            Assert.AreEqual(expected, actual);
        }
    }
}
