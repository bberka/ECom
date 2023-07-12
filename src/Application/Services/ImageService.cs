using Microsoft.AspNetCore.Http;

namespace ECom.Application.Services;

public class ImageService : IImageService
{
  private const string DefaultImageBase64String = "";
  private readonly IUnitOfWork _unitOfWork;

  public ImageService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public ResultData<Image> GetImage(int id) {
    var image = _unitOfWork.ImageRepository.GetById(id);
    if (image is null) return DomainResult.Image.NotFoundResult();
    return image;
  }

  public string GetImageBase64String(int id) {
    var imageData = _unitOfWork.ImageRepository
      .Get(x => x.Id == id)
      .Select(x => x.Data)
      .FirstOrDefault();
    if (imageData is null) return $"data:image/jpg;base64,{DefaultImageBase64String}";
    var imageBase64Data = Convert.ToBase64String(imageData);
    return $"data:image/jpg;base64,{imageBase64Data}";
  }

  public ResultData<int> UploadImage(IFormFile file) {
    var img = new Image();
    var ms = new MemoryStream();
    file.CopyTo(ms);
    img.Data = ms.ToArray();
    img.Name = file.FileName;
    _unitOfWork.ImageRepository.Insert(img);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return img.Id;
  }
}