namespace ECom.Shared;

public static class DomainResult
{
  public static CustomResult Exception(Exception exception, string name) {
    return CustomResult.Critical(exception, name);
  }

  public static CustomResult NotDeleted(string name) {
    return CustomResult.Warn(name, "NotDeleted");
  }

  public static CustomResult NotChanged(string name) {
    return CustomResult.Warn(name, "NotChanged");
  }

  #region OK

  public static CustomResult Ok(string name) {
    return CustomResult.Ok(name, "Success");
  }

  public static CustomResult OkAdded(string name) {
    return CustomResult.Ok(name, "Added");
  }

  public static CustomResult OkAuthenticated(string name) {
    return CustomResult.Ok(name, "Authenticated");
  }

  public static CustomResult OkUpdated(string name) {
    return CustomResult.Ok(name, "Updated");
  }

  public static CustomResult OkRemoved(string name) {
    return CustomResult.Ok(name, "Removed");
  }

  public static CustomResult OkDeleted(string name) {
    return CustomResult.Ok(name, "Deleted");
  }

  public static CustomResult OkCleared(string name) {
    return CustomResult.Ok(name, "Cleared");
  }

  public static CustomResult OkNotChanged(string name) {
    return CustomResult.Ok(name, "NotChanged");
  }

  #endregion

  #region WARNINGS

  public static CustomResult Validation(string name, string message) {
    return CustomResult.Validation(name, message);
  }

  public static CustomResult Deleted(string name) {
    return CustomResult.Warn(name, "Deleted");
  }

  public static CustomResult Invalid(string name) {
    return CustomResult.Warn(name, "Invalid");
  }

  public static CustomResult EmptyTable(string name) {
    return CustomResult.Warn(name, "EmptyTable");
  }

  public static CustomResult NotFound(string name) {
    return CustomResult.Warn(name, "NotFound");
  }

  public static CustomResult AlreadyDisabled(string name) {
    return CustomResult.Warn(name, "AlreadyDisabled");
  }

  public static CustomResult AlreadyEnabled(string name) {
    return CustomResult.Warn(name, "AlreadyEnabled");
  }

  public static CustomResult AlreadyDeleted(string name) {
    return CustomResult.Warn(name, "AlreadyDeleted");
  }

  public static CustomResult AlreadyExists(string name) {
    return CustomResult.Warn(name, "AlreadyExists");
  }

  public static CustomResult AlreadyInUse(string name) {
    return CustomResult.Warn(name, "AlreadyInUse");
  }

  public static CustomResult NotVerified(string name) {
    return CustomResult.Warn(name, "NotVerified");
  }

  public static CustomResult VerificationRequired(string name) {
    return CustomResult.Warn(name, "VerificationRequired");
  }

  public static CustomResult TooShort(string name) {
    return CustomResult.Warn(name, "TooShort");
  }

  public static CustomResult TooLong(string name) {
    return CustomResult.Warn(name, "TooShort");
  }

  public static CustomResult CanNotContainSpace(string name) {
    return CustomResult.Warn(name, "CanNotContainSpace");
  }

  public static CustomResult DoNotMatch(string name) {
    return CustomResult.Warn(name, "DoNotMatch");
  }

  public static CustomResult WrongPassword() {
    return CustomResult.Warn("Password", "Wrong");
  }

  public static CustomResult None(string name) {
    return CustomResult.Warn(name, "NOne");
  }

  #endregion

  #region ERRORS

  public static CustomResult Unauthorized(string name = "User") {
    return CustomResult.Warn(name, "Unauthorized");
  }

  public static CustomResult Forbidden(string name = "User") {
    return CustomResult.Warn(name, "Forbidden");
  }

  public static CustomResult UnderMaintenance() {
    return CustomResult.Error("System", "UnderMaintenance");
  }

  public static CustomResult DbInternalError(string operationName) {
    return CustomResult.Critical(operationName, "DbInternalError");
  }

  #endregion
}