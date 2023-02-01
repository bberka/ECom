
using EasMe;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.BaseManager
{
	public class OptionMgr : EfEntityRepositoryBase<Option, EComDbContext>
	{

		private OptionMgr() 
		{
			Cache = new(GetSingle, CACHE_REFRESH_INTERVAL_MINS);
		}
		public static OptionMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static OptionMgr? Instance;

		const byte CACHE_REFRESH_INTERVAL_MINS = 1;
		public  readonly EasCache<Option> Cache;
		
	}
}
