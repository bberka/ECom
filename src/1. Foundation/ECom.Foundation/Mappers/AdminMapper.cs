using ECom.Foundation.DTOs;
using ECom.Foundation.DTOs.Request;
using ECom.Foundation.Entities;

namespace ECom.Foundation.Mappers;

public static class AdminMapper
{
  public static Admin FromRequestAddAdmin(this Request_Admin_Add requestAdmin) {
    return new Admin {
      FirstName = requestAdmin.FirstName,
      LastName = requestAdmin.LastName,
      EmailAddress = requestAdmin.EmailAddress,
      Password = requestAdmin.Password,
      PhoneNumber = requestAdmin.PhoneNumber,
      RegisterDate = DateTime.Now
    };
  }

  public static Admin FromDto(this AdminDto dto) {
    return new Admin {
      Id = dto.Id,
      FirstName = dto.FirstName,
      LastName = dto.LastName,
      EmailAddress = dto.EmailAddress,
      PhoneNumber = dto.PhoneNumber,
      RegisterDate = dto.RegisterDate,
      Culture = dto.Culture,
      TwoFactorType = dto.TwoFactorType
    };
  }

  public static AdminDto ToDto(this Admin admin) {
    return new AdminDto {
      Id = admin.Id,
      FirstName = admin.FirstName,
      LastName = admin.LastName,
      EmailAddress = admin.EmailAddress,
      PhoneNumber = admin.PhoneNumber,
      RegisterDate = admin.RegisterDate,
      Culture = admin.Culture,
      TwoFactorType = admin.TwoFactorType
    };
  }
}