namespace ECom.Domain.Abstract;

public interface ISliderService
{
  CustomResult<Slider> Get(int sliderId);

  List<Slider> GetList();

  CustomResult Update(Slider slider);
  CustomResult Delete(int sliderId);
  CustomResult Add(Slider slider);
}