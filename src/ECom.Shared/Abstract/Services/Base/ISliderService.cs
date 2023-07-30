using ECom.Shared.Entities;

namespace ECom.Shared.Abstract.Services.Base;

public interface ISliderService
{
    CustomResult<Slider> GetSlider(int sliderId);

    List<Slider> GetSliders();

    CustomResult UpdateSlider(Slider slider);
    CustomResult DeleteSlider(int sliderId);
    CustomResult AddSlider(Slider slider);
}