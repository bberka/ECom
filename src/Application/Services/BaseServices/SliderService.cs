using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Entities;

namespace ECom.Application.Services.BaseServices;

public abstract class SliderService : ISliderService
{
  protected readonly IUnitOfWork UnitOfWork;

  protected SliderService(IUnitOfWork unitOfWork) {
    UnitOfWork = unitOfWork;
  }

  public CustomResult<Slider> GetSlider(int sliderId) {
    var slider = UnitOfWork.Sliders.Find(sliderId);
    if (slider is null) return DomainResult.NotFound(nameof(Slider));
    if (slider.DeleteDate.HasValue) return DomainResult.Deleted(nameof(Slider));
    return slider;
  }

  public List<Slider> GetSliders() {
    return UnitOfWork.Sliders.Where(x => !x.DeleteDate.HasValue).ToList();
  }

  public CustomResult UpdateSlider(Slider slider) {
    var exists = UnitOfWork.Sliders.Any(x => x.Id == slider.Id && !x.DeleteDate.HasValue);
    if (!exists) return DomainResult.NotFound(nameof(Slider));
    UnitOfWork.Sliders.Update(slider);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateSlider));
    return DomainResult.OkUpdated(nameof(Slider));
  }

  public CustomResult DeleteSlider(int sliderId) {
    var sliderResult = GetSlider(sliderId);
    if (!sliderResult.Status) return sliderResult.ToResult();
    var slider = sliderResult.Data!;
    slider.DeleteDate = DateTime.Now;
    UnitOfWork.Sliders.Update(slider);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteSlider));
    return DomainResult.Deleted(nameof(Slider));
  }

  public CustomResult AddSlider(Slider slider) {
    UnitOfWork.Sliders.Add(slider);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddSlider));
    return DomainResult.OkAdded(nameof(Slider));
  }
}