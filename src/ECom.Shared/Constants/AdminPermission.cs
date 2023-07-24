namespace ECom.Shared.Constants;

/// <summary>
/// Defined admin permissions for the application. The order does not matter the string name is taken as id.
/// </summary>
public enum AdminPermission 
{
  ManageAdmins,
  ManageCategories,
  ManageProducts,
  ManageOrders,
  ManageCoupons,
  ManageReports,
  ManageSettings,
  ManageQuestions,
  ManageShipping,
  ManagePayments,
  ManageSmtpOption,
  ManagePaymentOptions,
  ManageShippingOptions,
  ManageTaxOptions,
  ManageGeneralOptions,
  ManageImages,
  ManageAnnouncements,
  ManageCompanyInformation,
  ManageUserAccounts,
  ManageLocalization,
  ManageCargoOptions,
  ManageLoginSessions,
  ManageRoles
}