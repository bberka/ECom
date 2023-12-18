using Swashbuckle.AspNetCore.Annotations;

namespace ECom.Business.Attributes;

public class EndpointSwaggerOperationAttribute : SwaggerOperationAttribute
{
  public EndpointSwaggerOperationAttribute(string tagName,
                                           string? summary = null,
                                           string? description = null) {
    if (string.IsNullOrEmpty(tagName))
      tagName = "Endpoints";
    Tags = new[] { tagName };
    if (!string.IsNullOrEmpty(summary))
      Summary = summary;
    if (!string.IsNullOrEmpty(description))
      Description = description;
  }
}