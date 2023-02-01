using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Application.BaseManager
{
	public class SliderMgr : EfEntityRepositoryBase<Slider, EComDbContext>
	{

		private SliderMgr() { }
		public static SliderMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static SliderMgr? Instance;
	}
}
