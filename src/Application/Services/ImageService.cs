using ECom.Domain.Entities;

namespace ECom.Application.Services;

public class ImageService : IImageService
{
  private const string DefaultImageBase64String = "";
  private readonly IUnitOfWork _unitOfWork;

  public ImageService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public CustomResult<Image> GetImage(Guid id) {
    var image = _unitOfWork.ImageRepository.Find(id);
    if (image is null) return DomainResult.NotFound(nameof(Image));
    return image;
  }

  public string GetImageBase64String(Guid id) {
    var imageData = Enumerable.Select(_unitOfWork.ImageRepository
        .Get(x => x.Id == id), x => x.Data)
      .FirstOrDefault();
    if (imageData is null) return $"data:image/jpg;base64,{DefaultImageBase64String}";
    var imageBase64Data = Convert.ToBase64String(imageData);
    return $"data:image/jpg;base64,{imageBase64Data}";
  }

  public CustomResult<Guid> UploadImage(IFormFile file) {
    var img = new Image();
    var ms = new MemoryStream();
    file.CopyTo(ms);
    img.Data = ms.ToArray();
    img.Name = file.FileName;
    _unitOfWork.ImageRepository.Insert(img);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UploadImage));
    return img.Id;
  }
}