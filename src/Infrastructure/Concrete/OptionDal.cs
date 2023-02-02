
using EasMe;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Concrete
{
	public class OptionDal : EfEntityRepositoryBase<Option, EComDbContext>
	{

		private OptionDal() 
		{
			Cache = new(GetSingle, CACHE_REFRESH_INTERVAL_MINS);
		}
		public static OptionDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static OptionDal? Instance;

		const byte CACHE_REFRESH_INTERVAL_MINS = 1;
		public  readonly EasCache<Option> Cache;
		
	}
}
