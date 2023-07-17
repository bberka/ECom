namespace ECom.Domain.Constants;

public enum AdminOperationType
{
  AdminUpdate = 1,
  AdminDelete,
  AdminGet,
  AdminGetAll,
  AdminAdd,

  AnnouncementUpdate,
  AnnouncementDelete,
  AnnouncementAdd,
  AnnouncementEnable,
  AnnouncementDisable,


  CategoryAdd,
  CategoryUpdate,
  CategoryDelete,
  CategoryEnable,
  CategoryDisable,

  SubCategoryEnable,
  SubCategoryDisable,

  CompanyInfoAdd,
  CompanyInfoUpdate,

  ImageUpload,

  OptionGet,
  OptionUpdate,

  CargoOptionGet,
  CargoOptionUpdate,
  CargoOptionDelete,

  PaymentOptionGet,
  PaymentOptionUpdate,
  PaymentOptionDelete,

  SmtpOptionGet,
  SmtpOptionUpdate,
  SmtpOptionDelete,


}