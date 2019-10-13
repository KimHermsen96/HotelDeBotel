using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelDeBotel.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HotelDeBotel.Controllers.Tests
{
    [TestClass()]
    public class ManageControllerTests
    {

        private ManageController _manageController;

        [TestInitialize]
        public void TestInitialize()
        {
            _manageController = new ManageController();
        }

        [TestMethod()]
        public void ChangePasswordTest()
        {
           var result =  _manageController.ChangePassword() as ViewResult;
           Assert.AreEqual("ChangePassword", result.ViewName);
        }
    }
}