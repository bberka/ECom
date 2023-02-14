using ECom.Domain.DTOs.AdminDTOs;

namespace ECom.Application.Manager
{

    public class AdminJwtAuthenticator : IAdminJwtAuthenticator
	{
		private readonly IAdminService _adminService;
        private readonly IDebugService _debugService;
        private readonly EasJWT _jwtManager;
		public AdminJwtAuthenticator(
            IAdminService adminService,
            IDebugService debugService)
		{
			this._adminService = adminService;
            _debugService = debugService;
            _jwtManager = new(JwtOption.This.Secret, JwtOption.This.Issuer, JwtOption.This.Audience);
		}

	

        public ResultData<AdminLoginResponse> Authenticate(LoginRequest model)
        {
#if !DEBUG
            var admin = _debugService.GetAdminDto();
#else
            var loginResult = _adminService.Login(model);
            if (!loginResult.IsSuccess)
            {
                return Result.Error(loginResult.Rv, loginResult.ErrorCode);
            }

            var admin = loginResult.Data;
#endif


            var adminAsDic = admin.AsDictionary();
            var remove = adminAsDic.Where(x => x.Value == null || x.Value.ToString() == "");
            foreach (var kvp in remove)
            {
                adminAsDic.Remove(kvp.Key);
            }
            adminAsDic.Add("AdminOnly", "true");
            adminAsDic.Add(ClaimTypes.Role, admin.RoleName);
            adminAsDic.Add(EasMeClaimType.EndPointPermissions, admin.Permissions);
            var expireMins = JwtOption.This.TokenExpireMinutes;
            var date = DateTime.UtcNow.AddMinutes(expireMins);
            var token = _jwtManager.GenerateJwtToken(adminAsDic, date);
    
            var jwtTokenModel = new JwtToken
            {
                ExpireUnix = date.ToUnixTime(),
                Token = token,
            };
            return new AdminLoginResponse
            {
                Admin = admin,
                Token = jwtTokenModel
            };
        }
    }
}
