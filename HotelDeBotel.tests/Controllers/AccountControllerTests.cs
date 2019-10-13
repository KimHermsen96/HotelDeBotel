using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelDeBotel.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HotelDeBotel.Models;
using HotelDeBotel.tests;
using Moq;

namespace HotelDeBotel.Controllers.Tests
{
    [TestClass()]
    public class AccountControllerTests
    {
        private AccountController _accountController;

        [TestInitialize]
        public void TestInitialize()
        {
            _accountController = new AccountController();
        }


        [TestMethod()]
        public void AccountControllerTest()
        {
            new AccountController();
        }

        [TestMethod()]
        public void LoginTest()
        {
            var result = _accountController.Login(" ") as ViewResult;
            Assert.AreEqual("Login", result.ViewName);
        }

        [TestMethod()]
        public void LoginTest1()
        {
            var controller = new ModelStateTestController();

            LoginViewModel loginvm = new LoginViewModel()
            {
                Email = "kees@hotmail.nl",
                Password = "Test123!",
            };

            var result = controller.TestTryValidateModel(loginvm);
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void RegisterTest()
        {
            var result = _accountController.Register() as ViewResult;
            Assert.AreEqual("Register", result.ViewName);
        }

        [TestMethod()]
        public void RegisterTest1()
        {
            var controller = new ModelStateTestController();

            RegisterViewModel registervm = new RegisterViewModel()
            {
                Email = "kees@hotmail.nl",
                Password = "Test123!",
                ConfirmPassword = "Test123!"
            };
            var validateModelState = controller.TestTryValidateModel(registervm);

            Assert.AreEqual(true, validateModelState);
        }
    }
}