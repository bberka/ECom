using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace ECom.Domain.DTOs;

/// <summary>
///   Base class for Api Requests with Authorization and Authentication
/// </summary>
public abstract class AuthRequestModelBase
{
  /// <summary>
  ///   UserId received from current HttpContext.
  ///   If User is not authenticated value will be -1
  ///   <br />
  ///   <br />
  ///   This property is ignored in serialization.
  /// </summary>
  [JsonIgnore]
  [Newtonsoft.Json.JsonIgnore]
  [IgnoreDataMember]
  public int AuthenticatedUserId {
    get {
      var context = new HttpContextAccessor().HttpContext;
      if (context is not null)
        if (context.IsUserAuthenticated())
          return context.GetUserId();
      return -1;
    }
  }

  /// <summary>
  ///   AdminId received from current HttpContext.
  ///   If Admin is not authenticated value will be -1
  ///   <br />
  ///   <br />
  ///   This property is ignored in serialization.
  /// </summary>
  [JsonIgnore]
  [Newtonsoft.Json.JsonIgnore]
  [IgnoreDataMember]
  public int AuthenticatedAdminId {
    get {
      var context = new HttpContextAccessor().HttpContext;
      if (context is not null)
        if (context.IsAdminAuthenticated())
          return context.GetAdminId();
      return -1;
    }
  }
}