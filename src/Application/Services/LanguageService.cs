using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Application.Services
{
	
	public class LanguageService : ILanguageService
	{
		private readonly IEfEntityRepository<Language> _languageRepo;

		public LanguageService(IEfEntityRepository<Language> languageRepo)
		{
			this._languageRepo = languageRepo;
		}
		public List<Language> GetLanguages()
		{
			return _languageRepo.GetList();
		}
		public Language GetLanguage(int id)
		{
			var lang  = _languageRepo.Find(id);
			if (lang is null) throw new NotFoundException(nameof(Language));
			return lang;
		}

		public Result EnableOrDisable(int id)
		{
			var language = GetLanguage(id);
			language.IsValid = !language.IsValid;
			var res = _languageRepo.Update(language);
			if (!res) throw new DbInternalException(nameof(EnableOrDisable));
			return Result.Success("Updated");
		}
	}
}
