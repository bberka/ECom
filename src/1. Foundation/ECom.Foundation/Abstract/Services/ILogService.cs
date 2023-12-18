using ECom.Foundation.Enum;
using Serilog.Events;

namespace ECom.Foundation.Abstract.Services;

public interface ILogService
{
  void SecurityLog(LogEventLevel severity, string reason);

  // void AdminLog(ApiResponse result, Guid? adminId, string operationName, object? requestData = null);
  void AdminLog(AdminActionType actionType, Result result, Guid? adminId = null, object? requestData = null);

  void AdminLog(AdminActionType actionType, Guid? adminId = null, object? requestData = null);

  // void UserLog(ApiResponse result, Guid? userId, string operationName, object? requestData = null);
  void UserLog(UserActionType actionType, Result result, Guid? userId = null, object? requestData = null);
  void UserLog(UserActionType actionType, Guid? userId = null, object? requestData = null);
}