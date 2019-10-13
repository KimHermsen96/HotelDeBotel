using System;
using HotelDeBotel.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelDeBotel.tests.ViewModels
{
    [TestClass]
    public class ChangePasswordViewModelTest
    {
        [TestMethod]
        public void ChangePasswordViewModel()
        {
            var changepasswordvm = new ChangePasswordViewModel()
            {
                OldPassword = "",
                NewPassword = "",
                ConfirmPassword = ""
            };

            var oldPassword = changepasswordvm.OldPassword;
            var newPassword = changepasswordvm.NewPassword;
            var confirmPassword = changepasswordvm.ConfirmPassword;
        }
    }
}
