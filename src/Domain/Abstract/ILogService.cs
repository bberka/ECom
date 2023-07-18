using Serilog.Events;

namespace ECom.Domain.Abstract;

public interface ILogService
{
  void SecurityLog(LogEventLevel severity, params string[] parameters);
  void AdminLog(CustomResult result, int? adminId, string operationName, params object[] parameters);
  void UserLog(CustomResult result, int? userId, string operationName, params object[] parameters);
}