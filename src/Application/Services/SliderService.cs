using ECom.Domain.Entities;

namespace ECom.Application.Services;

public class SliderService : ISliderService
{
  private readonly IUnitOfWork _unitOfWork;

  public SliderService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public CustomResult<Slider> GetSlider(int sliderId) {
    var slider = _unitOfWork.SliderRepository.Find(sliderId);
    if (slider is null) return DomainResult.NotFound(nameof(Slider));
    if (slider.DeleteDate.HasValue) return DomainResult.Deleted(nameof(Slider));
    return slider;
  }

  public List<Slider> GetSliders() {
    return _unitOfWork.SliderRepository.Get(x => !x.DeleteDate.HasValue).ToList();
  }

  public CustomResult UpdateSlider(Slider slider) {
    var exists = _unitOfWork.SliderRepository.Any(x => x.Id == slider.Id && !x.DeleteDate.HasValue);
    if (!exists) return DomainResult.NotFound(nameof(Slider));
    _unitOfWork.SliderRepository.Update(slider);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateSlider));
    return DomainResult.OkUpdated(nameof(Slider));
  }

  public CustomResult DeleteSlider(int sliderId) {
    var sliderResult = GetSlider(sliderId);
    if (!sliderResult.Status) return sliderResult.ToResult();
    var slider = sliderResult.Data!;
    slider.DeleteDate = DateTime.Now;
    _unitOfWork.SliderRepository.Update(slider);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteSlider));
    return DomainResult.Deleted(nameof(Slider));
  }

  public CustomResult AddSlider(Slider slider) {
    _unitOfWork.SliderRepository.Insert(slider);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddSlider));
    return DomainResult.OkAdded(nameof(Slider));
  }
}