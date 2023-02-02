using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Services
{

	public interface IJwtOptionService : IEfEntityRepository<JwtOption>
	{
		JwtOption GetFromCache();
		JwtOption GetOption();
		Result UpdateJwtOption(JwtOption option);
	}

	public class JwtOptionService : EfEntityRepositoryBase<JwtOption, EComDbContext>, IJwtOptionService
	{

		public JwtOptionService()
		{
			Cache = new(GetOption, CACHE_REFRESH_INTERVAL_MINS);
		}

		const byte CACHE_REFRESH_INTERVAL_MINS = 10;
		private readonly EasCache<JwtOption> Cache;
		public JwtOption GetOption()
		{
#if DEBUG
			return GetSingle(x => x.IsRelease == false);
#else
			return GetSingle(x => x.IsRelease == true);
#endif
		}
		public JwtOption GetFromCache()
		{
			return Cache.Get();
		}

		public Result UpdateJwtOption(JwtOption option)
		{
			using var ctx = new EComDbContext();
			ctx.JwtOptions.Clear();
			ctx.SaveChanges();
			ctx.Add(option);
			var res = ctx.SaveChanges();
			if (res != 1) return Result.Error(1, Response.DbErrorInternal);
			Cache.Refresh();
			return Result.Success(Response.JwtOptionUpdated);
		}
	}


}
