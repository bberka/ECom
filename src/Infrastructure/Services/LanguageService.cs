using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Infrastructure.Services
{
	public interface ILanguageService : IEfEntityRepository<Language>
	{
	}
	public class LanguageService : EfEntityRepositoryBase<Language, EComDbContext>, ILanguageService
	{

	}
}
