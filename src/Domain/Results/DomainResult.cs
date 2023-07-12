namespace ECom.Domain.Results;

public static class DomainResult
{
  public static Result UnderMaintenanceResult() {
    return Result.Error("UnderMaintenance");
  }

  public static Result DbInternalErrorResult(string operationName) {
    return Result.Fatal(operationName);
  }

  public static Result DbInternalErrorResult() {
    return Result.Fatal("DbInternalError");
  }

  public static class User
  {
    public static Result NotFoundResult() {
      return Result.Warn("User.NotFound");
    }

    public static Result NotValidResult() {
      return Result.Warn("User.NotValid");
    }

    public static Result NotAuthorizedResult() {
      return Result.Error("User.NotAuthorized");
    }

    public static Result DeletedResult() {
      return Result.Warn("User.Deleted");
    }

    //Success
    public static Result RegisterSuccessResult() {
      return Result.Success("User.Register");
    }

    public static Result ChangePasswordSuccessResult() {
      return Result.Success("User.ChangePassword");
    }

    public static Result UpdateSuccessResult() {
      return Result.Success("User.Update");
    }
  }

  public static class Admin
  {
    public static Result NotFoundResult() {
      return Result.Warn("Admin.NotFound");
    }

    public static Result NotHavePermissionResult() {
      return Result.Error("Admin.NotHavePermission");
    }

    public static Result NotAuthorizedResult() {
      return Result.Error("Admin.NotAuthorized");
    }

    public static Result NotValidResult() {
      return Result.Warn("Admin.NotValid");
    }

    public static Result DeletedResult() {
      return Result.Warn("Admin.Deleted");
    }

    public static Result AlreadyDeletedResult() {
      return Result.Warn("Admin.AlreadyDeleted");
    }


    public static Result AddSuccessResult() {
      return Result.Success("Admin.Add");
    }

    public static Result ChangePasswordSuccessResult() {
      return Result.Success("Admin.ChangePassword");
    }

    public static Result UpdateSuccessResult() {
      return Result.Success("Admin.Update");
    }

    public static Result DeleteSuccessResult() {
      return Result.Success("Admin.Delete");
    }
  }

  public static class Product
  {
    public static Result NotFoundResult() {
      return Result.Warn("Product.NotFound");
    }

    public static Result NotValidResult() {
      return Result.Warn("Product.NotValid");
    }

    public static Result DeletedResult() {
      return Result.Warn("Product.Deleted");
    }

    public static Result UpdateSuccessResult() {
      return Result.Success("Product.Update");
    }

    public static Result AddSuccessResult() {
      return Result.Success("Product.Add");
    }
  }

  public static class Role
  {
    public static Result NotFoundResult() {
      return Result.Warn("Role.NotFound");
    }

    public static Result NotValidResult() {
      return Result.Warn("Role.NotValid");
    }


    public static Result DeletedResult() {
      return Result.Warn("Role.Deleted");
    }

    public static Result UpdateSuccessResult() {
      return Result.Success("Role.Update");
    }

    public static Result AddSuccessResult() {
      return Result.Success("Role.Add");
    }
  }

  public static class ProductComment
  {
    public static Result NotFoundResult() {
      return Result.Warn("ProductComment.NotFound");
    }

    public static ResultData<int> AddSuccessResult(int value) {
      return value;
    }
  }

  public static class ProductCommentImage
  {
    public static Result NotFoundResult() {
      return Result.Warn("ProductCommentImage.NotFound");
    }

    public static ResultData<int> AddSuccessResult(int value) {
      return value;
    }
  }

  public static class FavoriteProduct
  {
    public static Result NotFoundResult() {
      return Result.Warn("FavoriteProduct.NotFound");
    }

    public static Result DeletedResult() {
      return Result.Warn("FavoriteProduct.Deleted");
    }

    public static Result AddSuccessResult() {
      return Result.Success("FavoriteProduct.Add");
    }

    public static Result RemoveSuccessResult() {
      return Result.Success("FavoriteProduct.Remove");
    }
  }

  public static class Option
  {
    public static Result NotFoundResult() {
      return Result.Warn("Option.NotFound");
    }

    public static Result UpdateSuccessResult() {
      return Result.Success("Option.Update");
    }
  }

  public static class Address
  {
    public static Result NotFoundResult() {
      return Result.Warn("Address.NotFound");
    }

    public static Result AlreadyDeletedResult() {
      return Result.Error("Address.AlreadyDeleted");
    }

    public static Result DeletedResult() {
      return Result.Error("Address.Deleted");
    }

    public static Result UpdateSuccessResult() {
      return Result.Success("Address.Update");
    }

    public static Result DeleteSuccessResult() {
      return Result.Success("Address.Delete");
    }

    public static Result AddSuccessResult() {
      return Result.Success("Address.Add");
    }
  }

  public static class Collection
  {
    public static Result NotFoundResult() {
      return Result.Warn("Collection.NotFound");
    }

    public static Result UpdateSuccessResult() {
      return Result.Success("Collection.Update");
    }

    public static Result CreateSuccessResult() {
      return Result.Success("Collection.Create");
    }

    public static Result DeleteSuccessResult() {
      return Result.Success("Collection.Delete");
    }
  }

  public static class CompanyInformation
  {
    public static Result NotFoundResult() {
      return Result.Warn("CompanyInformation.NotFound");
    }

    public static Result UpdateSuccessResult() {
      return Result.Success("CompanyInformation.Update");
    }
  }

