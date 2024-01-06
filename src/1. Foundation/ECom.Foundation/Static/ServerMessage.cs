﻿namespace ECom.Foundation.Static;

public enum ServerMessage
{
  x_must_be_in_range,
  x_must_be_in_range_length,
  x_can_not_be_longer_than_y,
  x_can_not_be_shorter_than_y,
  x_can_not_be_bigger_than_y,
  x_can_not_be_smaller_than_y,
  x_can_not_be_same_with_y,
  x_can_not_be_equal_to_y,
  x_must_be_same_with_y,
  x_must_be_equal_to_y,
  x_must_contain_y,
  x_can_not_contain_y,
  x_can_only_contain_y,
  x_can_not_be_y,
  x_is_invalid,
  x_is_not_valid_format,
  x_already_exists,
  x_already_in_use,
  x_already_deleted,
  x_can_not_be_deleted,
  x_can_not_be_updated,
  x_can_not_be_recovered,
  x_can_not_be_disabled,
  x_can_not_be_enabled,
  x_can_not_be_changed,
  x_is_required,
  x_can_not_be_empty,
  x_can_not_be_deleted_because_of_x,
  x_can_not_be_deleted_because_of_db_relation,
  passwords_must_be_same,

  x_is_deleted_successfully,
  x_is_updated_successfully,
  x_is_added_successfully,
  x_is_recovered_successfully,
  x_is_disabled_successfully,
  x_is_enabled_successfully,
  x_is_created_successfully,

  unauthorized,
  forbidden,
  unauthorized_x,
  already_logged_in,
  x_not_found,
  db_internal_error,
  wrong_password,
  x_is_not_found,
  x_is_added_to_y_successfully,
  x_is_removed_successfully,
  x_is_removed_successfully_from_y,
  x_is_cleared_successfully,
  x_already_expired,
  x_is_expired,
  max_count_reached
}