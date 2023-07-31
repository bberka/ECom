namespace ECom.Shared;

public static class DomainResult
{
  public static CustomResult Exception(Exception exception, string name) {
    return CustomResult.Critical(exception, new LocParam("name", name));
  }
  public static CustomResult InvalidState(string name) {
    return CustomResult.Warn("invalid_state", new LocParam("name", name));
  }

  public static CustomResult NotDeleted(string name) {
    return CustomResult.Warn("not_deleted", new LocParam("name", name));
  }

  public static CustomResult NotChanged(string name) {
    return CustomResult.Warn("not_changed", new LocParam("name", name));
  }

  public static CustomResult NotSupported(string operationName = "action") {
    return CustomResult.Critical("not_supported", new LocParam("name", operationName));
  }

  public static CustomResult OkRecovered(string name) {
    return CustomResult.OkParam("ok_recovered", new LocParam("name", name));
  }

  #region OK

  public static CustomResult Success(string error, string name = "") {
    return CustomResult.OkParam(error, new LocParam("name", name));
  }
  public static CustomResult Ok(string name) {
    return CustomResult.OkParam("success", new LocParam("name", name));
  }

  public static CustomResult OkAdded(string name) {
    return CustomResult.OkParam("ok_added", new LocParam("name", name));
  }

  public static CustomResult OkAuthenticated(string name) {
    return CustomResult.OkParam("ok_authenticated", new LocParam("name", name));
  }

  public static CustomResult OkUpdated(string name) {
    return CustomResult.OkParam("ok_updated", new LocParam("name", name));
  }

  public static CustomResult OkRemoved(string name) {
    return CustomResult.OkParam("ok_removed", new LocParam("name", name));
  }

  public static CustomResult OkDeleted(string name) {
    return CustomResult.OkParam("ok_deleted", new LocParam("name", name));
  }

  public static CustomResult OkCleared(string name) {
    return CustomResult.OkParam("ok_cleared", new LocParam("name", name));
  }

  public static CustomResult OkNotChanged(string name) {
    return CustomResult.OkParam("ok_not_changed", new LocParam("name", name));
  }

  #endregion

  #region WARNINGS

  public static CustomResult Validation(string name, string message) {
    return CustomResult.Validation(message, new LocParam("name", name));
  }

  public static CustomResult Deleted(string name) {
    return CustomResult.Warn("deleted", new LocParam("name", name));
  }

  public static CustomResult Invalid(string name) {
    return CustomResult.Warn("invalid", new LocParam("name", name));
  }

  public static CustomResult EmptyTable(string name) {
    return CustomResult.Warn("empty_table", new LocParam("name", name));
  }

  public static CustomResult NotFound(string name) {
    return CustomResult.Warn("not_found", new LocParam("name", name));
  }

  public static CustomResult AlreadyDisabled(string name) {
    return CustomResult.Warn("already_disabled", new LocParam("name", name));
  }

  public static CustomResult AlreadyEnabled(string name) {
    return CustomResult.Warn("already_enabled", new LocParam("name", name));
  }

  public static CustomResult AlreadyDeleted(string name) {
    return CustomResult.Warn("already_deleted", new LocParam("name", name));
  }

  public static CustomResult AlreadyExists(string name) {
    return CustomResult.Warn("already_exists", new LocParam("name", name));
  }

  public static CustomResult AlreadyInUse(string name) {
    return CustomResult.Warn("already_in_use", new LocParam("name", name));
  }

  public static CustomResult NotVerified(string name) {
    return CustomResult.Warn("not_verified", new LocParam("name", name));
  }

  public static CustomResult VerificationRequired(string name) {
    return CustomResult.Warn("verification_required", new LocParam("name", name));
  }

  public static CustomResult TooShort(string name) {
    return CustomResult.Warn("too_short", new LocParam("name", name));
  }
  public static CustomResult NoAccountFound(string name) {
    return CustomResult.Warn("no_account_found", new LocParam("name", name));
  }
  public static CustomResult TooLong(string name) {
    return CustomResult.Warn("too_long", new LocParam("name", name));
  }

  public static CustomResult CanNotContainSpace(string name) {
    return CustomResult.Warn("can_not_contain_space", new LocParam("name", name));
  }

  public static CustomResult DoNotMatch(string name) {
    return CustomResult.Warn("do_not_match", new LocParam("name", name));
  }

  public static CustomResult WrongPassword() {
    return CustomResult.Warn("wrong_password");
  }

  public static CustomResult None(string name) {
    return CustomResult.Warn("none", new LocParam("name", name));
  }

  #endregion

  #region ERRORS

  public static CustomResult Unauthorized(string name = "User") {
    return CustomResult.Warn("unauthorized", new LocParam("name", name));
  }

  public static CustomResult Forbidden(string name = "User") {
    return CustomResult.Warn("forbidden", new LocParam("name", name));
  }

  public static CustomResult UnderMaintenance() {
    return CustomResult.Error("under_maintenance");
  }

  public static CustomResult DbInternalError(string operationName) {
    return CustomResult.Critical("db_internal_error", new LocParam("name", operationName));
  }

  #endregion
  public static CustomResult MaxCountReached(string name, int maxCountParam) {
    return CustomResult.Error("max_count_reached", new LocParam("name", name), new LocParam("count", maxCountParam));
  }

  public static CustomResult CannotSetExpired(string name) {
    return CustomResult.Error("can_not_set_expired", new LocParam("name", name));

  }
  public static CustomResult CanNotDelete(string name) {
    return CustomResult.Error("can_not_delete", new LocParam("name", name));
  }
  public static CustomResult CanNotDeleteBcRelation(string mainObjectName, string relationName) {
    return CustomResult.Error("can_not_delete_db_relation", new LocParam("objectName",mainObjectName), new LocParam("relationName",relationName));
  }
}