  public static class CargoOption
  {
    public static Result NotFoundResult() {
      return Result.Warn("CargoOption.NotFound");
    }

    public static Result UpdateSuccessResult() {
      return Result.Success("CargoOption.Update");
    }

    public static Result DeleteSuccessResult() {
      return Result.Success("CargoOption.Delete");
    }
  }

  public static class Category
  {
    public static Result NotFoundResult() {
      return Result.Warn("Category.NotFound");
    }

    public static Result NotValidResult() {
      return Result.Warn("Category.NotValid");
    }

    public static Result UpdateSuccessResult() {
      return Result.Success("Category.Update");
    }

    public static Result AddSuccessResult() {
      return Result.Success("Category.Add");
    }

    public static Result DeleteSuccessResult() {
      return Result.Success("Category.Delete");
    }
  }

  public static class SubCategory
  {
    public static Result NotFoundResult() {
      return Result.Warn("SubCategory.NotFound");
    }

    public static Result NotValidResult() {
      return Result.Warn("SubCategory.NotValid");
    }

    public static Result UpdateSuccessResult() {
      return Result.Success("SubCategory.Update");
    }

    public static Result AddSuccessResult() {
      return Result.Success("SubCategory.Add");
    }

    public static Result DeleteSuccessResult() {
      return Result.Success("SubCategory.Delete");
    }
  }

  public static class StockChange
  {
    public static Result AddSuccessResult() {
      return Result.Success("StockChange.Add");
    }
  }

  public static class Supplier
  {
    public static Result NotFoundResult() {
      return Result.Warn("Supplier.NotFound");
    }

    public static Result UpdateSuccessResult() {
      return Result.Success("Supplier.Update");
    }

    public static Result AddSuccessResult() {
      return Result.Success("Supplier.Add");
    }

    public static Result DeleteSuccessResult() {
      return Result.Success("Supplier.Delete");
    }
  }

  public static class Image
  {
    public static Result NotFoundResult() {
      return Result.Warn("Image.NotFound");
    }
  }

  public static class Language
  {
    public static Result NotValidResult() {
      return Result.Warn("Language.NotValid");
    }
  }

  public static class PaymentOption
  {
    public static Result NotFoundResult() {
      return Result.Warn("PaymentOption.NotFound");
    }

    public static Result UpdateSuccessResult() {
      return Result.Success("PaymentOption.Update");
    }
  }

  public static class SmtpOption
  {
    public static Result NotFoundResult() {
      return Result.Warn("SmtpOption.NotFound");
    }

    public static Result UpdateSuccessResult() {
      return Result.Success("SmtpOption.Update");
    }
  }

  public static class Announcement
  {
    public static Result NotFoundResult() {
      return Result.Warn("Announcement.NotFound");
    }

    public static Result UpdateSuccessResult() {
      return Result.Success("Announcement.Update");
    }

    public static Result AddSuccessResult() {
      return Result.Success("Announcement.Add");
    }

    public static Result DeleteSuccessResult() {
      return Result.Success("Announcement.Delete");
    }
  }

  public static class Cart
  {
    public static Result NotFoundResult() {
      return Result.Warn("Cart.NotFound");
    }

    public static Result ClearSuccessResult() {
      return Result.Success("Cart.Clear");
    }

    public static Result AddProductSuccessResult() {
      return Result.Success("Cart.AddProduct");
    }

    public static Result RemoveProductSuccessResult() {
      return Result.Success("Cart.RemoveProduct");
    }
  }

  public static class Slider
  {
    public static Result NotFoundResult() {
      return Result.Warn("Slider.NotFound");
    }

    public static Result DeletedResult() {
      return Result.Warn("Slider.Deleted");
    }

    public static Result UpdateSuccessResult() {
      return Result.Success("Slider.Update");
    }

    public static Result AddSuccessResult() {
      return Result.Success("Slider.Add");
    }

    public static Result DeleteSuccessResult() {
      return Result.Success("Slider.Delete");
    }
  }


  public static class Action
  {
    public static Result AlreadyDeletedResult(string relatedObjectName) {
      return Result.Warn($"{relatedObjectName}.AlreadyDeleted");
    }

    public static Result AlreadyExistsResult(string relatedObjectName) {
      return Result.Warn($"{relatedObjectName}.AlreadyExists");
    }
  }


  public static class Base
  {
    public static Result EmailIsInUseResult() {
      return Result.Warn("EmailAddress.AlreadyInUse");
    }

    public static Result EmailNotVerifiedResult() {
      return Result.Warn("EmailAddress.NotVerified");
    }

    public static Result FirstNameIsTooShort() {
      return Result.Warn("FirstName.TooShort");
    }

    public static Result FirstNameIsTooLong() {
      return Result.Warn("FirstName.TooLong");
    }

    public static Result LastNameIsTooShort() {
      return Result.Warn("LastName.TooShort");
    }

    public static Result LastNameIsTooLong() {
      return Result.Warn("LastName.TooLong");
    }

    public static Result PasswordIsTooShort() {
      return Result.Warn("Password.TooShort");
    }

    public static Result PasswordIsTooLong() {
      return Result.Warn("Password.TooLong");
    }

    public static Result PasswordCanNotContainSpaceResult() {
      return Result.Warn("Password.CanNotContainSpace");
    }

    public static Result PasswordNotMatchResult() {
      return Result.Warn("Password.NotMatch");
    }

    public static Result PasswordWrongResult() {
      return Result.Warn("Password.Wrong");
    }
  }
}