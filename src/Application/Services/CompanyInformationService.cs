using ECom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Services
{
	
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
			var companyInformation = new CompanyInformation();
#if DEBUG
            companyInformation = _companyInfoRepo.GetFirstOrDefault(x => x.IsRelease == false);
#else
            companyInformation = _companyInfoRepo.GetFirstOrDefault(x => x.IsRelease == true);

#endif
            if (companyInformation is null) throw new NotFoundException(nameof(CompanyInformation));
			return companyInformation;
		}
		public CompanyInformation GetFromCache()
		{
			return Cache.Get();
		}

		public Result UpdateCompanyInformation(CompanyInformation info)
		{
#if DEBUG 
			var isRelease = false;
#else
			var isRelease = true;
#endif
			var current = _companyInfoRepo.GetFirstOrDefault(x => x.IsRelease == isRelease);
			if (current != null)
			{
				var deleteResult = _companyInfoRepo.Delete(current);
				if (!deleteResult) 
				{
                    return Result.DbInternal(1);
                }
			}
            var res = _companyInfoRepo.Add(info);
            if (!res)
			{
                return Result.DbInternal(2);
            }
            Cache.Refresh();
			return Result.Success();
		}
	}

}
