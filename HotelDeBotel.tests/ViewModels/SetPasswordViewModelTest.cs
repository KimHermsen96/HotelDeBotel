using System;
using HotelDeBotel.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelDeBotel.tests.ViewModels
{
    [TestClass]
    public class SetPasswordViewModelTest
    {
        [TestMethod]
        public void SetPasswordViewModel()
        {
            var setPasswordVm = new SetPasswordViewModel()
            {
                NewPassword = "",
                ConfirmPassword =  ""
            };
            var newPassword = setPasswordVm.NewPassword;
            var confirmPassword = setPasswordVm.ConfirmPassword;
        }
    }
}
