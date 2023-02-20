

namespace ECom.Application.Services
{
    public class OptionService : IOptionService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IUnitOfWork _unitOfWork;
        const byte CACHE_REFRESH_INTERVAL_MINS = 10;



        public OptionService(IMemoryCache memoryCache, IUnitOfWork unitOfWork)
        {
            _memoryCache = memoryCache;
            _unitOfWork = unitOfWork;

        }



        public Result UpdateOption(Option option)
        {
            _unitOfWork.OptionRepository.Update(option);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(1);
            }
            _memoryCache.Set("option", option, TimeSpan.FromMinutes(5));
            return DomainResult.Option.UpdateSuccessResult();
        }

        public Result UpdateCargoOption(CargoOption option)
        {
            _unitOfWork.CargoOptionRepository.Update(option);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(1);
            }
            return DomainResult.CargoOption.UpdateSuccessResult();
        }
        public Result UpdatePaymentOption(PaymentOption option)
        {
            _unitOfWork.PaymentOptionRepository.Update(option);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(1);
            }
            return DomainResult.PaymentOption.UpdateSuccessResult();
        }
        public Result UpdateSmtpOption(SmtpOption option)
        {
            _unitOfWork.SmtpOptionRepository.Update(option);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(1);
            }
            return DomainResult.SmtpOption.UpdateSuccessResult();
        }



        public Option GetOption()
        {
            var cache = _memoryCache.Get<Option>("option");
            if (cache is not null) return cache;
            cache = _unitOfWork.OptionRepository.GetFirstOrDefault(x => x.IsRelease == !ConstantMgr.IsDebug());
            if (cache is null) throw new NotFoundException(nameof(Option));
            _memoryCache.Set("option", cache, TimeSpan.FromMinutes(5));
            return cache;
        }


        public List<CargoOption> ListCargoOptions()
        {
            var cache = _memoryCache.Get<List<CargoOption>>("cargo_option");
            if (cache is not null) return cache;
            cache = _unitOfWork.CargoOptionRepository.Get(x => x.IsValid == true).ToList();
            _memoryCache.Set("cargo_option", cache, TimeSpan.FromMinutes(5));
            return cache;
        }

        public List<PaymentOption> ListPaymentOptions()
        {
            var cache = _memoryCache.Get<List<PaymentOption>>("payment_option");
            if (cache is not null) return cache;
            cache = _unitOfWork.PaymentOptionRepository.Get(x => x.IsValid == true).ToList();
            _memoryCache.Set("payment_option", cache, TimeSpan.FromMinutes(5));
            return cache;
        }
        public List<SmtpOption> ListSmtpOptions()
        {
            var cache = _memoryCache.Get<List<SmtpOption>>("smtp_option");
            if (cache is not null) return cache;
            cache = _unitOfWork.SmtpOptionRepository.Get(x => x.IsValid == true).ToList();
            _memoryCache.Set("smtp_option", cache, TimeSpan.FromMinutes(5));
            return cache;
        }




    }
}
