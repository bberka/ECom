using ECom.Application.Services.BaseServices;
using ECom.Domain.Aspects;
using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Admin;
using ECom.Shared.Entities;

namespace ECom.Application.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminImageService : ImageService, IAdminImageService
{
  public AdminImageService(IUnitOfWork unitOfWork) : base(unitOfWork) {
  }

  public CustomResult<Image> GetImage(Guid id) {
    var image = UnitOfWork.ImageRepository.Find(id);
    if (image is null) return DomainResult.NotFound(nameof(Image));
    return image;
  }
  public CustomResult<Guid> UploadImage(IFormFile file) {
    var img = new Image();
    var ms = new MemoryStream();
    file.CopyTo(ms);
    img.Data = ms.ToArray();
    img.Name = file.FileName;
    UnitOfWork.ImageRepository.Insert(img);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UploadImage));
    return img.Id;
  }
}