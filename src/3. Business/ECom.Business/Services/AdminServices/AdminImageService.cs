using ECom.Foundation.Static;

namespace ECom.Business.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminImageService : IAdminImageService
{
  private readonly IUnitOfWork _unitOfWork;

  public AdminImageService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public Result<Image> GetImageWithResult(Guid id) {
    var image = _unitOfWork.Images.Find(id);
    if (image is null) return DomResults.x_is_not_found("image");
    return image;
  }


  public List<Image> GetImageList() {
    return _unitOfWork.Images.ToList();
  }

  public Result DeleteImage(Guid id) {
    var image = _unitOfWork.Images.Find(id);
    if (image is null) return DomResults.x_is_not_found("image");
    _unitOfWork.Images.Remove(image);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(DeleteImage));
    var filePath = Path.Combine(DomAppSettings.This.ImageResourceDirectory, id + "." + image.FileExtension);
    var exists = File.Exists(filePath);
    if (exists) File.Delete(filePath);

    return DomResults.x_is_deleted_successfully("image");
  }

  public Result<Guid> UploadImage(IFormFile file) {
    var img = new Image();
    var ms = new MemoryStream();
    file.CopyTo(ms);
    img.Name = Path.GetFileNameWithoutExtension(file.FileName);
    img.FileExtension = Path.GetExtension(file.FileName);
    img.Culture = StaticValues.DEFAULT_LANGUAGE; //TODO: get culture from request 
    img.RegisterDate = DateTime.UtcNow;
    img.Size = file.Length;
    img.ContentType = file.ContentType;
    _unitOfWork.Images.Add(img);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(UploadImage));
    var id = img.Id;
    var path = Path.Combine(DomAppSettings.This.ImageResourceDirectory, id + "." + img.FileExtension);
    File.WriteAllBytes(path, ms.ToArray());
    return img.Id;
  }
}