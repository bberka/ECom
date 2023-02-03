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
		public ResultData<Language> GetLanguageById(int id);

		public Result EnableOrDisable(int id);

		
	}
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
		public ResultData<Language> GetLanguageById(int id)
		{
			var lang  = _languageRepo.Find(id);
			if(lang is null)
			{
				return ResultData<Language>.Error(1, ErrCode.NotFound, "Language");
			}
			return ResultData<Language>.Success(lang);
		}

		public Result EnableOrDisable(int id)
		{
			var language = _languageRepo.Find(id);
			if (language is null) return Result.Error(1, ErrCode.NotFound,"Language");
			language.IsValid = !language.IsValid;
			var res = _languageRepo.Update(language);
			if(!res) return Result.Error(1,ErrCode.DbErrorInternal,"Language","EnableOrDisable");
			return Result.Success("Updated");
		}
	}
}
