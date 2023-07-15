using Swashbuckle.AspNetCore.Annotations;

namespace ECom.WebApi.Attributes;

public class EndpointSwaggerOperationAttribute : SwaggerOperationAttribute
{
  public EndpointSwaggerOperationAttribute(Type callingClassType, string? summary = null, string? description = null, string? operationId = null, params string[] tags) {
    var controllerName = callingClassType.Namespace?.Split(".").LastOrDefault() ?? "Base";
    var actionName = callingClassType.Name;
    Summary = summary ?? $"{actionName} {controllerName.ToLower()}";
    if (description is not null)
      Description = description;
    OperationId = operationId ?? $"{callingClassType.Namespace?.Replace(".", "_")}_{actionName}";
    if(tags.Length != 0) Tags = tags;
    else Tags = new[] { controllerName };
  }
}