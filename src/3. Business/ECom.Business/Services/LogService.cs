using ECom.Foundation.Static;

namespace ECom.Business.Services;

public class LogService : ILogService
{
  private static readonly EasTask LoggerTask = new();
  private readonly IUnitOfWork _unitOfWork;

  public LogService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

//TODO DB LOG
  public void SecurityLog(LogEventLevel severity, string reason) {
    var context = new HttpContextAccessor().HttpContext;
    var data = context.GetNecessaryRequestData();

    var action = new Action(() => {
      try {
        var log = new SecurityLog {
          RegisterDate = DateTime.Now,
          CFConnecting_IpAddress = data?.CFConnectingIpAddress,
          RemoteIpAddress = data?.RemoteIpAddress ?? "-",
          XReal_IpAddress = data?.XRealIpAddress,
          UserAgent = data?.UserAgent ?? "-",
          HttpStatusCode = context?.Response.StatusCode ?? -1,
          QueryString = context?.Request.QueryString.ToString() ?? "-",
          RequestUrl = context?.Request.GetDisplayUrl() ?? "-",
          Reason = reason
        };
        _unitOfWork.SecurityLogs.Add(log);
        var res = _unitOfWork.Save();
        if (!res) {
          //TODO File logging
        }
      }
      catch (Exception ex) {
        Log.Error(ex, "SecurityLog DbError");
      }
    });
    LoggerTask.AddToQueue(action);
  }


  public void AdminLog(AdminActionType actionType, Result result, Guid? adminId = null, object? requestData = null) {
    var context = new HttpContextAccessor().HttpContext;
    var httpData = context.GetNecessaryRequestData();
    var action = new Action(() => {
      try {
        var log = new AdminLog {
          AdminId = adminId,
          RegisterDate = DateTime.Now,
          Level = result.Level,
          CFConnecting_IpAddress = httpData?.CFConnectingIpAddress,
          RemoteIpAddress = httpData?.RemoteIpAddress ?? "-",
          XReal_IpAddress = httpData?.XRealIpAddress,
          UserAgent = httpData?.UserAgent ?? "-",
          ErrorCode = result.Message,
          HttpStatusCode = context?.Response.StatusCode ?? -1,
          QueryString = context?.Request.QueryString.ToString() ?? "-",
          RequestUrl = context?.Request.GetDisplayUrl() ?? "-",
          RequestData = requestData?.ToJsonString() ?? "-",
          ActionType = actionType
        };
        _unitOfWork.AdminLogs.Add(log);
        var res = _unitOfWork.Save();
        if (!res) {
          //TODO File logging
        }
      }
      catch (Exception ex) {
        Log.Error(ex, "AdminLog DbError");
      }
    });
    LoggerTask.AddToQueue(action);
  }

  public void AdminLog<T>(AdminActionType actionType, Result<T> result, Guid? adminId = null, object? requestData = null) { }

  public void AdminLog(AdminActionType actionType, Guid? adminId = null, object? requestData = null) { }

  public void UserLog(UserActionType actionType, Result result, Guid? userId = null, object? requestData = null) { }

  public void UserLog<T>(UserActionType actionType, Result<T> result, Guid? userId = null, object? requestData = null) { }

  public void UserLog(UserActionType actionType, Guid? userId = null, object? requestData = null) { }
}