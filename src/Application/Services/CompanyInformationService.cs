using ECom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Services
{
	public interface ICompanyInformationService 
	{
		CompanyInformation GetCompanyInformation();
		CompanyInformation GetFromCache();
		Result UpdateCompanyInformation(CompanyInformation info);

	}

	public class CompanyInformationService : ICompanyInformationService
	{

		const byte CACHE_REFRESH_INTERVAL_MINS = 1;
		private readonly EasCache<CompanyInformation> Cache;
		private readonly IEfEntityRepository<CompanyInformation> _companyInfoRepo;

		public CompanyInformationService(IEfEntityRepository<CompanyInformation> companyInfoRepo)
		{
			Cache = new(GetCompanyInformation, CACHE_REFRESH_INTERVAL_MINS);
			this._companyInfoRepo = companyInfoRepo;
		}


		public CompanyInformation GetCompanyInformation()
		{
#if DEBUG
			return _companyInfoRepo.GetSingle(x => x.IsRelease == false);
#else
			return GetSingle(x => x.IsRelease == true);
#endif
		}
		public CompanyInformation GetFromCache()
		{
			return Cache.Get();
		}

		public Result UpdateCompanyInformation(CompanyInformation info)
		{
			var isRelease = info.IsRelease;
			var current = _companyInfoRepo.GetFirstOrDefault(x =>x.IsRelease == isRelease);
			if (current != null)
			{
				var res = _companyInfoRepo.Delete(current);
				if (!res) return Result.Error(1, ErrCode.DbErrorInternal);
			}
			else
			{
				var res = _companyInfoRepo.Add(info);
				if (!res) return Result.Error(2, ErrCode.DbErrorInternal);
			}
			Cache.Refresh();
			return Result.Success(ErrCode.NotFound);
		}
	}

}
