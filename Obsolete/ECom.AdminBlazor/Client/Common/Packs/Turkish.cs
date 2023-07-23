using System.Collections.ObjectModel;
using ECom.Shared.DTOs.LocalizationStringDto;

namespace ECom.AdminBlazor.Client.Common.Packs;

public static class Turkish
{
  public static readonly ReadOnlyCollection<LocalizationStringDTO> Pack = new List<LocalizationStringDTO>() {
    new LocalizationStringDTO("announcements","Duyurular"),
    new LocalizationStringDTO("categories","Kategoriler"),
    new LocalizationStringDTO("dashboard","Anasayfa"),
    new LocalizationStringDTO("hello","Merhaba"),
    new LocalizationStringDTO("management","Yönetim"),
    new LocalizationStringDTO("options","Ayarlar"),
    new LocalizationStringDTO("roles_and_permissions","Roller ve Yetkiler"),
    new LocalizationStringDTO("admins","Yetkililer"),

    new LocalizationStringDTO("images","Resimler"),
    new LocalizationStringDTO("image_list","Resim Listesi"),
    new LocalizationStringDTO("upload_image","Resim Yükle"),
    new LocalizationStringDTO("base_option","Genel Ayarlar"),
    new LocalizationStringDTO("smtp_option","Smtp Ayarları"),
    new LocalizationStringDTO("payment_option","Ödeme Ayarları"),
    new LocalizationStringDTO("cargo_option","Karo Ayarları"),
    new LocalizationStringDTO("company_info","Şirket Bilgileri"),
    new LocalizationStringDTO("id","Id"),


  }.AsReadOnly();

}