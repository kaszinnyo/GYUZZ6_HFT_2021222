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
            var brandInput = new List<Brand>()
            {
                new Brand(){ Id = 1, Name = "Tesla"},
                new Brand(){ Id = 2, Name = "Mercedes"},
            };

            var carInput = new List<Car>()
            {
                new Car(){ Id = 1, Model = "Tesla Model S", BasePrice = 95000, BrandId = 1, Brand = brandInput[0]},
                new Car(){ Id = 2, Model = "Eqs", BasePrice = 105000, BrandId = 2, Brand = brandInput[1]},
            };

            var rentInput = new List<Rent>()
            {
                new Rent(){ Id = 1, CarId = 1, Date = new DateTime(2021,04,20), RenterName = "Drew", RentTime = 1.5, Rating = 4.5, Car = carInput[0] },
                new Rent(){ Id = 2, CarId = 2, Date = new DateTime(2021,04,21), RenterName = "Nick", RentTime = 1.8, Rating = 3.5, Car = carInput[1] },
            };
            mockBrandRepository = new Mock<IRepository<Brand>>(MockBehavior.Loose);
            mockBrandRepository.Setup(mb => mb.ReadAll()).Returns(brandInput.AsQueryable());
            brandLogic = new BrandLogic(mockBrandRepository.Object);

            mockCarRepository = new Mock<IRepository<Car>>(MockBehavior.Loose);
            mockCarRepository.Setup(mc => mc.ReadAll()).Returns(carInput.AsQueryable());
            carLogic = new CarLogic(mockCarRepository.Object);

            mockRentRepository = new Mock<IRepository<Rent>>(MockBehavior.Loose);
            mockRentRepository.Setup(mr => mr.ReadAll()).Returns(rentInput.AsQueryable());
            rentLogic = new RentLogic(mockRentRepository.Object, mockCarRepository.Object, mockBrandRepository.Object);


        }

        [Test]
        public void BrandCreateTest()
        {
            var brand = new Brand() { Name = "Bmw" };
            var wrongbrand = new Brand() { Name = "a" };

            //act
            brandLogic.Create(brand);

            //assert
            mockBrandRepository.Verify(b => b.Create(brand), Times.Once);
            mockBrandRepository.Setup(r => r.Create(wrongbrand));
            Assert.Throws(typeof(ArgumentException), () => brandLogic.Create(wrongbrand));
        }

        [Test]
        public void CarCreateTest()
        {
            var car = new Car() { Model = "Tesla Model 2" };
            var wrongcar = new Car() { Model = "a" };

            //act
            carLogic.Create(car);

            //assert
            mockCarRepository.Verify(c => c.Create(car), Times.Once);
            mockCarRepository.Setup(r => r.Create(wrongcar));
            Assert.Throws(typeof(ArgumentException), () => carLogic.Create(wrongcar));
        }

        [Test]
        public void RentCreateTest()
        {
            var rent = new Rent() { RenterName = "Drew", Rating = 3.4 };
            var wrongrent = new Rent() { RenterName = "a"};

            //act
            rentLogic.Create(rent);

            //assert
            mockRentRepository.Verify(r => r.Create(rent), Times.Once);
            mockRentRepository.Setup(r => r.Create(wrongrent));
            Assert.Throws(typeof(ArgumentException), () => rentLogic.Create(wrongrent));

        }

        [Test]
        public void CarUpdateTest()
        {
            var car = new Car() { Id = 1, BasePrice = 15000 };
            //act
            carLogic.Update(car);

            //assert
            mockCarRepository.Verify(c => c.Update(car), Times.Once);
        }

        [Test]
        public void BrandDeleteTest()
        {
            //act
            brandLogic.Delete(1);

            //assert
            mockBrandRepository.Verify(b => b.Delete(1), Times.Once);
        }

        [Test]
        public void CarDeleteTest()
        {
            //act
            carLogic.Delete(1);

            //assert
            mockCarRepository.Verify(c => c.Delete(1), Times.Once);
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
            var actual = rentLogic.BasePriceAverageByBrand();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RentCountByModel()
        {
            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("Tesla Model S",1),
                new KeyValuePair<string, int>("Eqs",1),
            };

            //act
            var actual = rentLogic.RentCountByModel();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RentsSumByDate()
        {
            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("20/04/2021 00:00:00",1.5),
                new KeyValuePair<string, double>("21/04/2021 00:00:00",1.8),
            };

            //act
            var actual = rentLogic.RentsSumByDate();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BrandCarCount()
        {
            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("Tesla",1),
                new KeyValuePair<string, int>("Mercedes",1),
            };

            //act
            var actual = rentLogic.BrandCarCount();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AverageRatingByModel()
        {
            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Tesla Model S",4.5),
                new KeyValuePair<string, double>("Eqs",3.5),
            };

            //act
            var actual = rentLogic.AverageRatingByModel();

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
