using ECom.Foundation.DTOs.Request;
using ECom.Foundation.Entities;

namespace ECom.Foundation.Mappers;

public static class AddressMapper
{
  public static Address FromRequestAddAddress(Request_Address_Add requestAddress) {
    return new Address {
      Name = requestAddress.Name,
      Surname = requestAddress.Surname,
      Title = requestAddress.Title,
      Town = requestAddress.Town,
      Country = requestAddress.Country,
      Provience = requestAddress.Provience,
      Details = requestAddress.Details,
      PhoneNumber = requestAddress.PhoneNumber
    };
  }
}