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
using Moq;

namespace HotelDeBotel.Controllers.Tests
{
    [TestClass()]
    public class BookingControllerTest
    {
        private BookingsController _bookingController;
        private Mock<IUserRepository> _mockUserRepo;
        private Mock<IBookingRepository> _mockBookingRepo;
        private Mock<IRoomRepository> _mockRoomRepo;
        private Mock<HotelContext> _mockContext;

       [TestInitialize]
        public void TestInitialize()
        {
            _mockBookingRepo = new Mock<IBookingRepository>();
            _mockRoomRepo = new Mock<IRoomRepository>();
            _mockUserRepo = new Mock<IUserRepository>();
            _mockContext = new Mock<HotelContext>();
            Mock<IGuestRepository> guestRepo = new Mock<IGuestRepository>();
            Mock<IDiscountRepository> discountRepo = new Mock<IDiscountRepository>();

            _bookingController = new BookingsController(_mockBookingRepo.Object, _mockRoomRepo.Object, _mockUserRepo.Object, _mockContext.Object, guestRepo.Object, discountRepo.Object);
        }


        // check if the right bookinglist is returned.  
        [TestMethod()]
        public void IndexTest()
        {
            var bookingList = new List<Booking>()
            {
                new Booking()
                {
                    Guests = new List<Guest>(),
                    Room = new Room(),
                    Date  = new DateTime(2019, 6, 12),
                    Price = 200,
                },
            };

            var userMock = new Mock<IPrincipal>();
            userMock.Setup(p => p.IsInRole("Employee")).Returns(true);

            var contextMock = new Mock<HttpContextBase>();
            contextMock.SetupGet(ctx => ctx.User)
                .Returns(userMock.Object);

            var controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.SetupGet(con => con.HttpContext)
                .Returns(contextMock.Object);

            _bookingController.ControllerContext = controllerContextMock.Object;

            _mockBookingRepo.Setup(x => x.GetAllBookingInfo()).Returns(bookingList);

            var result = _bookingController.Index() as ViewResult;
            userMock.Verify(p => p.IsInRole("Employee"));

            Assert.AreEqual(bookingList, result.Model);
        }

        //test if the booking is returned. 
        [TestMethod()]
        public void DetailsTest()
        {
            Booking booking = new Booking()
            {
                Guests = new List<Guest>(),
                Room = new Room(),
                Date = new DateTime(2019, 6, 12),
                Price = 200,
            };

            _mockBookingRepo.Setup(x => x.FindBooking(1)).Returns(booking);
            var result = _bookingController.Details(1) as ViewResult;
            Assert.AreEqual(booking, result.Model);
        }

        [TestMethod()]
        public void CreateTest()
        {
            Room room = new Room()
            {
                Name = "zeemans suite",
                Price = 200.00m,
                Size = 2,
                Image = "https://www.google.com/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjhxafnnvXgAhUBL1AKHVpqBOIQjRx6BAgBEAU&url=http%3A%2F%2Fwww.bestwesternplusmeridian.com%2Fhotel-rooms&psig=AOvVaw3w593gpqrXk-U5R3J0-aQU&ust=1552227094093805"
            };

            _mockRoomRepo.Setup(x => x.Find(1)).Returns(room);
            var result = _bookingController.Create(1) as ViewResult;
            var vm = (BookingViewModel)result.Model;
            Assert.AreEqual(room, vm.Room);
        }

        [TestMethod()]
        public void BookingContactDetailsTest()
        {

            _mockBookingRepo.Setup(x => x.IsAvailable(1, new DateTime(2020, 6, 30))).Returns(true);
            BookingViewModel bookingvm = new BookingViewModel()
            {
                Date = new DateTime(2020, 6, 30),
                NumberOfGuests = 2,
                Room = new Room()
                {
                    Id = 1,
                    Size = 3
                }
            };
            var result = _bookingController.BookingContactDetails(bookingvm) as ViewResult;
            Assert.AreEqual("BookingContactDetails", result.ViewName);
        }

        [TestMethod()]
        public void BookingContactDetailsTestTwo()
        {
            BookingViewModel bookingvm = new BookingViewModel()
            {
                Date = new DateTime(2000, 6, 30),
                NumberOfGuests = 2,
                Room = new Room()
                {
                    Id = 1,
                    Size = 1
                }
            };

            _mockBookingRepo.Setup(x => x.IsAvailable(1, new DateTime(2000, 6, 30))).Returns(false);
            var result = _bookingController.BookingContactDetails(bookingvm) as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }
    }
}