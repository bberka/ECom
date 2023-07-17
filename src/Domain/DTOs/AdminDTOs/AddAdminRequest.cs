﻿using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ECom.Domain.DTOs.AdminDTOs;

public class AddAdminRequest : BaseAuthenticatedRequest
{
  public string EmailAddress { get; set; }

  public string Password { get; set; }

  public int RoleId { get; set; }

  [IgnoreDataMember]
  [JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  public string EncryptedPassword => Password.ToEncryptedText();

  public Admin ToAdminEntity() {
    return new Admin {
      RegisterDate = DateTime.Now,
      DeletedDate = null,
      EmailAddress = EmailAddress,
      Password = Convert.ToBase64String(Password.MD5Hash()),
      IsValid = true,
      TwoFactorType = 0,
      RoleId = RoleId
    };
  }
}