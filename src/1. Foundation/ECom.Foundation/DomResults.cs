using ECom.Foundation.DTOs.Response;
using ECom.Foundation.Static;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ECom.Foundation;

public static class DomResults
{
  public static Result exception(Exception exc, string name) => Result.Exception(exc, name);

  public static Result validation_error(ModelStateDictionary errors) {
    // var firstModelTypeName = c.ActionDescriptor.Parameters.FirstOrDefault()?.ParameterType.Name ?? "N/A";
    var list = new List<ResultMessage>();
    foreach (var state in errors) {
      foreach (var error in state.Value.Errors) {
        var message = error.Exception?.Message ?? error.ErrorMessage;
        var propertyName = state.Key;
        list.Add(new ResultMessage("validation_error",
                                   new[] {
                                     propertyName,
                                     message
                                   }));
      }
    }

    return Result.Warning(list);
  }

  #region ERRORS

  public static Result x_must_be_in_range(string name, int min, int max) => Result.Error(ServerMessage.x_must_be_in_range, name, min, max);
  public static Result x_must_be_in_range_length(string name, int min, int max) => Result.Error(ServerMessage.x_must_be_in_range_length, name, min, max);
  public static Result x_can_not_be_longer_than_y(string name, int max) => Result.Error(ServerMessage.x_can_not_be_longer_than_y, name, max);
  public static Result x_can_not_be_shorter_than_y(string name, int min) => Result.Error(ServerMessage.x_can_not_be_shorter_than_y, name, min);
  public static Result x_can_not_be_bigger_than_y(string name, int max) => Result.Error(ServerMessage.x_can_not_be_bigger_than_y, name, max);
  public static Result x_can_not_be_smaller_than_y(string name, int min) => Result.Error(ServerMessage.x_can_not_be_smaller_than_y, name, min);
  public static Result x_can_not_be_same_with_y(string name, string compare_name) => Result.Error(ServerMessage.x_can_not_be_same_with_y, name, compare_name);
  public static Result x_can_not_be_equal_to_y(string name, string compare_name) => Result.Error(ServerMessage.x_can_not_be_equal_to_y, name, compare_name);
  public static Result x_must_be_same_with_y(string name, string compare_name) => Result.Error(ServerMessage.x_must_be_same_with_y, name, compare_name);
  public static Result x_must_be_equal_to_y(string name, string compare_name) => Result.Error(ServerMessage.x_must_be_equal_to_y, name, compare_name);
  public static Result x_must_contain_y(string name, string chars) => Result.Error(ServerMessage.x_must_contain_y, name, chars);
  public static Result x_can_not_contain_y(string name, string chars) => Result.Error(ServerMessage.x_can_not_contain_y, name, chars);
  public static Result x_can_only_contain_y(string name, string chars) => Result.Error(ServerMessage.x_can_only_contain_y, name, chars);
  public static Result x_can_not_be_y(string name, object value) => Result.Error(ServerMessage.x_can_not_be_y, name, value);
  public static Result x_is_invalid(string name) => Result.Error(ServerMessage.x_is_invalid, name);
  public static Result x_already_expired(string name) => Result.Error(ServerMessage.x_already_expired, name);
  public static Result x_is_not_valid_format(string name) => Result.Error(ServerMessage.x_is_not_valid_format, name);
  public static Result x_already_exists(string name) => Result.Error(ServerMessage.x_already_exists, name);
  public static Result x_is_expired(string name) => Result.Error(ServerMessage.x_is_expired, name);
  public static Result x_already_in_use(string name) => Result.Error(ServerMessage.x_already_in_use, name);
  public static Result x_already_deleted(string name) => Result.Error(ServerMessage.x_already_deleted, name);
  public static Result x_can_not_be_deleted(string name) => Result.Error(ServerMessage.x_can_not_be_deleted, name);
  public static Result x_can_not_be_updated(string name) => Result.Error(ServerMessage.x_can_not_be_updated, name);
  public static Result x_can_not_be_recovered(string name) => Result.Error(ServerMessage.x_can_not_be_recovered, name);
  public static Result x_can_not_be_disabled(string name) => Result.Error(ServerMessage.x_can_not_be_disabled, name);
  public static Result x_can_not_be_enabled(string name) => Result.Error(ServerMessage.x_can_not_be_enabled, name);
  public static Result x_can_not_be_changed(string name) => Result.Error(ServerMessage.x_can_not_be_changed, name);
  public static Result x_is_required(string name) => Result.Error(ServerMessage.x_is_required, name);
  public static Result x_can_not_be_empty(string name) => Result.Error(ServerMessage.x_can_not_be_empty, name);
  public static Result x_is_not_found(string name) => Result.Error(ServerMessage.x_is_not_found, name);
  public static Result x_can_not_be_deleted_because_of_x(string name, string reason) => Result.Error(ServerMessage.x_can_not_be_empty, name, reason);
  public static Result x_can_not_be_deleted_because_of_db_relation(string name, string relation_name) => Result.Error(ServerMessage.x_can_not_be_deleted_because_of_db_relation, name, relation_name);
  public static Result max_count_reached(int max) => Result.Error(ServerMessage.max_count_reached, max);

  public static Result wrong_password() => Result.Error(ServerMessage.wrong_password);
  public static Result already_logged_in() => Result.Error(ServerMessage.already_logged_in);

  public static Result passwords_must_be_same() => Result.Error(ServerMessage.passwords_must_be_same);
  public static Result unauthorized() => Result.Error(ServerMessage.unauthorized);
  public static Result forbidden() => Result.Error(ServerMessage.forbidden);
  public static Result unauthorized_x(string name) => Result.Error(ServerMessage.unauthorized_x, name);
  public static Result db_internal_error(string operation_name) => Result.Error(ServerMessage.db_internal_error, operation_name);

  #endregion

  #region SUCCESS

  public static Result x_is_deleted_successfully(string name) => Result.Success(ServerMessage.x_is_deleted_successfully, name);
  public static Result x_is_updated_successfully(string name) => Result.Success(ServerMessage.x_is_updated_successfully, name);
  public static Result x_is_added_successfully(string name) => Result.Success(ServerMessage.x_is_added_successfully, name);
  public static Result x_is_recovered_successfully(string name) => Result.Success(ServerMessage.x_is_recovered_successfully, name);
  public static Result x_is_disabled_successfully(string name) => Result.Success(ServerMessage.x_is_disabled_successfully, name);
  public static Result x_is_enabled_successfully(string name) => Result.Success(ServerMessage.x_is_enabled_successfully, name);
  public static Result x_is_created_successfully(string name) => Result.Success(ServerMessage.x_is_created_successfully, name);
  public static Result x_is_removed_successfully(string name) => Result.Success(ServerMessage.x_is_removed_successfully, name);
  public static Result x_is_cleared_successfully(string name) => Result.Success(ServerMessage.x_is_cleared_successfully, name);
  public static Result x_is_removed_successfully_from_y(string name, string removed_name) => Result.Success(ServerMessage.x_is_removed_successfully_from_y, name, removed_name);
  public static Result x_is_added_to_y_successfully(string name, string added_name) => Result.Success(ServerMessage.x_is_added_to_y_successfully, name, added_name);
  public static Result success_not_changed(string name) => Result.Success(ServerMessage.x_is_added_to_y_successfully, name);

  #endregion
}