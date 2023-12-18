using System.Text.Json.Serialization;

namespace ECom.Foundation.DTOs;

public class NestableListElementDto
{
  [JsonPropertyName("id")]
  public string Id { get; set; }

  [JsonPropertyName("children")]
  public NestableListElementDto[] Children { get; set; } = Array.Empty<NestableListElementDto>();
}