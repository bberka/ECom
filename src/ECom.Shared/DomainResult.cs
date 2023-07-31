namespace ECom.Shared;

public static class DomainResult
{
  public static CustomResult Exception(Exception exception, string name) {
    return CustomResult.Critical(exception, name);
  }
  public static CustomResult InvalidState(string name) {
    return CustomResult.Warn("invalid_state", name);
  }

  public static CustomResult NotDeleted(string name) {
    return CustomResult.Warn("not_deleted", name);
  }

  public static CustomResult NotChanged(string name) {
    return CustomResult.Warn("not_changed", name);
  }

  public static CustomResult NotSupported(string operationName) {
    return CustomResult.Critical("not_supported", operationName);
  }

  public static CustomResult NotSupported() {
    return CustomResult.Critical("action", "not_supported");
  }

  public static CustomResult OkRecovered(string name) {
    return CustomResult.OkParam( "ok_recovered",name);
  }

  #region OK

  public static CustomResult Success(string error, string name = "") {
    return CustomResult.OkParam(error, name);
  }
  public static CustomResult Ok(string name) {
    return CustomResult.OkParam("success",name);
  }

  public static CustomResult OkAdded(string name) {
    return CustomResult.OkParam("ok_added", name);
  }

  public static CustomResult OkAuthenticated(string name) {
    return CustomResult.OkParam("ok_authenticated", name);
  }

  public static CustomResult OkUpdated(string name) {
    return CustomResult.OkParam("ok_updated", name);
  }

  public static CustomResult OkRemoved(string name) {
    return CustomResult.OkParam("ok_removed", name);
  }

  public static CustomResult OkDeleted(string name) {
    return CustomResult.OkParam("ok_deleted", name);
  }

  public static CustomResult OkCleared(string name) {
    return CustomResult.OkParam("ok_cleared", name);
  }

  public static CustomResult OkNotChanged(string name) {
    return CustomResult.OkParam("ok_not_changed", name);
  }

  #endregion

  #region WARNINGS

  public static CustomResult Validation(string name, string message) {
    return CustomResult.Validation(name, message);
  }

  public static CustomResult Deleted(string name) {
    return CustomResult.Warn("deleted", name);
  }

  public static CustomResult Invalid(string name) {
    return CustomResult.Warn("invalid", name);
  }

  public static CustomResult EmptyTable(string name) {
    return CustomResult.Warn("empty_table", name);
  }

  public static CustomResult NotFound(string name) {
    return CustomResult.Warn("not_found", name);
  }

  public static CustomResult AlreadyDisabled(string name) {
    return CustomResult.Warn("already_disabled", name);
  }

  public static CustomResult AlreadyEnabled(string name) {
    return CustomResult.Warn("already_enabled", name);
  }

  public static CustomResult AlreadyDeleted(string name) {
    return CustomResult.Warn("already_deleted", name);
  }

  public static CustomResult AlreadyExists(string name) {
    return CustomResult.Warn("already_exists", name);
  }

  public static CustomResult AlreadyInUse(string name) {
    return CustomResult.Warn("already_in_use", name);
  }

  public static CustomResult NotVerified(string name) {
    return CustomResult.Warn("not_verified", name);
  }

  public static CustomResult VerificationRequired(string name) {
    return CustomResult.Warn("verification_required", name);
  }

  public static CustomResult TooShort(string name) {
    return CustomResult.Warn("too_short", name);
  }
  public static CustomResult NoAccountFound(string name) {
    return CustomResult.Warn("no_account_found", name);
  }
  public static CustomResult TooLong(string name) {
    return CustomResult.Warn("too_long", name);
  }

  public static CustomResult CanNotContainSpace(string name) {
    return CustomResult.Warn("can_not_contain_space", name);
  }

  public static CustomResult DoNotMatch(string name) {
    return CustomResult.Warn("do_not_match", name);
  }

  public static CustomResult WrongPassword() {
    return CustomResult.Warn("Password", "wrong");
  }

  public static CustomResult None(string name) {
    return CustomResult.Warn("none", name);
  }

  #endregion

  #region ERRORS

  public static CustomResult Unauthorized(string name = "User") {
    return CustomResult.Warn("unauthorized", name);
  }

  public static CustomResult Forbidden(string name = "User") {
    return CustomResult.Warn("forbidden", name);
  }

  public static CustomResult UnderMaintenance() {
    return CustomResult.Error("under_maintenance");
  }

  public static CustomResult DbInternalError(string operationName) {
    return CustomResult.Critical("db_internal_error",operationName);
  }

  #endregion
  public static CustomResult MaxCountReached(string announcementName,int maxCountParam) {
    return CustomResult.Error("max_count_reached",announcementName, maxCountParam);
  }

  public static CustomResult CannotSetExpired(string announcementName) {
    return CustomResult.Error( "can_not_set_expired",announcementName);

  }
  public static CustomResult CanNotDelete(string name) {
    return CustomResult.Error("can_not_delete", name);
  }
  public static CustomResult CanNotDeleteBcRelation(string mainObjectName,string relationName) {
    return CustomResult.Error("can_not_delete",mainObjectName,relationName);
  }
}