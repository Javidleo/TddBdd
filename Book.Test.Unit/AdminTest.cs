﻿using DomainModel;
using DomainModel.Validation;
using FluentAssertions;
using FluentValidation.TestHelper;
using UseCases.Exceptions;
using UseCases.Services;
using Xunit;

namespace BookTest.Unit
{
    public class AdminTest
    {
        private readonly AdminService service;
        private readonly AdminValidation validation;
        public AdminTest()
        {
             service = new AdminService();
            validation = new AdminValidation();
        }

        [Fact, Trait("Admin", "validation")]
        public void AdminVaidation_VaidatingNullName_ShouldHaveError()
        {
            var admin = Admin.Create(1, "", "family", "11/10/1395", "12341234", "username", "email", "password");
            var result = validation.TestValidate(admin);
            result.ShouldHaveValidationErrorFor(user => user.Name);
        }

        [Fact, Trait("Admin", "validation")]
        public void AdminValidation_validatingNotNullName_ShouldNotHaveError()
        {
            var admin = Admin.Create(1, "name", "family", "11/10/1395", "12341234", "username", "email", "password");
            var result = validation.TestValidate(admin);
            result.ShouldNotHaveValidationErrorFor(admin => admin.Name);
        }

        [Fact, Trait("Admin", "validation")]
        public void AdminValidation_ValidatingNullFamily_ShouldHaveError()
        {
            var admin = Admin.Create(1, "name", "", "", "", "", "", "123123");
            var result = validation.TestValidate(admin);
            result.ShouldHaveValidationErrorFor(admin => admin.Family);
        }

        [Fact, Trait("Admin", "validation")]
        public void AdminValidation_ValidatingNotNullFamily_ShouldNotHaveError()
        {
            var admin = Admin.Create(1, "name", "family", "age", "nationalcode", "username", "email", "password");
            var result = validation.TestValidate(admin);
            result.ShouldNotHaveValidationErrorFor(admin => admin.Family);
        }

        [Fact, Trait("Admin", "validation")]
        public void AdminValidation_ValidatingNullDateOfBirth_ShouldHaveError()
        {
            var admin = Admin.Create(1, "name", "family", "", "nationalcode", "username", "email", "password");
            var result = validation.TestValidate(admin);
            result.ShouldHaveValidationErrorFor(admin => admin.DateofBirth);
        }

        [Fact , Trait("Admin", "validation")]
        public void AdminValidtion_ValidatingNotNullDateOfBirth_ShouldNotHaveError()
        {
            var admin = Admin.Create(1, "name", "family", "11/12/1344", "nationalcode", "username", "email", "password");
            var result = validation.TestValidate(admin);
            result.ShouldNotHaveValidationErrorFor(admin => admin.DateofBirth);
        }

        [Fact , Trait("Admin", "validation")]
        public void AdminValidation_ValidatingInvalidDateofBirth_ShouldHaveError()
        {
            var admin = Admin.Create(1, "name", "family", "13141/12412/3453", "nationalcode", "username", "email", "password");
            var result = validation.TestValidate(admin);
            result.ShouldHaveValidationErrorFor(admin => admin.DateofBirth);
        }

        [Fact , Trait("Admin", "validation")]
        public void AdminValidation_ValidatingNullNationalCode_ShouldHaveError()
        {
            var admin = Admin.Create(1, "name", "family", "", "", "username", "email", "password");
            var result = validation.TestValidate(admin);
            result.ShouldHaveValidationErrorFor(admin => admin.NationalCode);
        }

        [Fact, Trait("Admin", "validation")]
        public void AdminValidation_ValidateingValidNationalCode_ShouldNotHaveError()
        {
            var admin = Admin.Create(1, "name", "family", "", "0317144073", "username", "email", "password");
            var result = validation.TestValidate(admin);
            result.ShouldNotHaveValidationErrorFor(admin => admin.NationalCode);
        }

        [Fact , Trait("Admin", "validation")]
        public void AdminValidation_ValidatingInvalidNationalCode_ShouldHaveError()
        {
            var admin = Admin.Create(1, "name", "family", "", "124er214123", "username", "email", "password");
            var result = validation.TestValidate(admin);
            result.ShouldHaveValidationErrorFor(admin => admin.NationalCode);
        }

        [Fact , Trait("Admin", "validation")]
        public void AdminValidation_ValidatingNullUserName_ShouldHaveError()
        {
            var admin = Admin.Create(1, "name", "family", "", "0317144073", "", "email", "password");
            var result = validation.TestValidate(admin);
            result.ShouldHaveValidationErrorFor(admin => admin.UserName);
        }

