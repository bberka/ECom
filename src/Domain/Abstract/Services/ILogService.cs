using Serilog.Events;

namespace ECom.Domain.Abstract.Services;

public interface ILogService
{
    void SecurityLog(LogEventLevel severity, params string[] parameters);
    void AdminLog(CustomResult result, Guid? adminId, string operationName, params object[] parameters);
    void UserLog(CustomResult result, Guid? userId, string operationName, params object[] parameters);
}