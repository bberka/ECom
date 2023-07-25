using ECom.Domain.Abstract.Services.Base;
using ECom.Domain.Entities;

namespace ECom.Application.Services.BaseServices;

public abstract class ImageService : IImageService
{
  protected const string DefaultImageBase64String = "";
  protected readonly IUnitOfWork UnitOfWork;

  protected ImageService(IUnitOfWork unitOfWork) {
    UnitOfWork = unitOfWork;
  }

  public string GetImageBase64String(Guid id) {
    var imageData = Enumerable.Select(UnitOfWork.ImageRepository
        .Get(x => x.Id == id), x => x.Data)
      .FirstOrDefault();
    if (imageData is null) return $"data:image/jpg;base64,{DefaultImageBase64String}";
    var imageBase64Data = Convert.ToBase64String(imageData);
    return $"data:image/jpg;base64,{imageBase64Data}";
  }


}