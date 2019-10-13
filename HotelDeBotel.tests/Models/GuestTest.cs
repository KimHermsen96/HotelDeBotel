using System;
using HotelDeBotel.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelDeBotel.tests.model
{
    [TestClass]
    public class GuestTest
    {
        [TestMethod]
        public void Guest()
        {
            var guest = new Guest()
            {
                Name = "Kees",
                EmailAddress = "Kees@hotmail.nl",
                Zipcode = "1234AB",
                HouseNumber = 1,
                Addition = "a",
                BookingId = 1
            };

            var name = guest.Name;
            var email = guest.EmailAddress;
            var zipcode = guest.Zipcode;
            var addition = guest.Addition;
            var housenumber = guest.HouseNumber;
            var booking = guest.BookingId;
        }
    }
}
