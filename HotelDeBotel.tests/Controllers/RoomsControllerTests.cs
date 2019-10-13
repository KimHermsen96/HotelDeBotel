using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelDeBotel.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HotelDeBotel.Domain;
using HotelDeBotel.Models;
using HotelDeBotel.Repository.IRepositories;
using HotelDeBotel.Repository.Persistance;
using HotelDeBotel.tests;
using Microsoft.AspNet.Identity;
using Moq;

namespace HotelDeBotel.Controllers.Tests
{
    [TestClass()]
    public class RoomsControllerTests
    {
        private RoomsController _roomsController;
        private Mock<IRoomRepository> _mockRoomRepo;
        private Mock<HotelContext> _mockHotelContext;
        private Mock<IUserRepository> _mockUserRepo;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRoomRepo = new Mock<IRoomRepository>();
            _mockHotelContext = new Mock<HotelContext>();
            _mockUserRepo = new Mock<IUserRepository>();
            _roomsController = new RoomsController(_mockRoomRepo.Object, _mockHotelContext.Object, _mockUserRepo.Object);
        }


        [TestMethod()]
        public void RoomsControllerTest()

        {
            RoomsController controller = new RoomsController(_mockRoomRepo.Object, _mockHotelContext.Object, _mockUserRepo.Object);
            Assert.IsNotNull(controller);
        }

        [TestMethod()]
        public void IndexTest()
        {
            var context = new Mock<System.Web.Mvc.ControllerContext>();
            var mockPrincipal = new Mock<IPrincipal>();
            var mockIdentity = new Mock<IIdentity>();

            mockPrincipal.Setup(p => p.Identity).Returns(mockIdentity.Object);
            mockIdentity.Setup(ob => ob.Name).Returns("name");

            context.SetupGet(x => x.HttpContext.User).Returns(mockPrincipal.Object);
            context.SetupGet(x => x.HttpContext.User.Identity).Returns(mockIdentity.Object);

            _roomsController.ControllerContext = context.Object;
            var rooms = _mockRoomRepo.Setup(x => x.GetAll()).Returns(new List<Room>());
            var user = _mockUserRepo.Setup(x => x.Find("1")).Returns(new ApplicationUser());

            RoomsViewModel roomvm = new RoomsViewModel()
            {
                Rooms = new List<Room>(),
                User = new ApplicationUser()
            };

            var result = _roomsController.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);

        }

        [TestMethod()]
        public void ReserveRoomTest()
        {
            var result = _roomsController.ReserveRoom(1) as RedirectToRouteResult;
            Assert.AreEqual("Create", result.RouteValues["Action"]);
            Assert.AreEqual("Bookings", result.RouteValues["Controller"]);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            _mockRoomRepo.Setup(x => x.Find(1)).Returns(new Room());
            var result = _roomsController.Details(1) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod()]
        public void CreateTest()
        {

            var result = _roomsController.Create() as ViewResult;

            var room = result.Model;
            Assert.AreEqual("Create", result.ViewName);
            Assert.AreEqual(null, result.Model);
        }

        [TestMethod()]
        public void CreateTest1()
        {
            var controller = new ModelStateTestController();
            Room room = new Room()
            {
                Name = "Suite",
                Size = 2,
                Image = "",
                Price = 100.00m
            };

            var validationROne = controller.TestTryValidateModel(room);
            var result = _roomsController.Create(room) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }

        [TestMethod()]
        public void EditTest()
        {
            _mockRoomRepo.Setup(x => x.Find(1)).Returns(new Room());
            var result = _roomsController.Edit(1) as ViewResult;
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            _mockRoomRepo.Setup(x => x.Find(1)).Returns(new Room());
            var result = _roomsController.Delete(1) as ViewResult;
            Assert.AreEqual("Delete", result.ViewName);
        }
    }
}