using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
		
	}
}
