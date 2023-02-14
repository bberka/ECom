using EasMe.Logging;

namespace ECom.Domain.Abstract
{
    public interface ILogService
    {
        void SecurityLog(LogSeverity severity, params string[] parameters);
        void AdminLog(Result result, int? adminId, string operationName, params object[] parameters);
        void UserLog(Result result, int? userId, string operationName,params object[] parameters);



    }
}
