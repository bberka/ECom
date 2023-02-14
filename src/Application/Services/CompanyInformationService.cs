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
        private readonly IUnitOfWork _unitOfWork;

        const byte CACHE_REFRESH_INTERVAL_MINS = 1;
		private readonly EasCache<CompanyInformation?> Cache;

		public CompanyInformationService(IUnitOfWork unitOfWork)
		{
            _unitOfWork = unitOfWork;
            Cache = new(GetCompanyInformationNullable, CACHE_REFRESH_INTERVAL_MINS);
		}

        private CompanyInformation? GetCompanyInformationNullable()
        {
            return GetCompanyInformation().Data;
        }
		public ResultData<CompanyInformation> GetCompanyInformation()
		{
            var companyInformation = _unitOfWork.CompanyInformationRepository.GetFirstOrDefault(x => x.IsRelease == !ConstantMgr.IsDebug());
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
			var current = _unitOfWork.CompanyInformationRepository.GetFirstOrDefault(x => x.IsRelease == info.IsRelease);
			if (current != null)
			{
                _unitOfWork.CompanyInformationRepository.Delete(current);
			}
            _unitOfWork.CompanyInformationRepository.Add(info);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
            }
            Cache.Refresh();
            return DomainResult.CompanyInformation.UpdateSuccessResult();
		}
	}

}
