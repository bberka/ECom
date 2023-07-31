using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services;
using ECom.Shared.Extensions;

namespace ECom.Application.Services;

public class LogService : ILogService
{
    private readonly IUnitOfWork UnitOfWork;

    public LogService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
    private static readonly EasTask EasTask = new();

    public void SecurityLog(LogEventLevel severity, params string[] parameters)
    {
        var context = new HttpContextAccessor().HttpContext;
        var data = context.GetNecessaryRequestData();

        var action = new Action(() =>
        {
            //try {
            //  var log = new SecurityLog {
            //    Params = string.Join("|", parameters),
            //    RegisterDate = DateTime.Now,
            //    CFConnecting_IpAddress = data?.CFConnectingIpAddress,
            //    RemoteIpAddress = data?.RemoteIpAddress ?? "-",
            //    XReal_IpAddress = data?.XRealIpAddress,
            //    UserAgent = data?.UserAgent ?? "-",
            //    HttpStatusCodeResponse = context?.Response.StatusCode ?? -1,
            //    QueryString = context?.Request.QueryString.ToString() ?? "-",
            //    RequestUrl = context?.Request.GetDisplayUrl() ?? "-"
            //  };
            //  unitOfWork.SecurityLogRepository.Add(log);
            //  var res = unitOfWork.Save();
            //  if (!res) {
            //    //TODO File logging
            //  }
            //}
            //catch (Exception ex) {
            //  Log.Error(ex, "SecurityLog DbError");
            //}
        });
        EasTask.AddToQueue(action);
    }


    public void AdminLog(CustomResult result, Guid? adminId, string operationName, params object[] parameters)
    {
        var context = new HttpContextAccessor().HttpContext;
        var data = context.GetNecessaryRequestData();

        var action = new Action(() =>
        {
            //try {
            //  var log = new AdminLog {
            //    AdminId = adminId,
            //    OperationName = operationName,
            //    RegisterDate = DateTime.Now,
            //    Severity = (int)result.Level,
            //    CFConnecting_IpAddress = data?.CFConnectingIpAddress,
            //    RemoteIpAddress = data?.RemoteIpAddress ?? "-",
            //    XReal_IpAddress = data?.XRealIpAddress,
            //    UserAgent = data?.UserAgent ?? "-",
            //    Params = string.Join("|", parameters),
            //    //ResultErrors = string.Join("|", result.ValidationErrors.Select(x => x.Message)),
            //    ErrorCode = result.ErrorCode,
            //    //ErrorCode = $"{result.Message.Name}.{result.Message.Error}|{string.Join(":",result.Message.Params)}",
            //    Rv = 0
            //  };
            //  unitOfWork.AdminLogRepository.Add(log);
            //  var res = unitOfWork.Save();
            //  if (!res) {
            //    //TODO File logging
            //  }
            //}
            //catch (Exception ex) {
            //  Log.Error(ex, "AdminLog DbError");
            //}
        });
        EasTask.AddToQueue(action);
    }

    public void UserLog(CustomResult result, Guid? userId, string operationName, params object[] parameters)
    {
        var context = new HttpContextAccessor().HttpContext;
        var data = context.GetNecessaryRequestData();
        var action = new Action(() =>
        {
            //try {
            //  var log = new UserLog {
            //    UserId = userId,
            //    OperationName = operationName,
            //    RegisterDate = DateTime.Now,
            //    Severity = (int)result.Level,
            //    CFConnecting_IpAddress = data?.CFConnectingIpAddress,
            //    RemoteIpAddress = data?.RemoteIpAddress ?? "-",
            //    XReal_IpAddress = data?.XRealIpAddress,
            //    UserAgent = data?.UserAgent ?? "-",
            //    Params = string.Join("|", parameters),
            //    //ResultErrors = string.Join("|", result.ValidationErrors.Select(x => x.Message)),
            //    ErrorCode = result.ErrorCode,
            //    //ErrorCode = $"{result.Message.Name}.{result.Message.Error}|{string.Join(":", result.Message.Params)}",
            //    Rv = 0
            //  };
            //  unitOfWork.UserLogRepository.Add(log);
            //  var res = unitOfWork.Save();
            //  if (!res) {
            //    //TODO File logging
            //  }
            //}
            //catch (Exception e) {
            //  Log.Error(e, "UserLog DbError");
            //}
        });
        EasTask.AddToQueue(action);
    }
}