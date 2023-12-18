namespace ECom.Business.Services.BaseServices;

public class SliderService : ISliderService
{
  private readonly IUnitOfWork _unitOfWork;

  public SliderService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public Result<Slider> GetSlider(int sliderId) {
    var slider = _unitOfWork.Sliders.Find(sliderId);
    if (slider is null) return DefResult.NotFound(nameof(Slider));
    if (slider.DeleteDate.HasValue) return DefResult.Deleted(nameof(Slider));
    return slider;
  }

  public List<Slider> GetSliders() {
    return _unitOfWork.Sliders.Where(x => !x.DeleteDate.HasValue).ToList();
  }

  public Result UpdateSlider(Slider slider) {
    var exists = _unitOfWork.Sliders.Any(x => x.Id == slider.Id && !x.DeleteDate.HasValue);
    if (!exists) return DefResult.NotFound(nameof(Slider));
    _unitOfWork.Sliders.Update(slider);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(UpdateSlider));
    return DefResult.OkUpdated(nameof(Slider));
  }

  public Result DeleteSlider(int sliderId) {
    var sliderResult = GetSlider(sliderId);
    if (!sliderResult.Status) return sliderResult.ToResult();
    var slider = sliderResult.Data!;
    slider.DeleteDate = DateTime.Now;
    _unitOfWork.Sliders.Update(slider);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(DeleteSlider));
    return DefResult.Deleted(nameof(Slider));
  }

  public Result AddSlider(Slider slider) {
    _unitOfWork.Sliders.Add(slider);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(AddSlider));
    return DefResult.OkAdded(nameof(Slider));
  }
}