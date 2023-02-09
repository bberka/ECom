using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECom.Domain.Results;


namespace ECom.Application.Services
{

	public class SliderService :  ISliderService
	{
        private readonly IEfEntityRepository<Slider> _sliderRepo;

        public SliderService(
			IEfEntityRepository<Slider> sliderRepo)
		{
            this._sliderRepo = sliderRepo;
        }

        public ResultData<Slider> Get(int sliderId)
        {
            var slider = _sliderRepo.Find(sliderId);
            if (slider is null) return DomainResult.Slider.NotFoundResult(1);
            if (slider.DeleteDate.HasValue) return DomainResult.Slider.DeletedResult(3);
            return slider;
        }

        public List<Slider> GetList()
        {
            return _sliderRepo.GetList(x => !x.DeleteDate.HasValue);
        }

        public Result Update(Slider slider)
        {
            var exists = _sliderRepo.Any(x => x.Id == slider.Id && !x.DeleteDate.HasValue);
            if(!exists) return DomainResult.Slider.NotFoundResult(1);
            var res = _sliderRepo.Update(slider);
            if (!res) return DomainResult.DbInternalErrorResult(2);
            return DomainResult.Slider.UpdateSuccessResult();
        }

        public Result Delete(int sliderId)
        {
            var sliderResult = Get(sliderId);
            if (sliderResult.IsFailure) return sliderResult.ToResult(100);
            var slider = sliderResult.Data;
            slider.DeleteDate = DateTime.Now;
            var res = _sliderRepo.Update(slider);
            if (!res) return DomainResult.DbInternalErrorResult(1);
            return DomainResult.Slider.DeleteSuccessResult();
        }

        public Result Add(Slider slider)
        {
            var res = _sliderRepo.Add(slider);
            if (!res) return DomainResult.DbInternalErrorResult(1);
            return DomainResult.Slider.AddSuccessResult();
        }
    }
}
