//using System.Security.Claims;
//using AspectInjector.Broker;
//using AspNetCore.Authorization.Extender;
//using Microsoft.AspNetCore.Components.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Serilog;

//namespace ECom.Domain.Aspects;


///// <summary>
///// Sets a permission for a method or class that uses <see cref="AuthenticationStateProvider"/> to check if accessed admin is allowed to use the action.
///// <br></br>
///// <br></br>
///// In order to use this the method must return type of <see cref="CustomResult"/> or <see cref="CustomResult{T}"/>
///// </summary>
//[Aspect(Scope.PerInstance)]
//[Injection(typeof(RequireAdminPermissionAspect))]
//[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
//public class RequireAdminPermissionAspect : Attribute
//{
//  private readonly AuthenticationStateProvider _authenticationStateProvider;
//  private readonly IRoleService _roleService;

//  public RequireAdminPermissionAspect(
//    [FromServices] AuthenticationStateProvider authenticationStateProvider = null,
//    [FromServices] IRoleService roleService = null) {
//    _authenticationStateProvider = authenticationStateProvider;
//    _roleService = roleService;
//  }

//  public RequireAdminPermissionAspect() {
  
//  }

//  //public RequireAdminPermissionAspect(AdminPermission permission, bool useClaims) {
//  //  Permission = permission;
//  //  UseClaims = useClaims;
//  //}
//  /// <summary>
//  /// Sets required permission
//  /// </summary>
//  public AdminPermission Permission { get; set; }

//  /// <summary>
//  /// Whether to use claims or database to get admin permissions
//  /// </summary>
//  public bool UseClaims { get; set; } = true;

//  [Advice(Kind.Around)]
//  public object Intercept(
//    [Argument(Source.Target)] Func<object[], object> target,
//    [Argument(Source.Arguments)] object[] args,
//    //[Argument(Source.Instance)] object instance,
//    [Argument(Source.Name)] string methodName,
//    [Argument(Source.Type)] Type type,
//    [Argument(Source.ReturnType)] Type returnType) {
//    var auth = _authenticationStateProvider.GetAuthenticationStateAsync().GetAwaiter().GetResult();
//    if (auth.User.Identity?.IsAuthenticated != true) {
//      return DomainResult.Unauthorized("Admin");
//    }
//    var adminIdString = auth.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//    if (adminIdString == null) {
//      return DomainResult.Unauthorized("Admin");
//    }
//    var adminId = Guid.Parse(adminIdString);
//    var requiredPermission = Permission.ToString();
//    if (UseClaims) {
//      var permissions = auth.User.FindFirst(ExtClaimTypes.EndPointPermissions);
//      if (permissions is null) {
//        return DomainResult.Unauthorized("Admin");
//      }
//      var parsed = permissions.Value.Split(",");
//      var hasPermission = parsed.Contains(requiredPermission);
//      if (!hasPermission) {
//        return DomainResult.Forbidden("Admin");
//      }
//    }
//    else {
//      //use db
//      var hasPermission = _roleService.HasPermission(adminId, requiredPermission);
//      if (!hasPermission) {
//        return DomainResult.Forbidden("Admin");
//      }
//    }
//    return target(args);
//  }

//}