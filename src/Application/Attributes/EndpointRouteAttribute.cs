using System.Text;
using Microsoft.AspNetCore.Mvc.Routing;

namespace ECom.Application.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class EndpointRouteAttribute : Attribute, IRouteTemplateProvider
{

  public const string DefaultPrefix = "api/v0.1.0";

  public EndpointRouteAttribute(Type callingClassType) {
    var controllerName = InternalAssemblyHelper.CreateFoldersArrayFromNameSpace(callingClassType.Namespace);
    var actionName = InternalAssemblyHelper.CreateActionName(callingClassType.Name, controllerName);
    Template = InternalAssemblyHelper.BuildRoute(controllerName, actionName, DefaultPrefix);
  }
  public EndpointRouteAttribute(Type callingClassType,string customPrefix) {
    var controllerName = InternalAssemblyHelper.CreateFoldersArrayFromNameSpace(callingClassType.Namespace);
    var actionName = InternalAssemblyHelper.CreateActionName(callingClassType.Name, controllerName);
    Template = InternalAssemblyHelper.BuildRoute(controllerName, actionName,DefaultPrefix, customPrefix);
  }
  public EndpointRouteAttribute(string customRouteTemplate) {
    Template = customRouteTemplate;
  }

  public string? Template { get; set; }
  public int? Order { get; set; }
  public string? Name { get; set; }




}