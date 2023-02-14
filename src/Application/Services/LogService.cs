
using ECom.Domain.Entities;
using ECom.Domain.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ECom.Domain.Results.DomainResult;
using Action = System.Action;

namespace ECom.Application.Services
{

	public class LogService : ILogService
	{

        private static readonly EasTask EasTask = new();

        public void SecurityLog(LogSeverity severity, params string[] parameters)
        {
            var context = HttpContextHelper.Current;
            var data = context.GetNecessaryRequestData();
            var action = new Action(() =>
            {
                var unitOfWork = new UnitOfWork();
                var log = new SecurityLog
                {
                    Params = string.Join("|", parameters),
                    RegisterDate = DateTime.Now,
                    CFConnecting_IpAddress = data?.CFConnectingIpAddress,
                    RemoteIpAddress = data?.RemoteIpAddress ?? "-",
                    XReal_IpAddress = data?.XRealIpAddress,
                    UserAgent = data?.UserAgent ?? "-",
                    HttpStatusCodeResponse = context?.Response.StatusCode ?? -1,
                    QueryString = context?.Request.QueryString.ToString() ?? "-",
                    RequestUrl = context?.Request.GetDisplayUrl() ?? "-",
                };
                unitOfWork.SecurityLogRepository.Add(log);
                var res = unitOfWork.Save();
                if (!res)
                {
                    //TODO File logging
                }
            });
            EasTask.AddToQueue(action);
        }

 
        public void AdminLog(Result result, int? adminId, string operationName, params object[] parameters)
        {
            var data = HttpContextHelper.Current.GetNecessaryRequestData();
            var action = new Action(() =>
            {
                var unitOfWork = new UnitOfWork();
                var log = new AdminLog()
                {

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
                    Rv = result.Rv,
                };
                unitOfWork.AdminLogRepository.Add(log);
                var res = unitOfWork.Save();
                if (!res)
                {
                    //TODO File logging
                }
            });
            EasTask.AddToQueue(action);
        }

        public void UserLog(Result result, int? userId, string operationName, params object[] parameters)
        {

            var context = HttpContextHelper.Current.GetNecessaryRequestData();
            var action = new Action(() =>
            {
                var unitOfWork = new UnitOfWork();
                var log = new UserLog
                {
                    
                    UserId = userId,
                    OperationName = operationName,
                    RegisterDate = DateTime.Now,
                    Severity = (int)result.Severity,
                    CFConnecting_IpAddress = context?.CFConnectingIpAddress,
                    RemoteIpAddress = context?.RemoteIpAddress ?? "-",
                    XReal_IpAddress = context?.XRealIpAddress,
                    UserAgent = context?.UserAgent ?? "-",
                    Params = string.Join("|",parameters),
                    ResultErrors = string.Join("|",result.Errors),
                    ErrorCode = result.ErrorCode,
                    Rv = result.Rv,
                };
                unitOfWork.UserLogRepository.Add(log);
                var res = unitOfWork.Save();
                if (!res)
                {
                    //TODO File logging
                }
            });
            EasTask.AddToQueue(action);
        }
    }
}
