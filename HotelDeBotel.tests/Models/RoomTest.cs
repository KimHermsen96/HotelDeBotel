using System;
using HotelDeBotel.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelDeBotel.tests.model
{
    [TestClass]
    public class RoomTest
    {
        [TestMethod]
        public void Room()
        {

            var room = new Room()
            {
                Name = "Mermade Room",
                Size = 2,
                Price = 100.00m,
                Image = ""
            };

            var name = room.Name;
            var size = room.Size;
            var price = room.Price;
            var image = room.Image;
        }
    }
}
