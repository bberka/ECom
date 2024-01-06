using ECom.Foundation.DTOs;
using ECom.Foundation.DTOs.Request;
using ECom.Foundation.Entities;
using ECom.Foundation.Lib;

namespace ECom.Foundation.Mappers;

public static class UserMapper
{
  public static User FromRequestRegisterUser(this Request_User_Register requestUser) {
    return new User {
      FirstName = requestUser.FirstName,
      LastName = requestUser.LastName,
      EmailAddress = requestUser.EmailAddress,
      Password = requestUser.Password.ToHashedText(),
      PhoneNumber = requestUser.PhoneNumber,
      CitizenShipNumber = requestUser.CitizenshipNumber,
      RegisterDate = DateTime.Now,
      Culture = requestUser.PreferredCultureType
    };
  }

  public static User FromDto(this UserDto dto) {
    return new User {
      Id = dto.Id,
      FirstName = dto.FirstName,
      LastName = dto.LastName,
      EmailAddress = dto.EmailAddress,
      PhoneNumber = dto.PhoneNumber,
      RegisterDate = dto.RegisterDate,
      Culture = dto.Culture,
      TwoFactorType = dto.TwoFactorType,
      IsEmailVerified = dto.IsEmailVerified
    };
  }

  public static UserDto ToDto(this User user) {
    return new UserDto {
      Id = user.Id,
      FirstName = user.FirstName,
      LastName = user.LastName,
      EmailAddress = user.EmailAddress,
      PhoneNumber = user.PhoneNumber,
      RegisterDate = user.RegisterDate,
      Culture = user.Culture,
      TwoFactorType = user.TwoFactorType,
      IsEmailVerified = user.IsEmailVerified
    };
  }
}