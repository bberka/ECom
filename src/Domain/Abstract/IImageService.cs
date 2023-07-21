using ECom.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ECom.Domain.Abstract;

public interface IImageService
{
  CustomResult<Guid> UploadImage(IFormFile file);

  string GetImageBase64String(Guid id);

  CustomResult<Image> GetImage(Guid id);
}