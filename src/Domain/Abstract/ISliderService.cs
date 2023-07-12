namespace ECom.Domain.Abstract;

public interface ISliderService
{
  ResultData<Slider> Get(int sliderId);

  List<Slider> GetList();

  Result Update(Slider slider);
  Result Delete(int sliderId);
  Result Add(Slider slider);
}