using EasMe.Logging;

namespace ECom.Domain.Abstract
{
    public interface ILogService
    {
        void SecurityLog(LogSeverity severity, params string[] parameters);
        void AdminLog(LogSeverity severity, string operationName, int adminId, params string[] parameters);
        void UserLog(LogSeverity severity, string operationName, int userId, params string[] parameters);

    }
}
