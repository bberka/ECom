
using Serilog.Events;

namespace ECom.Domain.Abstract;

public interface ILogService
{
  void SecurityLog(LogEventLevel severity, params string[] parameters);
  void AdminLog(Result result, int? adminId, string operationName, params object[] parameters);
  void UserLog(Result result, int? userId, string operationName, params object[] parameters);
}