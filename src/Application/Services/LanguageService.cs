using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Application.Services
{
	public interface ILanguageService 
	{
		public List<Language> GetLanguages();
	}
	public class LanguageService : ILanguageService
	{
		private readonly IEfEntityRepository<Language> _languageRepo;

		public LanguageService(
			IEfEntityRepository<Language> languageRepo)
		{
			this._languageRepo = languageRepo;
		}
		public List<Language> GetLanguages()
		{
			return _languageRepo.GetList();
		}
	}
}
