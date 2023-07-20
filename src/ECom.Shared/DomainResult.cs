namespace ECom.Shared;

public static class DomainResult
{
  public static CustomResult Exception(Exception exception, string name) {
    return CustomResult.Critical(exception, name);
  }

  public static CustomResult NotDeleted(string name) {
    return CustomResult.Warn(name, "not_deleted");
  }

  public static CustomResult NotChanged(string name) {
    return CustomResult.Warn(name, "not_changed");
  }

  #region OK

  public static CustomResult Ok(string name) {
    return CustomResult.Ok(name, "success");
  }

  public static CustomResult OkAdded(string name) {
    return CustomResult.Ok(name, "added");
  }

  public static CustomResult OkAuthenticated(string name) {
    return CustomResult.Ok(name, "authenticated");
  }

  public static CustomResult OkUpdated(string name) {
    return CustomResult.Ok(name, "updated");
  }

  public static CustomResult OkRemoved(string name) {
    return CustomResult.Ok(name, "removed");
  }

  public static CustomResult OkDeleted(string name) {
    return CustomResult.Ok(name, "deleted");
  }

  public static CustomResult OkCleared(string name) {
    return CustomResult.Ok(name, "cleared");
  }

  public static CustomResult OkNotChanged(string name) {
    return CustomResult.Ok(name, "not_changed");
  }

  #endregion

  #region WARNINGS

  public static CustomResult Validation(string name, string message) {
    return CustomResult.Validation(name, message);
  }

  public static CustomResult Deleted(string name) {
    return CustomResult.Warn(name, "deleted");
  }

  public static CustomResult Invalid(string name) {
    return CustomResult.Warn(name, "invalid");
  }

  public static CustomResult EmptyTable(string name) {
    return CustomResult.Warn(name, "empty_table");
  }

  public static CustomResult NotFound(string name) {
    return CustomResult.Warn(name, "not_found");
  }

  public static CustomResult AlreadyDisabled(string name) {
    return CustomResult.Warn(name, "already_disabled");
  }

  public static CustomResult AlreadyEnabled(string name) {
    return CustomResult.Warn(name, "already_enabled");
  }

  public static CustomResult AlreadyDeleted(string name) {
    return CustomResult.Warn(name, "already_deleted");
  }

  public static CustomResult AlreadyExists(string name) {
    return CustomResult.Warn(name, "already_exists");
  }

  public static CustomResult AlreadyInUse(string name) {
    return CustomResult.Warn(name, "already_in_use");
  }

  public static CustomResult NotVerified(string name) {
    return CustomResult.Warn(name, "not_verified");
  }

  public static CustomResult VerificationRequired(string name) {
    return CustomResult.Warn(name, "verification_required");
  }

  public static CustomResult TooShort(string name) {
    return CustomResult.Warn(name, "too_short");
  }

  public static CustomResult TooLong(string name) {
    return CustomResult.Warn(name, "too_long");
  }

  public static CustomResult CanNotContainSpace(string name) {
    return CustomResult.Warn(name, "can_not_contain_space");
  }

  public static CustomResult DoNotMatch(string name) {
    return CustomResult.Warn(name, "do_not_match");
  }

  public static CustomResult WrongPassword() {
    return CustomResult.Warn("Password", "wrong");
  }

  public static CustomResult None(string name) {
    return CustomResult.Warn(name, "none");
  }

  #endregion

  #region ERRORS

  public static CustomResult Unauthorized(string name = "User") {
    return CustomResult.Warn(name, "unauthorized");
  }

  public static CustomResult Forbidden(string name = "User") {
    return CustomResult.Warn(name, "forbidden");
  }

  public static CustomResult UnderMaintenance() {
    return CustomResult.Error("System", "under_maintenance");
  }

  public static CustomResult DbInternalError(string operationName) {
    return CustomResult.Critical(operationName, "db_internal_error");
  }

  #endregion

  public static CustomResult NotSupported(string operationName) {
    return CustomResult.Critical(operationName, "not_supported");
  }
  public static CustomResult NotSupported() {
    return CustomResult.Critical("action","not_supported");
  }

  public static CustomResult OkNone(string empty = "") {
    return CustomResult.Ok("", "none");

  }

  public static CustomResult OkRecovered(string name) {
    return CustomResult.Ok(name, "recovered");

  }
}