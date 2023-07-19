namespace ECom.Shared.Constants;

public enum AdminOperationType
{
  AdminUpdate = 1,
  AdminDisable,
  AdminEnable,
  AdminDelete,
  AdminGet,
  AdminGetAll,
  AdminCreate,

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


  AdminRecoverAccount
}