using ECom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECom.Domain.Results;
using Microsoft.Extensions.Caching.Memory;
using Ninject.Activation.Caching;

namespace ECom.Application.Services
{
	
	public class CompanyInformationService : ICompanyInformationService
	{
        private readonly IMemoryCache _memoryCache;
        private readonly IUnitOfWork _unitOfWork;

        const byte CACHE_REFRESH_INTERVAL_MINS = 1;

		public CompanyInformationService(IMemoryCache memoryCache,IUnitOfWork unitOfWork)
		{
            _memoryCache = memoryCache;
            _unitOfWork = unitOfWork;
		}

     
		public ResultData<CompanyInformation> GetCompanyInformation()
		{
            var companyInformation = _unitOfWork.CompanyInformationRepository.GetFirstOrDefault(x => x.IsRelease == !ConstantMgr.IsDebug());
            if (companyInformation is null) return DomainResult.CompanyInformation.NotFoundResult(1);
			return companyInformation;
		}
		public CompanyInformation? GetFromCache()
        {
            var cache = _memoryCache.Get<CompanyInformation>("company_info");
            if(cache is not null) return cache;
            cache = _unitOfWork.CompanyInformationRepository.GetFirstOrDefault(x => x.IsRelease == !ConstantMgr.IsDebug());
            if(cache is not null) 
                _memoryCache.Set("company_info", cache, TimeSpan.FromMinutes(5));
            return cache;
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
            return DomainResult.CompanyInformation.UpdateSuccessResult();
		}
	}

}
