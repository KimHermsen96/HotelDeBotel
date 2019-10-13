using System;
using System.Collections.Generic;
using HotelDeBotel.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelDeBotel.tests.model
{
    [TestClass]
    public class BookingTest
    {
        [TestMethod]
        public void Booking()
        {
           
            var booking = new Booking()
            {
                Guests = new List<Guest>(),
                Room = new Room(),
                RoomId = 1,
                Date = new DateTime(2019, 06, 30),
                Price = 100.00m,
                User = new ApplicationUser()
            };

            var allGuests =  booking.Guests;
            var room =  booking.Room;
            var user = booking.User;
            var price = booking.Price;
            var date = booking.Date;
            var roomId = booking.RoomId;

        }
    }
}
