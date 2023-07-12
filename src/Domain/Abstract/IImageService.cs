using Microsoft.AspNetCore.Http;

namespace ECom.Domain.Abstract;

public interface IImageService
{
  ResultData<int> UploadImage(IFormFile file);

  string GetImageBase64String(int id);

  ResultData<Image> GetImage(int id);
}