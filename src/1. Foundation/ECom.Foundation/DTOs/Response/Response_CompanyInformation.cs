namespace ECom.Foundation.DTOs.Response;

public class Response_CompanyInformation
{
  public string WebUiUrl { get; set; }

  public string AdminPanelUrl { get; set; }

  public string CompanyName { get; set; }

  public string Description { get; set; }

  public string CompanyAddress { get; set; }

  public string? PhoneNumber { get; set; }

  public string ContactEmail { get; set; }

  public string? WhatsApp { get; set; }

  public string? FacebookLink { get; set; }

  public string? InstagramLink { get; set; }

  public string? YoutubeLink { get; set; }

  public Guid? LogoImageId { get; set; }

  public Guid? FavIcoImageId { get; set; }
}