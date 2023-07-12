﻿using ECom.Domain.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Serilog.Events;

namespace ECom.Application.Services;

public class LogService : ILogService
{
  private static readonly EasTask EasTask = new();

  public void SecurityLog(LogEventLevel severity, params string[] parameters) {
    var context = new HttpContextAccessor().HttpContext;
    var data = context.GetNecessaryRequestData();
    var action = new Action(() => {
      var unitOfWork = new UnitOfWork();
      var log = new SecurityLog {
        Params = string.Join("|", parameters),
        RegisterDate = DateTime.Now,
        CFConnecting_IpAddress = data?.CFConnectingIpAddress,
        RemoteIpAddress = data?.RemoteIpAddress ?? "-",
        XReal_IpAddress = data?.XRealIpAddress,
        UserAgent = data?.UserAgent ?? "-",
        HttpStatusCodeResponse = context?.Response.StatusCode ?? -1,
        QueryString = context?.Request.QueryString.ToString() ?? "-",
        RequestUrl = context?.Request.GetDisplayUrl() ?? "-"
      };
      unitOfWork.SecurityLogRepository.Insert(log);
      var res = unitOfWork.Save();
      if (!res) {
        //TODO File logging
      }
    });
    EasTask.AddToQueue(action);
  }


  public void AdminLog(Result result, int? adminId, string operationName, params object[] parameters) {
    var context = new HttpContextAccessor().HttpContext;
    var data = context.GetNecessaryRequestData();
    var action = new Action(() => {
      var unitOfWork = new UnitOfWork();
      var log = new AdminLog {
        AdminId = adminId,
        OperationName = operationName,
        RegisterDate = DateTime.Now,
        Severity = (int)result.Severity,
        CFConnecting_IpAddress = data?.CFConnectingIpAddress,
        RemoteIpAddress = data?.RemoteIpAddress ?? "-",
        XReal_IpAddress = data?.XRealIpAddress,
        UserAgent = data?.UserAgent ?? "-",
        Params = string.Join("|", parameters),
        ResultErrors = string.Join("|", result.Errors),
        ErrorCode = result.ErrorCode,
        Rv = 0
      };
      unitOfWork.AdminLogRepository.Insert(log);
      var res = unitOfWork.Save();
      if (!res) {
        //TODO File logging
      }
    });
    EasTask.AddToQueue(action);
  }

  public void UserLog(Result result, int? userId, string operationName, params object[] parameters) {
    var context = new HttpContextAccessor().HttpContext;
    var data = context.GetNecessaryRequestData();
    var action = new Action(() => {
      var unitOfWork = new UnitOfWork();
      var log = new UserLog {
        UserId = userId,
        OperationName = operationName,
        RegisterDate = DateTime.Now,
        Severity = (int)result.Severity,
        CFConnecting_IpAddress = data?.CFConnectingIpAddress,
        RemoteIpAddress = data?.RemoteIpAddress ?? "-",
        XReal_IpAddress = data?.XRealIpAddress,
        UserAgent = data?.UserAgent ?? "-",
        Params = string.Join("|", parameters),
        ResultErrors = string.Join("|", result.Errors),
        ErrorCode = result.ErrorCode,
        Rv = 0
      };
      unitOfWork.UserLogRepository.Insert(log);
      var res = unitOfWork.Save();
      if (!res) {
        //TODO File logging
      }
    });
    EasTask.AddToQueue(action);
  }
}