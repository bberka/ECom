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
    if (image is null) return DefResult.NotFound(nameof(Image));
    return image;
  }


  public List<Image> GetImageList() {
    return _unitOfWork.Images.ToList();
  }

  public Result DeleteImage(Guid id) {
    var image = _unitOfWork.Images.Find(id);
    if (image is null) return DefResult.NotFound(Image.LocKey);
    _unitOfWork.Images.Remove(image);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(DeleteImage));
    var filePath = Path.Combine(EComAppSettings.This.ImageResourceDirectory, id + "." + image.FileExtension);
    var exists = File.Exists(filePath);
    if (exists) File.Delete(filePath);

    return DefResult.OkDeleted(Image.LocKey);
  }

  public Result<Guid> UploadImage(IFormFile file) {
    var img = new Image();
    var ms = new MemoryStream();
    file.CopyTo(ms);
    img.Name = Path.GetFileNameWithoutExtension(file.FileName);
    img.FileExtension = Path.GetExtension(file.FileName);
    img.Culture = ConstantContainer.DefaultLanguage; //TODO: get culture from request 
    img.RegisterDate = DateTime.UtcNow;
    img.Size = file.Length;
    img.ContentType = file.ContentType;
    _unitOfWork.Images.Add(img);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(UploadImage));
    var id = img.Id;
    var path = Path.Combine(EComAppSettings.This.ImageResourceDirectory, id + "." + img.FileExtension);
    File.WriteAllBytes(path, ms.ToArray());
    return img.Id;
  }
}