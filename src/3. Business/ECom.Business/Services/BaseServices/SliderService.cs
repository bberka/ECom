namespace ECom.Business.Services.BaseServices;

public class SliderService : ISliderService
{
  private readonly IUnitOfWork _unitOfWork;

  public SliderService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public Result<Slider> GetSlider(int sliderId) {
    var slider = _unitOfWork.Sliders.Find(sliderId);
    if (slider is null || slider.DeleteDate.HasValue) return DomResults.x_is_not_found("slider");
    return slider;
  }

  public List<Slider> GetSliders() {
    return _unitOfWork.Sliders.Where(x => !x.DeleteDate.HasValue).ToList();
  }

  public Result UpdateSlider(Slider slider) {
    var exists = _unitOfWork.Sliders.Any(x => x.Id == slider.Id && !x.DeleteDate.HasValue);
    if (!exists) return DomResults.x_is_not_found("slider");
    _unitOfWork.Sliders.Update(slider);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(UpdateSlider));
    return DomResults.x_is_updated_successfully("slider");
  }

  public Result DeleteSlider(int sliderId) {
    var sliderResult = GetSlider(sliderId);
    if (!sliderResult.Status) return sliderResult.ToResult();
    var slider = sliderResult.Value!;
    slider.DeleteDate = DateTime.Now;
    _unitOfWork.Sliders.Update(slider);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(DeleteSlider));
    return DomResults.x_is_deleted_successfully("slider");
  }

  public Result AddSlider(Slider slider) {
    _unitOfWork.Sliders.Add(slider);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(AddSlider));
    return DomResults.x_is_added_successfully("slider");
  }
}