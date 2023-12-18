namespace ECom.Foundation.DTOs;

public class FileRequestDto
{
  [Required]
  public IFormFile file { get; set; }
}