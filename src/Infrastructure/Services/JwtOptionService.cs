using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Services
{
	public interface IJwtOptionService : IEfEntityRepository<JwtOption>
	{
		public JwtOption GetFromCache();
		public Result UpdateJwtOption(JwtOption jwtOption);
	}


	public class JwtOptionService : EfEntityRepositoryBase<JwtOption, EComDbContext>, IJwtOptionService
	{

		public JwtOptionService()
		{
			Cache = new(GetSingle, CACHE_REFRESH_INTERVAL_MINS);
		}

		const byte CACHE_REFRESH_INTERVAL_MINS = 10;
		private readonly EasCache<JwtOption> Cache;

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
