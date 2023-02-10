﻿
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

namespace ECom.Application.Services
{

	public class LogService : ILogService
	{
		private readonly IEfEntityRepository<UserLog> _userLogRepo;
		private readonly IEfEntityRepository<SecurityLog> _securityLogRepo;
		private readonly IEfEntityRepository<AdminLog> _adminLogRepo;

		public LogService(
			IEfEntityRepository<UserLog> userLogRepo,
			IEfEntityRepository<SecurityLog> securityLogRepo,
			IEfEntityRepository<AdminLog> adminLogRepo)
		{
			this._userLogRepo = userLogRepo;
			this._securityLogRepo = securityLogRepo;
			this._adminLogRepo = adminLogRepo;
		}

       
        public void SecurityLog(LogSeverity severity, params string[] parameters)
        {
            var context = HttpContextHelper.Current;
            var data = context.GetNecessaryRequestData();
            Task.Run(() =>
            {
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
                _securityLogRepo.Add(log);
            });

        }

 
        public void AdminLog(Result result, int? adminId, string operationName, params object[] parameters)
        {
            var context = HttpContextHelper.Current.GetNecessaryRequestData();
            Task.Run(() =>
            {
                var log = new AdminLog()
                {

                    AdminId = adminId,
                    OperationName = operationName,
                    RegisterDate = DateTime.Now,
                    Severity = (int)result.Severity,
                    CFConnecting_IpAddress = context?.CFConnectingIpAddress,
                    RemoteIpAddress = context?.RemoteIpAddress ?? "-",
                    XReal_IpAddress = context?.XRealIpAddress,
                    UserAgent = context?.UserAgent ?? "-",
                    Params = string.Join("|", parameters),
                    ResultErrors = string.Join("|", result.Errors),
                    ErrorCode = result.ErrorCode,
                    Rv = result.Rv,
                };
                _adminLogRepo.Add(log);
            });
            
        }

        public void UserLog(Result result, int? userId, string operationName, params object[] parameters)
        {

            var context = HttpContextHelper.Current.GetNecessaryRequestData();
            Task.Run(() =>
            {
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
                _userLogRepo.Add(log);
            });
        }
    }
}
