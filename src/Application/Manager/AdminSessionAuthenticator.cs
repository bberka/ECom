using System.Collections.Concurrent;

namespace ECom.Application.Manager;

public class AdminSessionAuthenticator
{
  private readonly IAdminService _adminService;
  private const int SessionExpireMinutes = 1440;
  public AdminSessionAuthenticator(IAdminService adminService) {
    _adminService = adminService;
  }

  private ConcurrentDictionary<string, AdminLoginSession> Dictionary { get; set; } = new();
  public CustomResult<AdminLoginSession> AdminLogin(LoginRequest request) {
    var result = _adminService.AdminLogin(request);
    if (result.Status) {
      return result.ToResult();
    }
    var sessionId = EasGenerate.RandomString(512);
    var resp = AdminLoginSession.Create(result.Data, TimeSpan.FromMinutes(SessionExpireMinutes));
    return resp;
  }

  public AdminLoginSession? Validate(string sessionId) {
    if (string.IsNullOrWhiteSpace(sessionId)) return null;
    if (!Dictionary.ContainsKey(sessionId)) return null;
    var session = Dictionary[sessionId];
    var isExpired = session.ExpireTime < DateTime.Now;
    if (isExpired) {
      Dictionary.TryRemove(sessionId, out _);
      return null;
    }
    return session;
  }
}
