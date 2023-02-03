



using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace ECom.Application.Services
{
	public interface IOptionService
	{
		JwtOption GetJwtOption();
		Option GetOption();
		List<CargoOption> GetCargoOptions();
		List<PaymentOption> GetPaymentOptions();
		List<SmtpOption> GetSmtpOptions();

		JwtOption GetJwtOptionFromCache();
		Option GetOptionFromCache();
		List<CargoOption> GetCargoOptionsFromCache();
		List<PaymentOption> GetPaymentOptionsFromCache();
		List<SmtpOption> GetSmtpOptionsFromCache();
		
		Result UpdateCargoOption(CargoOption option);
		Result UpdateJwtOption(JwtOption option);
		Result UpdateOption(Option option);
		Result UpdatePaymentOption(PaymentOption option);
		Result UpdateSmtpOption(SmtpOption option);
		public void RefreshCache();
	}

	public class OptionService : IOptionService
	{
		const byte CACHE_REFRESH_INTERVAL_MINS = 1;

		private readonly EasCache<Option> OptionCache;
		private readonly EasCache<JwtOption> JwtOptionCache;
		private readonly EasCache<List<CargoOption>> CargoOptionCache;
		private readonly EasCache<List<SmtpOption>> SmtpOptionCache;
		private readonly EasCache<List<PaymentOption>> PaymentOptionCache;


		private readonly IEfEntityRepository<Option> _optionRepo;
		private readonly IEfEntityRepository<JwtOption> _jwtOptionRepo;
		private readonly IEfEntityRepository<SmtpOption> _smtpOptionRepo;
		private readonly IEfEntityRepository<CargoOption> _cargoOptionRepo;
		private readonly IEfEntityRepository<PaymentOption> _paymentOptionRepo;

		public OptionService(
			IEfEntityRepository<Option> optionRepo,
			IEfEntityRepository<JwtOption> jwtOptionRepo,
			IEfEntityRepository<SmtpOption> smtpOptionRepo,
			IEfEntityRepository<CargoOption> cargoOptionRepo,
			IEfEntityRepository<PaymentOption> paymentOptionRepo)
		{
			this._optionRepo = optionRepo;
			this._jwtOptionRepo = jwtOptionRepo;
			this._smtpOptionRepo = smtpOptionRepo;
			this._cargoOptionRepo = cargoOptionRepo;
			this._paymentOptionRepo = paymentOptionRepo;

			OptionCache = new(GetOption, CACHE_REFRESH_INTERVAL_MINS);
			JwtOptionCache = new(GetJwtOption, CACHE_REFRESH_INTERVAL_MINS);
			CargoOptionCache = new(GetCargoOptions, CACHE_REFRESH_INTERVAL_MINS);
			SmtpOptionCache = new(GetSmtpOptions, CACHE_REFRESH_INTERVAL_MINS);
			PaymentOptionCache = new(GetPaymentOptions, CACHE_REFRESH_INTERVAL_MINS);

		}



		public Result UpdateOption(Option option)
		{
			var res = _optionRepo.Update(option);
			if (!res) return Result.Error(1, ErrCode.DbErrorInternal);
			OptionCache.Refresh();
			return Result.Success(ErrCode.NotFound);
		}
		public Result UpdateJwtOption(JwtOption option)
		{
			var res = _jwtOptionRepo.Update(option);
			if (!res) return Result.Error(1, ErrCode.DbErrorInternal);
			OptionCache.Refresh();
			return Result.Success(ErrCode.NotFound);
		}
		public Result UpdateCargoOption(CargoOption option)
		{
			var res = _cargoOptionRepo.Update(option);
			if (!res) return Result.Error(1, ErrCode.DbErrorInternal);
			OptionCache.Refresh();
			return Result.Success(ErrCode.NotFound);
		}
		public Result UpdatePaymentOption(PaymentOption option)
		{
			var res = _paymentOptionRepo.Update(option);
			if (!res) return Result.Error(1, ErrCode.DbErrorInternal);
			OptionCache.Refresh();
			return Result.Success(ErrCode.NotFound);
		}
		public Result UpdateSmtpOption(SmtpOption option)
		{
			var res = _smtpOptionRepo.Update(option);
			if (!res) return Result.Error(1, ErrCode.DbErrorInternal);
			OptionCache.Refresh();
			return Result.Success(ErrCode.NotFound);
		}


		
		public Option GetOption()
		{
#if DEBUG
			return _optionRepo.GetSingle(x => x.IsRelease == false);
#else
			return _optionRepo.GetSingle(x => x.IsRelease == true);
#endif
		}


		public JwtOption GetJwtOption()
		{
#if DEBUG
			return _jwtOptionRepo.GetSingle(x => x.IsRelease == false);
#else
			return _jwtOptionRepo.GetSingle(x => x.IsRelease == true);
#endif
		}

		public List<CargoOption> GetCargoOptions()
		{
			return _cargoOptionRepo.GetList(x => x.IsValid == true);
		}

		public List<PaymentOption> GetPaymentOptions()
		{
			return _paymentOptionRepo.GetList(x => x.IsValid == true);
		}
		public List<SmtpOption> GetSmtpOptions()
		{
			return _smtpOptionRepo.GetList(x => x.IsValid == true);
		}

		public void RefreshCache()
		{
			OptionCache.Refresh();
			PaymentOptionCache.Refresh();
			SmtpOptionCache.Refresh();
			JwtOptionCache.Refresh();
			CargoOptionCache.Refresh();

		}

		public JwtOption GetJwtOptionFromCache()
		{
			return JwtOptionCache.Get();
		}

		public Option GetOptionFromCache()
		{
			return OptionCache.Get();
		}

		public List<CargoOption> GetCargoOptionsFromCache()
		{
			return CargoOptionCache.Get();
		}

		public List<PaymentOption> GetPaymentOptionsFromCache()
		{
			return PaymentOptionCache.Get();
		}

		public List<SmtpOption> GetSmtpOptionsFromCache()
		{
			return SmtpOptionCache.Get();
		}
	}
}
