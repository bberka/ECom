namespace ECom.Shared.DTOs;

/// <summary>
///   Base class for Api Requests with Authorization and Authentication
/// </summary>
public abstract class BaseAuthenticatedRequest
{
  ///// <summary>
  /////   UserId received from current HttpContext.
  /////   If User is not authenticated value will be -1
  /////   <br />
  /////   <br />
  /////   This property is ignored in serialization.
  ///// </summary>
  //[System.Text.Json.Serialization.JsonIgnore]
  //[Newtonsoft.Json.JsonIgnore]
  //[IgnoreDataMember]
  //[NotMapped]
  //public int AuthenticatedUserId {
  //  get {
  //    var context = new HttpContextAccessor().HttpContext;
  //    if (context is not null)
  //      if (context.IsUserAuthenticated())
  //        return context.GetUserId();
  //    return -1;
  //  }
  //}

  ///// <summary>
  /////   AdminId received from current HttpContext.
  /////   If Admins is not authenticated value will be -1
  /////   <br />
  /////   <br />
  /////   This property is ignored in serialization.
  ///// </summary>
  //[System.Text.Json.Serialization.JsonIgnore]
  //[Newtonsoft.Json.JsonIgnore]
  //[IgnoreDataMember]
  //[NotMapped]
  //public int AuthenticatedAdminId {
  //  get {
  //    var context = new HttpContextAccessor().HttpContext;
  //    if (context is not null)
  //      if (context.IsAdminAuthenticated())
  //        return context.GetAdminId();
  //    return -1;
  //  }
  //}

  //[System.Text.Json.Serialization.JsonIgnore]
  //[Newtonsoft.Json.JsonIgnore]
  //[IgnoreDataMember]
  //[NotMapped]
  //public List<string> AdminPermissions {
  //  get {
  //    var context = new HttpContextAccessor().HttpContext;
  //    if (context is null) return new();
  //    if (!context.IsAdminAuthenticated()) return new();
  //    var permissions = context.User.GetPermissions();
  //    return permissions;
  //  }
  //}
}