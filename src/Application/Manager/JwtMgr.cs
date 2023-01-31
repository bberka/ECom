using EasMe;
using EasMe.Extensions;

namespace ECom.Application.Manager
{
    public class JwtMgr : IJwtAuthentication
    {
        private static readonly EasJWT _easJWT = new(OptionHelper.Option.Get().JwtSecret);
        private static HashSet<JwtTokenModel> _tokens = new HashSet<JwtTokenModel>();
        public ResultData<JwtTokenModel> Authenticate(LoginModel model)
        {
            if (!UserValidator.ValidateUsername(model.Username))
            {
                return ResultData<JwtTokenModel>.Error(1, Response.InvalidUsername);
            }
            if (!UserValidator.ValidatePassword(model.Password))
            {
                return ResultData<JwtTokenModel>.Error(2, Response.InvalidPassword);
            }
            
            var ctx = EComDbContext.New();

            //md5 hash password
            var hashed = model.Password.MD5Hash();
            var user = ctx.Users.Where(x => x.Username == model.Username).SingleOrDefault();
            if (user is null)
            {
                return ResultData<JwtTokenModel>.Error(3,Response.WrongUsername);
            }
            var realPasswordHashed = user.Password.MD5Hash();
            if (hashed != realPasswordHashed)
            {
                return ResultData<JwtTokenModel>.Error(4, Response.WrongPassword);
            }
            if (user.IsValid)
            {
                return ResultData<JwtTokenModel>.Error(5,Response.NotValid);
            }
            if (user.IsTestAccount)
            {
#if RELEASE
		        throw new Exception("TestAccountsUsedOnlyDebug");
#endif
            }
            if (user.TwoFactorType != 0)
            {
                ThrowHelper.NotImplemented();
            }
            if (!user.IsEmailVerified)
            {
                //TODO: Send verify email
                return ResultData<JwtTokenModel>.Error(6, Response.EmailIsNotVerified);
            }
            var userClaimsDic = user.ToClaimsIdentity();
            DateTime expire = DateTime.Now.AddMinutes(OptionHelper.Option.Get().JwtExpireMinutesDefault);
            if (model.RememberMe)
            {
                expire = DateTime.Now.AddMinutes(OptionHelper.Option.Get().JwtExpireMinutesLong);
            }
            var token = _easJWT.GenerateJwtToken(userClaimsDic, expire);
            string? refresh = null;
            if (OptionHelper.Option.Get().IsUseRefreshToken)
            {
                refresh = EasGenerate.GenerateRandomString(128);
            }
            var tokenModel = new JwtTokenModel
            {
                Token = token,
                RefreshToken = refresh,
                ExpireUnix = expire.ToUnixTime()
            };
            _tokens.Add(tokenModel);
            RemoveExpiredSessions();
            return ResultData<JwtTokenModel>.Success(tokenModel);
        }
        private static void RemoveExpiredSessions()
        {
            lock (_tokens)
            {
                var now = DateTime.Now.ToUnixTime();
                _tokens.RemoveWhere(x => x.ExpireUnix < now);
            }
        }
        ResultData<string> IJwtAuthentication.Refresh(string token)
        {
            throw new NotImplementedException();
        }
    }
}
