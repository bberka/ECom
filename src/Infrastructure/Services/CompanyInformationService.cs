using ECom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Services
{
	public interface ICompanyInformationService : IEfEntityRepository<CompanyInformation>
	{
		CompanyInformation GetCompanyInformation();
		CompanyInformation GetFromCache();
		Result UpdateCompanyInformation(CompanyInformation info);

	}

	public class CompanyInformationService : EfEntityRepositoryBase<CompanyInformation, EComDbContext>, ICompanyInformationService
	{
		public CompanyInformationService()
		{
			Cache = new(GetCompanyInformation, CACHE_REFRESH_INTERVAL_MINS);
		}

		const byte CACHE_REFRESH_INTERVAL_MINS = 1;
		private readonly EasCache<CompanyInformation> Cache;

		public CompanyInformation GetCompanyInformation()
		{
#if DEBUG
			return GetSingle(x => x.IsRelease == false);
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
			var current = GetFirstOrDefault(x =>x.IsRelease == isRelease);
			if (current != null)
			{
				var res = Delete(current);
				if (!res) return Result.Error(1, Response.DbErrorInternal);
			}
			else
			{
				var res = Add(info);
				if (!res) return Result.Error(2, Response.DbErrorInternal);
			}
			Cache.Refresh();
			return Result.Success(Response.CompanyInformationUpdated);
		}
	}

}
