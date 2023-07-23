using ECom.Domain.Entities;

namespace ECom.Domain.Abstract;

public interface ISliderService
{
  CustomResult<Slider> GetSlider(int sliderId);

  List<Slider> GetSliders();

  CustomResult UpdateSlider(Slider slider);
  CustomResult DeleteSlider(int sliderId);
  CustomResult AddSlider(Slider slider);
}