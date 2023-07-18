namespace ECom.Domain;

public static class DomainResult
{

  #region OK
  public static CustomResult Ok(string name) => CustomResult.Ok(name, "Success");
  public static CustomResult OkAdded(string name) => CustomResult.Ok(name, "Added");
  public static CustomResult OkAuthenticated(string name) => CustomResult.Ok(name, "Authenticated");
  public static CustomResult OkUpdated(string name) => CustomResult.Ok(name, "Updated");
  public static CustomResult OkRemoved(string name) => CustomResult.Ok(name, "Removed");
  public static CustomResult OkDeleted(string name) => CustomResult.Ok(name, "Deleted");
  public static CustomResult OkCleared(string name) => CustomResult.Ok(name, "Cleared");
  public static CustomResult OkNotChanged(string name) => CustomResult.Ok(name, "NotChanged");

  #endregion

  #region WARNINGS

  public static CustomResult Validation(string name,string message) => CustomResult.Validation(name, message);
  public static CustomResult Deleted(string name) => CustomResult.Warn(name, "Deleted");
  public static CustomResult Invalid(string name) => CustomResult.Warn(name, "Invalid");
  public static CustomResult EmptyTable(string name) => CustomResult.Warn(name, "EmptyTable");
  public static CustomResult NotFound(string name) => CustomResult.Warn(name, "NotFound");
  public static CustomResult AlreadyDisabled(string name) => CustomResult.Warn(name, "AlreadyDisabled");
  public static CustomResult AlreadyEnabled(string name) => CustomResult.Warn(name, "AlreadyEnabled");
  public static CustomResult AlreadyDeleted(string name) => CustomResult.Warn(name, "AlreadyDeleted");
  public static CustomResult AlreadyExists(string name) => CustomResult.Warn(name, "AlreadyExists");
  public static CustomResult AlreadyInUse(string name) => CustomResult.Warn(name, "AlreadyInUse");
  public static CustomResult NotVerified(string name) => CustomResult.Warn(name, "NotVerified");
  public static CustomResult VerificationRequired(string name) => CustomResult.Warn(name, "VerificationRequired");
  public static CustomResult TooShort(string name) => CustomResult.Warn(name, "TooShort");
  public static CustomResult TooLong(string name) => CustomResult.Warn(name, "TooShort");
  public static CustomResult CanNotContainSpace(string name) => CustomResult.Warn(name, "CanNotContainSpace");
  public static CustomResult DoNotMatch(string name) => CustomResult.Warn(name, "DoNotMatch");
  public static CustomResult WrongPassword() => CustomResult.Warn("Password", "Wrong");
  public static CustomResult None(string name) => CustomResult.Warn(name, "NOne");
  #endregion

  #region ERRORS
  public static CustomResult Unauthorized(string name = "User") => CustomResult.Warn(name, "Unauthorized");
  public static CustomResult Forbidden(string name = "User") => CustomResult.Warn(name, "Forbidden");
  public static CustomResult UnderMaintenance() => CustomResult.Error("System", "UnderMaintenance");
  public static CustomResult DbInternalError(string operationName) => CustomResult.Critical(operationName, "DbInternalError");

  #endregion

  public static CustomResult Exception(Exception exception, string name) => CustomResult.Critical(exception, name);

  public static CustomResult NotDeleted(string name)  => CustomResult.Warn(name, "NotDeleted");

  public static CustomResult NotChanged(string name) => CustomResult.Warn(name, "NotChanged");
}