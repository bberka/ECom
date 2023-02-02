using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Infrastructure.Concrete
{
	public class LanguageDal : EfEntityRepositoryBase<Language, EComDbContext>
	{

		private LanguageDal() { }
		public static LanguageDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static LanguageDal? Instance;
	}
}
