using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Application.BaseManager
{
	public class LanguageMgr : EfEntityRepositoryBase<Language, EComDbContext>
	{

		private LanguageMgr() { }
		public static LanguageMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static LanguageMgr? Instance;
	}
}
