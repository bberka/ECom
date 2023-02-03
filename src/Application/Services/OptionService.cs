



namespace ECom.Application.Services
{

	public interface IOptionService : IEfEntityRepository<Option>
	{
		Option GetFromCache();
		Option GetOption();
		Result UpdateOption(Option option);
	}

	public class OptionService : EfEntityRepositoryBase<Option, EComDbContext>, IOptionService
	{
		public OptionService()
		{
			Cache = new(GetOption, CACHE_REFRESH_INTERVAL_MINS);
		}

		const byte CACHE_REFRESH_INTERVAL_MINS = 1;
		private readonly EasCache<Option> Cache;

		public Result UpdateOption(Option option)
		{
			using var ctx = new EComDbContext();
			ctx.Options.Clear();
			ctx.SaveChanges();
			ctx.Add(option);
			var res = ctx.SaveChanges();
			if (res != 1) return Result.Error(1, ErrCode.DbErrorInternal);
			Cache.Refresh();
			return Result.Success(ErrCode.NotFound);
		}
		public Option GetOption()
		{
#if DEBUG
			return GetSingle(x => x.IsRelease == false);
#else
			return GetSingle(x => x.IsRelease == true);
#endif
		}
		public Option GetFromCache()
		{
			return Cache.Get();
		}
	}
}
