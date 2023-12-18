using ECom.Foundation.DTOs.Response;
using ECom.Foundation.Entities;

namespace ECom.Foundation.Mappers;

public static class CompanyInformationMapper
{
  public static Response_CompanyInformation ToResponse(this CompanyInformation companyInformation) {
    return new Response_CompanyInformation {
      FacebookLink = companyInformation.FacebookLink,
      InstagramLink = companyInformation.InstagramLink,
      YoutubeLink = companyInformation.YoutubeLink,
      LogoImageId = companyInformation.LogoImageId,
      FavIcoImageId = companyInformation.FavIcoImageId,
      WebUiUrl = companyInformation.WebUiUrl,
      AdminPanelUrl = companyInformation.AdminPanelUrl,
      CompanyName = companyInformation.CompanyName,
      Description = companyInformation.Description,
      CompanyAddress = companyInformation.CompanyAddress,
      PhoneNumber = companyInformation.PhoneNumber,
      ContactEmail = companyInformation.ContactEmail,
      WhatsApp = companyInformation.WhatsApp
    };
  }
}