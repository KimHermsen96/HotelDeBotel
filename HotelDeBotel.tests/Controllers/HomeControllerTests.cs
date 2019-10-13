using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelDeBotel.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HotelDeBotel.Domain;
using HotelDeBotel.Repository.IRepositories;
using Moq;

namespace HotelDeBotel.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        private HomeController _homeController;
        private Mock<IRoomRepository> _mockRoomRepo;

        [TestInitialize]
        public void TestInitialize()
        {
             _mockRoomRepo = new Mock<IRoomRepository>();
            _homeController = new HomeController(_mockRoomRepo.Object);
        }

        [TestMethod()]
        public void IndexTest()
        {
            var rooms = new List<Room>();
            var result = _homeController.Index() as ViewResult;
            _mockRoomRepo.Setup(x => x.RecommendedRooms()).Returns(rooms);
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}