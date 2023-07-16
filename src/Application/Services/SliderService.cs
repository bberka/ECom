using ECom.Domain;

namespace ECom.Application.Services;

public class SliderService : ISliderService
{
  private readonly IUnitOfWork _unitOfWork;

  public SliderService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public CustomResult<Slider> Get(int sliderId) {
    var slider = _unitOfWork.SliderRepository.GetById(sliderId);
    if (slider is null) return DomainResult.NotFound(nameof(Slider));
    if (slider.DeleteDate.HasValue) return DomainResult.Deleted(nameof(Slider));
    return slider;
  }

  public List<Slider> GetList() {
    return _unitOfWork.SliderRepository.Get(x => !x.DeleteDate.HasValue).ToList();
  }

  public CustomResult Update(Slider slider) {
    var exists = _unitOfWork.SliderRepository.Any(x => x.Id == slider.Id && !x.DeleteDate.HasValue);
    if (!exists) return DomainResult.NotFound(nameof(Slider));
    _unitOfWork.SliderRepository.Update(slider);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(Update));
    return DomainResult.OkUpdated(nameof(Slider));
  }

  public CustomResult Delete(int sliderId) {
    var sliderResult = Get(sliderId);
    if (!sliderResult.Status) return sliderResult.ToResult();
    var slider = sliderResult.Data!;
    slider.DeleteDate = DateTime.Now;
    _unitOfWork.SliderRepository.Update(slider);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(Delete));
    return DomainResult.Deleted(nameof(Slider));
  }

  public CustomResult Add(Slider slider) {
    _unitOfWork.SliderRepository.Insert(slider);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(Add));
    return DomainResult.OkAdded(nameof(Slider));
  }
}