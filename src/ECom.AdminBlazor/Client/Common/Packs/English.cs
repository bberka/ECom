using ECom.Shared.DTOs.LocalizationStringDto;
using System.Collections.ObjectModel;

namespace ECom.AdminBlazor.Client.Common.Packs;

public static class English
{
  public static readonly ReadOnlyCollection<LocalizationStringDTO> Pack = new List<LocalizationStringDTO>() {
    new LocalizationStringDTO("announcements","Announcements"),
    new LocalizationStringDTO("categories","Categories"),
    new LocalizationStringDTO("dashboard","Dashboard"),
    new LocalizationStringDTO("hello","Hello"),
    new LocalizationStringDTO("management","Management"),
    new LocalizationStringDTO("options","Options"),
    new LocalizationStringDTO("roles_and_permissions","Roles and Permissions"),
    new LocalizationStringDTO("admins","Admins"),

    new LocalizationStringDTO("images","Images"),
    new LocalizationStringDTO("image_list","Image List"),
    new LocalizationStringDTO("upload_image","Upload Image"),
    new LocalizationStringDTO("base_option","General Options"),
    new LocalizationStringDTO("smtp_option","Smtp Options"),
    new LocalizationStringDTO("payment_option","Payment Options"),
    new LocalizationStringDTO("cargo_option","Cargo Options"),
    new LocalizationStringDTO("company_info","Company Information"),

    new LocalizationStringDTO("id","Id"),
    new LocalizationStringDTO("name","Name"),
    new LocalizationStringDTO("description","Description"),
    new LocalizationStringDTO("price","Price"),
    new LocalizationStringDTO("stock","Stock"),
    new LocalizationStringDTO("category","Category"),
    new LocalizationStringDTO("image","Image"),
    new LocalizationStringDTO("created_date","Created Date"),
    new LocalizationStringDTO("register_date","Register Date"),
    new LocalizationStringDTO("deleted_date","Deleted Date"),
    new LocalizationStringDTO("date","Date"),
    new LocalizationStringDTO("datetime","Datetime"),
    new LocalizationStringDTO("email_address","Email Address"),
    new LocalizationStringDTO("role","Role"),
    new LocalizationStringDTO("permissions","Permissions"),
    new LocalizationStringDTO("two_factor_type","Two Factor Type"),

  }.AsReadOnly();
}