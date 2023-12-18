using ECom.Foundation.DTOs.Response;

namespace ECom.Foundation.Abstract.Services.Admin;

public interface IAdminJwtAuthenticator : JwtAuthenticator<Response_Admin_Login> { }