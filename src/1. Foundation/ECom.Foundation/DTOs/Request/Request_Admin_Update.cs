﻿namespace ECom.Foundation.DTOs.Request;

public class Request_Admin_Update : BaseAuthenticatedRequest
{
  [Required]
  public Guid Id { get; set; }

  [EmailAddress]
  [Required]
  [MaxLength(ConstantContainer.MaxEmailLength)]
  public string EmailAddress { get; set; }

  [Required]
  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  public string RoleId { get; set; }

  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  public string FirstName { get; set; }

  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  public string LastName { get; set; }

  [MinLength(ConstantContainer.MinPhoneLength)]
  [MaxLength(ConstantContainer.MaxPhoneLength)]
  public string PhoneNumber { get; set; }
}