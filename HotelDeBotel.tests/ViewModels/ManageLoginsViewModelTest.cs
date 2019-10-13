using System;
using System.Collections.Generic;
using HotelDeBotel.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelDeBotel.tests.ViewModels
{
    [TestClass]
    public class ManageLoginsViewModelTest
    {
        [TestMethod]
        public void ManageLoginsViewModel()
        {

            var manageLoginsvm = new ManageLoginsViewModel()
            {
                CurrentLogins = new List<UserLoginInfo>(),
                OtherLogins = new List<AuthenticationDescription>()
            };

            var currentLogins = manageLoginsvm.CurrentLogins;
            var otherLogins = manageLoginsvm.OtherLogins;
        }
    }
}
