using System;
using System.Collections.Generic;
using HotelDeBotel.Models;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelDeBotel.tests.ViewModels
{
    [TestClass]
    public class IndexViewModelTest
    {
        [TestMethod]
        public void IndexViewModel()
        {
            var indexvm = new IndexViewModel()
            {
                HasPassword = true,
                Logins = new List<UserLoginInfo>(),
                PhoneNumber = "",
                TwoFactor = false,
                BrowserRemembered = false
            };

            var hasPassword = indexvm.HasPassword;
            var logins = indexvm.Logins;
            var phone = indexvm.PhoneNumber;
            var twoFactor = indexvm.TwoFactor;
            var browserRemembered = indexvm.BrowserRemembered;

        }
    }
}
