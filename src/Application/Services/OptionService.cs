using ECom.Domain.Entities;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using ECom.Domain.Results;

namespace ECom.Application.Services
{
	public class OptionService : IOptionService
	{
		const byte CACHE_REFRESH_INTERVAL_MINS = 1;

		private readonly EasCache<Option> OptionCache;
		private readonly EasCache<List<CargoOption>> CargoOptionCache;
		private readonly EasCache<List<SmtpOption>> SmtpOptionCache;
		private readonly EasCache<List<PaymentOption>> PaymentOptionCache;

		private readonly IEfEntityRepository<Option> _optionRepo;
		private readonly IEfEntityRepository<SmtpOption> _smtpOptionRepo;
		private readonly IEfEntityRepository<CargoOption> _cargoOptionRepo;
		private readonly IEfEntityRepository<PaymentOption> _paymentOptionRepo;

		public OptionService(
			IEfEntityRepository<Option> optionRepo,
			IEfEntityRepository<SmtpOption> smtpOptionRepo,
			IEfEntityRepository<CargoOption> cargoOptionRepo,
			IEfEntityRepository<PaymentOption> paymentOptionRepo)
		{
			this._optionRepo = optionRepo;
			this._smtpOptionRepo = smtpOptionRepo;
			this._cargoOptionRepo = cargoOptionRepo;
			this._paymentOptionRepo = paymentOptionRepo;

			OptionCache = new(GetOption, CACHE_REFRESH_INTERVAL_MINS);
			CargoOptionCache = new(ListCargoOptions, CACHE_REFRESH_INTERVAL_MINS);
			SmtpOptionCache = new(ListSmtpOptions, CACHE_REFRESH_INTERVAL_MINS);
			PaymentOptionCache = new(ListPaymentOptions, CACHE_REFRESH_INTERVAL_MINS);

		}



		public Result UpdateOption(Option option)
		{
			var res = _optionRepo.Update(option);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(1);
            }
			OptionCache.Refresh();
            return DomainResult.Option.UpdateSuccessResult();
        }
       
        public Result UpdateCargoOption(CargoOption option)
		{
			var res = _cargoOptionRepo.Update(option);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(1);
            }
			CargoOptionCache.Refresh();
            return DomainResult.CargoOption.UpdateSuccessResult();
        }
        public Result UpdatePaymentOption(PaymentOption option)
		{
			var res = _paymentOptionRepo.Update(option);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(1);
            }
            PaymentOptionCache.Refresh();
			return DomainResult.PaymentOption.UpdateSuccessResult();
		}
		public Result UpdateSmtpOption(SmtpOption option)
		{
			var res = _smtpOptionRepo.Update(option);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(1);
            }
            SmtpOptionCache.Refresh();
            return DomainResult.SmtpOption.UpdateSuccessResult();
        }



        public Option GetOption()
		{

#if DEBUG
            var option = _optionRepo.GetFirstOrDefault(x => x.IsRelease == false);
#else
            var option = _optionRepo.GetFirstOrDefault(x => x.IsRelease == true);
#endif
            if (option is null) throw new NotFoundException(nameof(Option));
            return option;
        }


        public List<CargoOption> ListCargoOptions()
		{
			return _cargoOptionRepo.GetList(x => x.IsValid == true);
		}

		public List<PaymentOption> ListPaymentOptions()
		{
			return _paymentOptionRepo.GetList(x => x.IsValid == true);
		}
		public List<SmtpOption> ListSmtpOptions()
		{
			return _smtpOptionRepo.GetList(x => x.IsValid == true);
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
