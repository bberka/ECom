using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.Base;

public interface ISliderService
{
  Result<Slider> GetSlider(int sliderId);

  List<Slider> GetSliders();

  Result UpdateSlider(Slider slider);
  Result DeleteSlider(int sliderId);
  Result AddSlider(Slider slider);
}