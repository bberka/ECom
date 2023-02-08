using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Results
{
    public static class DomainResult
    {
        public static class User
        {
            public static Result NotFoundResult(ushort rv) => Result.Warn(rv,"User.NotFound");
            public static Result NotValidResult(ushort rv) => Result.Warn(rv,"User.NotValid");
            public static Result NotAuthorizedResult(ushort rv) => Result.Error(rv,"User.NotAuthorized");
            public static Result DeletedResult(ushort rv) => Result.Warn(rv,"User.Deleted");
            public static Result TestAccountCanNotBeUsedResult(ushort rv) => Result.Error(rv, "User.TestAccountCanNotBeUsed");
            public static Result RegisterSuccessResult() => Result.Success("User.Register");
            public static Result ChangePasswordSuccessResult() => Result.Success("User.ChangePassword");
            public static Result UpdateSuccessResult() => Result.Success("User.Update");
        }

        public static class Admin
        {
            public static Result NotFoundResult(ushort rv) => Result.Warn(rv, "Admin.NotFound");
            public static Result NotHavePermissionResult(ushort rv) => Result.Error(rv, "Admin.NotHavePermission");
            public static Result NotAuthorizedResult(ushort rv) => Result.Error(rv, "Admin.NotAuthorized");
            public static Result NotValidResult(ushort rv) => Result.Warn(rv, "Admin.NotValid");
            public static Result DeletedResult(ushort rv) => Result.Warn(rv, "Admin.Deleted");
            public static Result AlreadyDeletedResult(ushort rv) => Result.Warn(rv, "Admin.AlreadyDeleted");
            public static Result TestAccountCanNotBeUsedResult(ushort rv) => Result.Warn(rv, "Admin.TestAccountCanNotBeUsed");


            public static Result AddSuccessResult() => Result.Success("Admin.Add");
            public static Result ChangePasswordSuccessResult() => Result.Success("Admin.ChangePassword");
            public static Result UpdateSuccessResult() => Result.Success("Admin.Update");
            public static Result DeleteSuccessResult() => Result.Success("Admin.Delete");


        }
        public static class Product
        {
            public static Result NotFoundResult(ushort rv) => Result.Warn(rv, "Product.NotFound");
            public static Result NotValidResult(ushort rv) => Result.Warn(rv, "Product.NotValid");
            public static Result DeletedResult(ushort rv) => Result.Warn(rv, "Product.Deleted");
            public static Result UpdateSuccessResult() => Result.Success("Product.Update");
            public static Result AddSuccessResult() => Result.Success("Product.Add");
        }
        public static class FavoriteProduct
        {
            public static Result NotFoundResult(ushort rv) => Result.Warn(rv, "FavoriteProduct.NotFound");
            public static Result DeletedResult(ushort rv) => Result.Warn(rv, "FavoriteProduct.Deleted");
            public static Result AddSuccessResult() => Result.Success("FavoriteProduct.Add");
            public static Result RemoveSuccessResult() => Result.Success("FavoriteProduct.Remove");
        }
        public static class Option
        {
            public static Result NotFoundResult(ushort rv) => Result.Warn(rv, "Option.NotFound");
            public static Result UpdateSuccessResult() => Result.Success("Option.Update");
        }
        public static class Address
        {
            public static Result NotFoundResult(ushort rv) => Result.Warn(rv, "Address.NotFound");
            public static Result AlreadyDeletedResult(ushort rv) => Result.Error(rv, "Address.AlreadyDeleted");
            public static Result DeletedResult(ushort rv) => Result.Error(rv, "Address.Deleted");
            public static Result UpdateSuccessResult() => Result.Success("Address.Update");
            public static Result DeleteSuccessResult() => Result.Success("Address.Delete");
            public static Result AddSuccessResult() => Result.Success("Address.Add");
        }
        public static class Collection
        {
            public static Result NotFoundResult(ushort rv) => Result.Warn(rv, "Collection.NotFound");
            public static Result UpdateSuccessResult() => Result.Success("Collection.Update");
            public static Result CreateSuccessResult() => Result.Success("Collection.Create");
            public static Result DeleteSuccessResult() => Result.Success("Collection.Delete");
        }
        public static class CompanyInformation
        {
            public static Result NotFoundResult(ushort rv) => Result.Warn(rv, "CompanyInformation.NotFound");
            public static Result UpdateSuccessResult() => Result.Success("CompanyInformation.Update");

        }
        public static class CargoOption
        {
            public static Result NotFoundResult(ushort rv) => Result.Warn(rv, "CargoOption.NotFound");
            public static Result UpdateSuccessResult() => Result.Success("CargoOption.Update");
            public static Result DeleteSuccessResult() => Result.Success("CargoOption.Delete");
        }
        public static class Category
        {
            public static Result NotFoundResult(ushort rv) => Result.Warn(rv, "Category.NotFound");
            public static Result NotValidResult(ushort rv) => Result.Warn(rv, "Category.NotValid");
            public static Result UpdateSuccessResult() => Result.Success("Category.Update");
            public static Result AddSuccessResult() => Result.Success("Category.Add");
            public static Result DeleteSuccessResult() => Result.Success("Category.Delete");

        }
        public static class SubCategory
        {
            public static Result NotFoundResult(ushort rv) => Result.Warn(rv, "SubCategory.NotFound");
            public static Result NotValidResult(ushort rv) => Result.Warn(rv, "SubCategory.NotValid");
            public static Result UpdateSuccessResult() => Result.Success("SubCategory.Update");
            public static Result AddSuccessResult() => Result.Success("SubCategory.Add");
            public static Result DeleteSuccessResult() => Result.Success("SubCategory.Delete");

        }
        public static class Image
        {
            public static Result NotFoundResult(ushort rv) => Result.Warn(rv, "Image.NotFound");
        }
        public static class Language
        {
            public static Result NotValidResult(ushort rv) => Result.Warn(rv, "Language.NotValid");
        }
        public static class PaymentOption
        {
            public static Result NotFoundResult(ushort rv) => Result.Warn(rv, "PaymentOption.NotFound");
            public static Result UpdateSuccessResult() => Result.Success("PaymentOption.Update");
        }
        public static class SmtpOption
        {
            public static Result NotFoundResult(ushort rv) => Result.Warn(rv, "SmtpOption.NotFound");
            public static Result UpdateSuccessResult() => Result.Success("SmtpOption.Update");
        }
        public static class Announcement
        {
            public static Result NotFoundResult(ushort rv) => Result.Warn(rv, "Announcement.NotFound");
            public static Result UpdateSuccessResult() => Result.Success("Announcement.Update");
            public static Result AddSuccessResult() => Result.Success("Announcement.Add");
            public static Result DeleteSuccessResult() => Result.Success("Announcement.Delete");
        }

        public static class Cart
        {
            public static Result NotFoundResult(ushort rv) => Result.Warn(rv, "Cart.NotFound");
            public static Result ClearSuccessResult() => Result.Success("Cart.Clear");
            public static Result AddProductSuccessResult() => Result.Success("Cart.AddProduct");
            public static Result RemoveProductSuccessResult() => Result.Success("Cart.RemoveProduct");

        }

        public static class Action
        {
            public static Result AlreadyDeletedResult(ushort rv,string relatedObjectName) => Result.Warn(rv,$"{relatedObjectName}.AlreadyDeleted");
            public static Result AlreadyExistsResult(ushort rv,string relatedObjectName) => Result.Warn(rv,$"{relatedObjectName}.AlreadyExists");

        }

        
        public  static class Base
        {
            public static Result EmailIsInUseResult(ushort rv) => Result.Warn(rv,"EmailAddress.AlreadyInUse");
            public static Result EmailNotVerifiedResult(ushort rv) => Result.Warn(rv,"EmailAddress.NotVerified");

            public static Result FirstNameIsTooShort(ushort rv) => Result.Warn(rv, "FirstName.TooShort");
            public static Result FirstNameIsTooLong(ushort rv) => Result.Warn(rv, "FirstName.TooLong");

            public static Result LastNameIsTooShort(ushort rv) => Result.Warn(rv, "LastName.TooShort");
            public static Result LastNameIsTooLong(ushort rv) => Result.Warn(rv, "LastName.TooLong");

            public static Result PasswordIsTooShort(ushort rv) => Result.Warn(rv, "Password.TooShort");
            public static Result PasswordIsTooLong(ushort rv) => Result.Warn(rv, "Password.TooLong");
            public static Result PasswordCanNotContainSpaceResult(ushort rv) => Result.Warn(rv, "Password.CanNotContainSpace");
            public static Result PasswordNotMatchResult(ushort rv) => Result.Warn(rv,"Password.NotMatch");
            public static Result PasswordWrongResult(ushort rv) => Result.Warn(rv,"Password.Wrong");


        }
        public static Result UnderMaintenanceResult() => Result.Error(ushort.MaxValue, "UnderMaintenance");

        public static Result DbInternalErrorResult(ushort rv, string operationName) => Result.Fatal(rv, operationName);
        public static Result DbInternalErrorResult(ushort rv) => Result.Fatal(rv,"DbInternalError");

        public static Result ValidationErrorResult(ushort rv, string propertyName, string errorCode) =>
            Result.Warn(rv, $"{propertyName}.{errorCode}");
    }
}
