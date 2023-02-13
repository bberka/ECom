using ECom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECom.Domain.Results;

namespace ECom.Application.Services
{
	
	public class CompanyInformationService : ICompanyInformationService
	{

		const byte CACHE_REFRESH_INTERVAL_MINS = 1;
		private readonly EasCache<CompanyInformation?> Cache;
		private readonly IEfEntityRepository<CompanyInformation> _companyInfoRepo;

		public CompanyInformationService(IEfEntityRepository<CompanyInformation> companyInfoRepo)
		{
			Cache = new(GetCompanyInformationNullable, CACHE_REFRESH_INTERVAL_MINS);
			this._companyInfoRepo = companyInfoRepo;
		}

        private CompanyInformation? GetCompanyInformationNullable()
        {
            return GetCompanyInformation().Data;
        }
		public ResultData<CompanyInformation> GetCompanyInformation()
		{
            var companyInformation = _companyInfoRepo.GetFirstOrDefault(x => x.IsRelease == !ConstantMgr.IsDebug());
            if (companyInformation is null) return DomainResult.CompanyInformation.NotFoundResult(1);
			return companyInformation;
		}
		public CompanyInformation? GetFromCache()
		{
			return Cache.Get();
		}

		public Result UpdateOrAddCompanyInformation(CompanyInformation info)
        {
            info.IsRelease = !ConstantMgr.IsDebug();
			var current = _companyInfoRepo.GetFirstOrDefault(x => x.IsRelease == info.IsRelease);
			if (current != null)
			{
				var deleteResult = _companyInfoRepo.Delete(current);
				if (!deleteResult)
                {
                    return DomainResult.DbInternalErrorResult(1);
                }
			}
            var res = _companyInfoRepo.Add(info);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
            }
            Cache.Refresh();
            return DomainResult.CompanyInformation.UpdateSuccessResult();
		}
	}

}
