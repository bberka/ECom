namespace ECom.Business.Services.BaseServices;

public class ImageService : IImageService
{
  protected const string DefaultImageBase64String = "";
  private readonly IUnitOfWork _unitOfWork;

  public ImageService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  // public string GetImageBase64String(Guid id) {
  //   throw new NotImplementedException();
  //   //TODO: Implement this method
  //   // var imageData = Enumerable.Select(UnitOfWork.Images
  //   //                                             .Where(x => x.Id == id), x => x.Value)
  //   //                           .FirstOrDefault();
  //   // if (imageData is null) return $"data:image/jpg;base64,{DefaultImageBase64String}";
  //   // var imageBase64Data = Convert.ToBase64String(imageData);
  //   // return $"data:image/jpg;base64,{imageBase64Data}";
  // }


  public Image? GetImageDbData(Guid id) {
    var image = _unitOfWork.Images.Find(id);
    return image;
  }

  public Stream? GetImage(Guid id) {
    throw new NotImplementedException();
  }
}