using ECom.Foundation.DTOs.Response;

namespace ECom.Foundation.Abstract.Services.User;

public interface IUserJwtAuthenticator : JwtAuthenticator<Response_User_Login> { }