using ECom.Foundation.Models;

namespace ECom.Foundation;

/// <summary>
///   Defined Results
/// </summary>
public static class DefResult
{
  public static Result Exception(Exception exception, string name) {
    return Result.Fatal(exception, new LocParam("name", name));
  }

  public static Result InvalidState(string name) {
    return Result.Warn("invalid_state", new LocParam("name", name));
  }

  public static Result NotDeleted(string name) {
    return Result.Warn("not_deleted", new LocParam("name", name));
  }

  public static Result NotChanged(string name) {
    return Result.Warn("not_changed", new LocParam("name", name));
  }

  public static Result NotSupported(string operationName = "action") {
    return Result.Fatal("not_supported", new LocParam("name", operationName));
  }

  public static Result OkRecovered(string name) {
    return Result.OkParam("ok_recovered", new LocParam("name", name));
  }

  public static Result MaxCountReached(string name, int maxCountParam) {
    return Result.Error("max_count_reached", new LocParam("name", name), new LocParam("count", maxCountParam));
  }

  public static Result CannotSetExpired(string name) {
    return Result.Error("can_not_set_expired", new LocParam("name", name));
  }

  public static Result CanNotDelete(string name) {
    return Result.Error("can_not_delete", new LocParam("name", name));
  }

  public static Result CanNotDeleteBecauseOfDbRelation(string mainObjectName, string relationName) {
    return Result.Error("can_not_delete_because_of_db_relation",
                        new LocParam("main_object_name", mainObjectName),
                        new LocParam("relation_name", relationName));
  }

  public static Result MustBeSame(string mainPropertyName, string comparePropertyName) {
    return Result.Error("must_be_same",
                        new LocParam("main_property_name", mainPropertyName),
                        new LocParam("compare_property_name", comparePropertyName));
  }

  public static Result NotImplemented(string name) {
    return Result.Error("not_implemented", new LocParam("name", name));
  }

  #region OK

  public static Result Success(string error, string name = "") {
    return Result.OkParam(error, new LocParam("name", name));
  }

  public static Result Ok(string name) {
    return Result.OkParam("success", new LocParam("name", name));
  }

  public static Result OkAdded(string name) {
    return Result.OkParam("ok_added", new LocParam("name", name));
  }

  public static Result OkAuthenticated(string name) {
    return Result.OkParam("ok_authenticated", new LocParam("name", name));
  }

  public static Result OkUpdated(string name) {
    return Result.OkParam("ok_updated", new LocParam("name", name));
  }

  public static Result OkRemoved(string name) {
    return Result.OkParam("ok_removed", new LocParam("name", name));
  }

  public static Result OkDeleted(string name) {
    return Result.OkParam("ok_deleted", new LocParam("name", name));
  }

  public static Result OkCleared(string name) {
    return Result.OkParam("ok_cleared", new LocParam("name", name));
  }

  public static Result OkNotChanged(string name) {
    return Result.OkParam("ok_not_changed", new LocParam("name", name));
  }

  #endregion

  #region WARNINGS

  public static Result Validation(string name, string message) {
    return Result.Validation(message, new LocParam("name", name));
  }

  public static Result Validation(List<Error> errors) {
    return Result.Validation(errors);
  }

  public static Result Deleted(string name) {
    return Result.Warn("deleted", new LocParam("name", name));
  }

  public static Result Invalid(string name) {
    return Result.Warn("invalid", new LocParam("name", name));
  }

  public static Result EmptyTable(string name) {
    return Result.Warn("empty_table", new LocParam("name", name));
  }

  public static Result NotFound(string name) {
    return Result.Warn("not_found", new LocParam("name", name));
  }

  public static Result AlreadyDisabled(string name) {
    return Result.Warn("already_disabled", new LocParam("name", name));
  }

  public static Result AlreadyEnabled(string name) {
    return Result.Warn("already_enabled", new LocParam("name", name));
  }

  public static Result AlreadyDeleted(string name) {
    return Result.Warn("already_deleted", new LocParam("name", name));
  }

  public static Result AlreadyExists(string name) {
    return Result.Warn("already_exists", new LocParam("name", name));
  }

  public static Result AlreadyInUse(string name) {
    return Result.Warn("already_in_use", new LocParam("name", name));
  }

  public static Result NotVerified(string name) {
    return Result.Warn("not_verified", new LocParam("name", name));
  }

  public static Result VerificationRequired(string name) {
    return Result.Warn("verification_required", new LocParam("name", name));
  }

  public static Result TooShort(string name) {
    return Result.Warn("too_short", new LocParam("name", name));
  }

  public static Result NoAccountFound(string name) {
    return Result.Warn("no_account_found", new LocParam("name", name));
  }

  public static Result TooLong(string name) {
    return Result.Warn("too_long", new LocParam("name", name));
  }

  public static Result CanNotContainSpace(string name) {
    return Result.Warn("can_not_contain_space", new LocParam("name", name));
  }

  public static Result DoNotMatch(string name) {
    return Result.Warn("do_not_match", new LocParam("name", name));
  }

  public static Result WrongPassword() {
    return Result.Warn("wrong_password");
  }

  public static Result None(string name) {
    return Result.Warn("none", new LocParam("name", name));
  }

  #endregion

  #region ERRORS

  public static Result Unauthorized(string name = "User") {
    return Result.Error("unauthorized", new LocParam("name", name));
  }

  public static Result Forbidden(string name = "User") {
    return Result.Error("forbidden", new LocParam("name", name));
  }

  public static Result UnderMaintenance() {
    return Result.Error("under_maintenance");
  }

  public static Result DbInternalError(string operationName) {
    return Result.Fatal("db_internal_error", new LocParam("name", operationName));
  }

  #endregion
}