using System;
using System.Collections.Generic;
using HotelDeBotel.Domain;
using HotelDeBotel.Repository.IRepositories;
using HotelDeBotel.Repository.Persistance;
using HotelDeBotel.Repository.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HotelDeBotel.tests
{
    [TestClass]
    public class DiscountTest
    {
        private DiscountRepository discountRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            var random = new Mock<Random>();
            discountRepository = new DiscountRepository(random.Object);
        }

        [TestMethod]
        public void MondayAndTuesdayDiscount()
        {
            DateTime monday = new DateTime(2019, 2, 25);
            decimal amount = discountRepository.MondayAndTuesdayDiscount(monday, 100);
            Assert.AreEqual(amount, 85);
        }

        [TestMethod]
        public void WeekOfTheYearDiscount_Uneven()
        {
            DateTime dayInWeekNine = new DateTime(2019, 2, 25);
            decimal amount = discountRepository.WeekOfTheYearDiscount(dayInWeekNine, 100);
            Assert.AreEqual(amount, 97);
        }

        [TestMethod]
        public void WeekOfTheYearDiscount_Even()
        {
            DateTime dayInWeekTen = new DateTime(2019, 3, 6);
            decimal amount = discountRepository.WeekOfTheYearDiscount(dayInWeekTen, 100);
            Assert.AreEqual(amount, 100);
        }

        [TestMethod]
        public void AlphabeticDiscount_One()
        {
            Guest guestOne = new Guest(){ Name = "Kees" };
            Guest guestTwo = new Guest(){ Name = "abce" };
            List<Guest> guests = new List<Guest>(){ guestOne, guestTwo};

            decimal amount = discountRepository.AlphabeticDiscount(100, guests);
            Assert.AreEqual(amount, 94.12m);
        }

        [TestMethod]
        public void AlphabeticDiscount_Two()
        {
            Guest guestOne = new Guest() { Name = "Ivo" };
            Guest guestTwo = new Guest() { Name = "Berend" };
            List<Guest> guests = new List<Guest>() { guestOne, guestTwo };

            decimal amount = discountRepository.AlphabeticDiscount(100, guests);
            Assert.AreEqual(amount, 100.00m);
        }

        [TestMethod]
        public void AlphabeticDiscount_Three()
        {
            Guest guestOne = new Guest() { Name = "AARON" };
            Guest guestTwo = new Guest() { Name = "Suzan" };
            List<Guest> guests = new List<Guest>() { guestOne, guestTwo };

            decimal amount = discountRepository.AlphabeticDiscount(100, guests);
            Assert.AreEqual(amount, 96.04m);
        }

        [TestMethod]
        public void DiceDubbelerDiscount()
        {
            decimal amount = discountRepository.DiceDubbelerDiscount(75, 100);
          
            switch (discountRepository.RandomNumber)
            {
                case 1:
                    Assert.AreEqual(amount, 75);
                    break;
                case 2:
                    Assert.AreEqual(amount, 50);
                    break;
                case 3:
                    Assert.AreEqual(amount, 25);
                    break;
                case 4:
                    Assert.AreEqual(amount, 0);
                    break;
                case 5:
                    Assert.AreEqual(amount, -25);
                    break;
                case 6:
                    Assert.AreEqual(amount, -50);
                    break;
            }
        }

        [TestMethod]
        public void CheckDiscount_LessThanSixty()
        {

            decimal amount = discountRepository.CheckDiscount(50, 100);
            Assert.AreEqual(amount, 50);
           
        }

        [TestMethod]
        public void CheckDiscount_MoreThanSixty()
        {

            decimal amount = discountRepository.CheckDiscount(20, 100);
            Assert.AreEqual(amount, 40);
        }
    }
}