        [Fact , Trait("Admin", "validation")]
        public void AdminValidation_ValidatingValidUserName_ShouldNotHaveError()
        {
            var admin = Admin.Create(1, "name", "family", "", "0317144073", "username", "email", "password");
            var result = validation.TestValidate(admin);
            result.ShouldNotHaveValidationErrorFor(admin => admin.UserName);
        }

        [Fact, Trait("Admin", "validation")]
        public void AdminValidation_ValidatingInvalidUserName_ShouldHaveError()
        {
            var admin = Admin.Create(1, "name", "family", "", "0317144073", "ffdfSDF$34", "email", "password");
            var result = validation.TestValidate(admin);
            result.ShouldHaveValidationErrorFor(admin => admin.UserName);
        }

        [Fact, Trait("Admin", "validation")]
        public void AdminValidation_ValidatingValidEmail_ShouldNotHaveError()
        {
            var admin = Admin.Create(1, "name", "family", "", "0317144073", "username", "javidle.fd@gmail.com", "password");
            var result = validation.TestValidate(admin);
            result.ShouldNotHaveValidationErrorFor(admin => admin.Email);
        }

        [Fact , Trait("Admin", "validation")]
        public void AdminValidationI_ValidatingNullEmail_ShouldHaveError()
        {
            var admin = Admin.Create(1, "name", "family", "", "0317144073", "username", "", "password");
            var result = validation.TestValidate(admin);
            result.ShouldHaveValidationErrorFor(admin => admin.Email);
        }

        [Fact , Trait("Admin", "validation")]
        public void AdminValidation_ValidatingInvalidEmail_ShouldHaveError()
        {
            var admin = Admin.Create(1, "name", "family", "", "0317144073", "username", "dfsdf223#3124", "password");
            var result = validation.TestValidate(admin);
            result.ShouldHaveValidationErrorFor(admin => admin.Email);
        }

        [Fact , Trait("Admin", "validation")]
        public void AdminValidation_ValidatingNullPassword_ShouldHaveError()
        {
            var admin = Admin.Create(1, "name", "family", "", "0317144073", "username", "email", "");
            var result = validation.TestValidate(admin);
            result.ShouldHaveValidationErrorFor(admin => admin.Password);
        }

        [Fact, Trait("Admin", "validation")]
        public void AdminValidation_ValidatingValidPassword_ShouldNotHaveError()
        {
            var admin = Admin.Create(1, "name", "family", "", "0317144073", "username", "email", "123#2fsda");
            var result = validation.TestValidate(admin);
            result.ShouldNotHaveValidationErrorFor(admin => admin.Password);
        }

        [Fact, Trait("Admin", "validation")]
        public void AdminValidation_ValidatingInvalidPassword_ShouldHaveError()
        {
            var admin = Admin.Create(1, "name", "family", "", "0317144073", "username", "email", "pass");
            var result = validation.TestValidate(admin);
            result.ShouldHaveValidationErrorFor(admin => admin.Password);
        }

        [Theory, Trait("Admin", "create")]
        [InlineData(2,"reza", "mohamadi", "0317144073","11/12/1399","javidleo","javidleo.ef@gmial.com","javidl123#21")]
        [InlineData(2,"Alireza", "Javadi", "0477786431", "29/12/1350","rezand","reza.sl@yahoo.com","123@35%fdf")]
        [InlineData(2,"mohamad", "Navidi", "0988309009", "11/10/1340","mohadamdf","mohamad@cloud.com","res1@2323:fdsfS")]
        public void CreateAdmin_CheckForCreatingSuccessfully_ReturnRanToCompletionStatusMessage(int id , string name ,string family , string nationalCode, string dateofbirth, string username ,string email , string password)
        {
            var result = service.Create(id, name, family, dateofbirth, nationalCode, username, email, password);
            result.Status.ToString().Should().Be("RanToCompletion");
        }

        [Theory, Trait("Admin", "create")]
        [InlineData(2, "reza", "mohamadi", "123d1123", "11/12/1399", "javidleo", "javidleo.ef@gmial.com", "javidl123#21")]
        [InlineData(2, "Alireza", "Javadi", "0477786431", "29/12/1350", "rezand", "reza.sl@yahoo.com", "123123123")]
        [InlineData(2, "mohamad", "Navidi", "0988309009", "11/10/1340", "MohammadReza", "mohamad@cloud.com", "res1@2323:fdsfS")]
        [InlineData(2, "mohamad", "reza23", "0988309009", "", "MohammadReza", "mohamad@cloud.com", "res1@2323:fdsfS")]
        public void CreateAdmin_CheckForCreateWhenSendInvalidDataToService_ThrowsNotAcceptableException(int id, string name, string family, string nationalCode, string dateofbirth, string username, string email, string password)
        {
            void result () => service.Create(id, name, family, dateofbirth, nationalCode, username, email, password);
            Assert.Throws<NotAcceptableException>(result);
        }
        
    }
}
