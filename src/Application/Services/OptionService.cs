using ECom.Domain.Entities;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using ECom.Domain.Results;

namespace ECom.Application.Services
{
	public class OptionService : IOptionService
	{
        private readonly IUnitOfWork _unitOfWork;
        const byte CACHE_REFRESH_INTERVAL_MINS = 1;

		private readonly EasCache<Option> OptionCache;
		private readonly EasCache<List<CargoOption>> CargoOptionCache;
		private readonly EasCache<List<SmtpOption>> SmtpOptionCache;
		private readonly EasCache<List<PaymentOption>> PaymentOptionCache;


		public OptionService(IUnitOfWork unitOfWork)
		{
            _unitOfWork = unitOfWork;
			OptionCache = new(GetOption, CACHE_REFRESH_INTERVAL_MINS);
			CargoOptionCache = new(ListCargoOptions, CACHE_REFRESH_INTERVAL_MINS);
			SmtpOptionCache = new(ListSmtpOptions, CACHE_REFRESH_INTERVAL_MINS);
			PaymentOptionCache = new(ListPaymentOptions, CACHE_REFRESH_INTERVAL_MINS);

		}



		public Result UpdateOption(Option option)
		{
			_unitOfWork.OptionRepository.Update(option);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(1);
            }
			OptionCache.Refresh();
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
            CargoOptionCache.Refresh();
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
            PaymentOptionCache.Refresh();
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
            SmtpOptionCache.Refresh();
            return DomainResult.SmtpOption.UpdateSuccessResult();
        }



        public Option GetOption()
		{
            var option = _unitOfWork.OptionRepository.GetFirstOrDefault(x => x.IsRelease == !ConstantMgr.IsDebug());
            if (option is null) throw new NotFoundException(nameof(Option));
            return option;
        }


        public List<CargoOption> ListCargoOptions()
		{
			return _unitOfWork.CargoOptionRepository.GetList(x => x.IsValid == true);
		}

		public List<PaymentOption> ListPaymentOptions()
		{
			return _unitOfWork.PaymentOptionRepository.GetList(x => x.IsValid == true);
		}
		public List<SmtpOption> ListSmtpOptions()
		{
			return _unitOfWork.SmtpOptionRepository.GetList(x => x.IsValid == true);
		}

		public void RefreshCache()
		{
			OptionCache.Refresh();
			PaymentOptionCache.Refresh();
			SmtpOptionCache.Refresh();
			CargoOptionCache.Refresh();

		}


		public Option GetOptionFromCache()
		{
			return OptionCache.Get();
		}

		public List<CargoOption> ListCargoOptionsFromCache()
		{
			return CargoOptionCache.Get();
		}

		public List<PaymentOption> ListPaymentOptionsFromCache()
		{
			return PaymentOptionCache.Get();
		}

		public List<SmtpOption> ListSmtpOptionsFromCache()
		{
			return SmtpOptionCache.Get();
		}
	}
}
