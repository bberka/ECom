namespace ECom.Application.Services;

public class SliderService : ISliderService
{
  private readonly IUnitOfWork _unitOfWork;

  public SliderService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public ResultData<Slider> Get(int sliderId) {
    var slider = _unitOfWork.SliderRepository.GetById(sliderId);
    if (slider is null) return DomainResult.Slider.NotFoundResult();
    if (slider.DeleteDate.HasValue) return DomainResult.Slider.DeletedResult();
    return slider;
  }

  public List<Slider> GetList() {
    return _unitOfWork.SliderRepository.Get(x => !x.DeleteDate.HasValue).ToList();
  }

  public Result Update(Slider slider) {
    var exists = _unitOfWork.SliderRepository.Any(x => x.Id == slider.Id && !x.DeleteDate.HasValue);
    if (!exists) return DomainResult.Slider.NotFoundResult();
    _unitOfWork.SliderRepository.Update(slider);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.Slider.UpdateSuccessResult();
  }

  public Result Delete(int sliderId) {
    var sliderResult = Get(sliderId);
    if (sliderResult.IsFailure) return sliderResult.ToResult();
    var slider = sliderResult.Data;
    slider.DeleteDate = DateTime.Now;
    _unitOfWork.SliderRepository.Update(slider);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.Slider.DeleteSuccessResult();
  }

  public Result Add(Slider slider) {
    _unitOfWork.SliderRepository.Insert(slider);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.Slider.AddSuccessResult();
  }
}