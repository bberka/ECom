using System.Collections.ObjectModel;
using ECom.Shared.DTOs.LocalizationStringDto;

namespace ECom.AdminBlazorServer.Common.Packs;

public static class English
{
  public static readonly ReadOnlyCollection<LocalizationStringDTO> Pack = new List<LocalizationStringDTO>() {
    new("announcements","Announcements"),
    new("categories","Categories"),
    new("dashboard","Dashboard"),
    new("hello","Hello"),
    new("management","Management"),
    new("options","Options"),
    new("roles","Roles"),
    new("permissions","permissions"),
    new("and","and"),
    new("admins","Admins"),
    new("images","Images"),
    new("image_list","Image List"),
    new("upload_image","Upload Image"),
    new("base_option","General Options"),
    new("smtp_option","Smtp Options"),
    new("payment_option","Payment Options"),
    new("cargo_option","Cargo Options"),
    new("company_info","Company Information"),
    new("id","Id"),
    new("name","Name"),
    new("description","Description"),
    new("price","Price"),
    new("stock","Stock"),
    new("category","Category"),
    new("image","Image"),
    new("created","Created"),
    new("register","Register"),
    new("deleted","Deleted"),
    new("date","Date"),
    new("datetime","Datetime"),
    new("email_address","Email Address"),
    new("role","Role"),
    new("permissions","Permissions"),
    new("two_factor","Two Factor"),

  }.AsReadOnly();
}