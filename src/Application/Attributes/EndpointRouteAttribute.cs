using System.Text;
using Microsoft.AspNetCore.Mvc.Routing;

namespace ECom.Application.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class EndpointRouteAttribute : Attribute, IRouteTemplateProvider
{
  private const bool RemoveControllerNameFromActionName = true;
  private const bool UseToLower = true;
  private const string Endpoints = "Endpoints";
  private const string Endpoint = "Endpoint";
  public const string DefaultPrefix = "api/v0.1.0";

  public EndpointRouteAttribute(Type callingClassType) {
    var controllerName = CreateFoldersArray(callingClassType.Namespace);
    var actionName = CreateActionName(callingClassType.Name, controllerName);
    Template = BuildRoute(controllerName, actionName, DefaultPrefix);
  }
  public EndpointRouteAttribute(Type callingClassType,string customPrefix) {
    var controllerName = CreateFoldersArray(callingClassType.Namespace);
    var actionName = CreateActionName(callingClassType.Name, controllerName);
    Template = BuildRoute(controllerName, actionName,DefaultPrefix, customPrefix);
  }
  public EndpointRouteAttribute(string customRouteTemplate) {
    Template = customRouteTemplate;
  }

  public string? Template { get; set; }
  public int? Order { get; set; }
  public string? Name { get; set; }

  private static string BuildRoute(string[] folders, string actionName, params string[] prefixes) {
    var sb = new StringBuilder();
    sb.Append("/");
    foreach (var prefix in prefixes)
      sb.Append($"{prefix}/");
    foreach (var folder in folders)
      sb.Append($"{folder}/");
    sb.Append(actionName);
    var route = sb.ToString().Replace("//", "/");
    if(UseToLower) route = route.ToLower();

    return route;
  }
  private static string[] CreateFoldersArray(string? ns) {
    if (ns == null) return Array.Empty<string>();
    var indexofEndpoints = ns?.IndexOf(Endpoints, StringComparison.OrdinalIgnoreCase) ?? -1;
    if (indexofEndpoints == -1) return Array.Empty<string>();
    var controller = ConvertDotsToSlash(ns?[(indexofEndpoints + Endpoints.Length)..]);
    if (controller.Equals(Endpoints, StringComparison.OrdinalIgnoreCase)) return Array.Empty<string>();
    return controller.Trim('/').Split("/").Select(x => x.RemoveText(Endpoints)).ToArray();
  }

  private static string CreateActionName(string baseActionName, string[] folders) {
    var actionName = baseActionName?.RemoveText(Endpoint).RemoveText("/") ?? throw new ArgumentNullException(nameof(baseActionName));
    if (RemoveControllerNameFromActionName) {
      foreach (var folder in folders) {
        if(folder.Length == 0) continue;
        actionName = actionName.Replace(folder,"", StringComparison.OrdinalIgnoreCase);
      }
    }
    return actionName;
  }
  private static string ConvertDotsToSlash(string? str) => str?.Replace(".", "/") ?? "";
}