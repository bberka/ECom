using ECom.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ECom.Domain.Abstract;

public interface IImageService
{
  CustomResult<int> UploadImage(IFormFile file);

  string GetImageBase64String(int id);

  CustomResult<Image> GetImage(int id);
}