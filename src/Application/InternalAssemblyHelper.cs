using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ECom.Application;

internal static class InternalAssemblyHelper
{
  private const string Endpoints = "Endpoints";
  private const string Endpoint = "Endpoint";
  private const bool RemoveControllerNameFromActionName = false;
  private const bool UseToLower = true;

  internal static string[] CreateFoldersArrayFromNameSpace(string? ns) {
    if (ns == null) return Array.Empty<string>();
    var indexofEndpoints = ns?.IndexOf(Endpoints, StringComparison.OrdinalIgnoreCase) ?? -1;
    if (indexofEndpoints == -1) return Array.Empty<string>();
    var controller = ConvertDotsToSlash(ns?[(indexofEndpoints + Endpoints.Length)..]);
    if (controller.Equals(Endpoints, StringComparison.OrdinalIgnoreCase)) return Array.Empty<string>();
    return controller.Trim('/').Split("/").Select(x => x.RemoveText(Endpoints)).ToArray();
  }
  internal static string ConvertDotsToSlash(string? str) => str?.Replace(".", "/") ?? "";

  internal static string CreateActionName(string baseActionName, string[] folders) {
    var actionName = baseActionName?.RemoveText(Endpoint).RemoveText("/") ?? throw new ArgumentNullException(nameof(baseActionName));
    if (RemoveControllerNameFromActionName) {
      foreach (var folder in folders) {
        if (folder.Length == 0) continue;
        actionName = actionName.Replace(folder, "", StringComparison.OrdinalIgnoreCase);
      }
    }
    return actionName;
  }
  internal static string BuildRoute(string[] folders, string actionName, params string[] prefixes) {
    var sb = new StringBuilder();
    sb.Append("/");
    foreach (var prefix in prefixes)
      sb.Append($"{prefix}/");
    foreach (var folder in folders)
      sb.Append($"{folder}/");
    sb.Append(actionName);
    var route = sb.ToString().Replace("//", "/");
    if (UseToLower) route = route.ToLower();

    return route;
  }

  internal static string GetControllerName(string? ns) {
    var folders = CreateFoldersArrayFromNameSpace(ns);
    var controllerName = folders.LastOrDefault()?.RemoveText(Endpoints);
    if (string.IsNullOrEmpty(controllerName)) controllerName = "_BaseEndpoints";
    return controllerName;
  }
}