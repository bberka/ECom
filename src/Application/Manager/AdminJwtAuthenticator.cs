using EasMe.Authorization;
using ECom.Domain.Interfaces;
using System.Security.Claims;
using ECom.Domain.Lib;

namespace ECom.Application.Manager
{

    public class AdminJwtAuthenticator : IAdminJwtAuthenticator
	{
		private readonly IAdminService _adminService;
		private readonly EasJWT _jwtManager;
		public AdminJwtAuthenticator(IAdminService adminService)
		{
			this._adminService = adminService;
			_jwtManager = new(JwtOption.This.Secret, JwtOption.This.Issuer, JwtOption.This.Audience);
		}

	

        public ResultData<AdminLoginResponseModel> Authenticate(LoginRequestModel model)
        {
            var loginResult = _adminService.Login(model);
            if (!loginResult.IsSuccess)
            {
                return Result.Error(loginResult.Rv, loginResult.ErrorCode);
            }
            var adminAsDic = loginResult.Data.AsDictionary();
            var remove = adminAsDic.Where(x => x.Value == null || x.Value.ToString() == "");
            foreach (var kvp in remove)
            {
                adminAsDic.Remove(kvp.Key);
            }
            adminAsDic.Add("AdminOnly", "true");
            adminAsDic.Add(ClaimTypes.Role, loginResult.Data.RoleName);
            adminAsDic.Add(EasMeClaimType.EndPointPermissions,loginResult.Data.Permissions);
            var expireMins = JwtOption.This.TokenExpireMinutes;
            var date = DateTime.UtcNow.AddMinutes(expireMins);
            var token = _jwtManager.GenerateJwtToken(adminAsDic, date);
    
            var jwtTokenModel = new JwtTokenModel
            {
                ExpireUnix = date.ToUnixTime(),
                Token = token,
            };
            return new AdminLoginResponseModel
            {
                Admin = loginResult.Data,
                Token = jwtTokenModel
            };
        }
    }
}
