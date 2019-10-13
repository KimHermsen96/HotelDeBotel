using System;
using System.Collections.Generic;
using HotelDeBotel.Domain;
using HotelDeBotel.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelDeBotel.tests.ViewModels
{
    [TestClass]
    public class RoomsViewModelTest
    {
        [TestMethod]
        public void RoomsViewModel()
        {
            var roomsvm = new RoomsViewModel()
            {
                Rooms = new List<Room>(),
                User = new ApplicationUser()
            };

            var rooms = roomsvm.Rooms;
            var user = roomsvm.User;
        }
    }
}
