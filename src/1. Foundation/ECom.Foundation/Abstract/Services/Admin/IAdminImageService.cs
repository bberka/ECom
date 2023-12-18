using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.Admin;

public interface IAdminImageService
{
  Result<Guid> UploadImage(IFormFile file);
  Result<Image> GetImageWithResult(Guid id);
  List<Image> GetImageList();
  Result DeleteImage(Guid id);
}