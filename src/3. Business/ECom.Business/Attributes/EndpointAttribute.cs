using Microsoft.AspNetCore.Mvc.Routing;

namespace ECom.Business.Attributes;

// [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
// public class EndpointRouteAttribute : Attribute,
//                                       IRouteTemplateProvider
// {
//   public EndpointRouteAttribute(string route) {
//     Template = route;
//   }
//
//   public string? Template { get; set; }
//   public int? Order { get; set; }
//   public string? Name { get; set; }
// }

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class EndpointAttribute : HttpMethodAttribute
{
  public EndpointAttribute(string routeTemplate, HttpMethodType httpMethods) : base(new[] { httpMethods.ToString() }, routeTemplate) { }
  public EndpointAttribute(string routeTemplate, HttpMethodType[] httpMethods) : base(httpMethods.Select(x => x.ToString()), routeTemplate) { }
}