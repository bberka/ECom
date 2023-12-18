using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.Base;

public interface IImageService
{
  // string GetImageBase64String(Guid id);

  Image? GetImageDbData(Guid id);
  Stream? GetImage(Guid id);
}