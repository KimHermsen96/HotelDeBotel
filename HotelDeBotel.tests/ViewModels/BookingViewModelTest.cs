using System;
using System.Collections.Generic;
using HotelDeBotel.Domain;
using HotelDeBotel.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelDeBotel.tests.ViewModels
{
    [TestClass]
    public class BookingViewModelTest
    {
        [TestMethod]
        public void BookingViewModel()
        {

            var bookingvm = new BookingViewModel()
            {
                Guests = new List<Guest>(),
                Room = new Room(),
                Date = new DateTime(2019, 06, 30),
                Price = 100.00m,
                Discount = 20.00m,
                NumberOfGuests = 2  
            };

            var guests = bookingvm.Guests;
            var room = bookingvm.Room;
            var date = bookingvm.Date;
            var price = bookingvm.Price;
            var discount = bookingvm.Discount;
            var numberOfGuests = bookingvm.NumberOfGuests;
        }
    }
}
