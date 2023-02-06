
using ECom.Domain.Entities;
using ECom.Domain.Extensions;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AdminLog(LogSeverity severity, string operationName, int adminId, params string[] parameters)
        {
            Task.Run(() =>
            {
                var context = HttpContextHelper.Current.GetNecessaryRequestData();
                var log = new AdminLog
                {
                    AdminId = adminId,
                    OperationName = operationName,
                    Params = string.Join("|", parameters),
                    RegisterDate = DateTime.Now,
                    Severity = (int)severity,
                    CFConnecting_IpAddress = context?.CFConnectingIpAddress,
                    RemoteIpAddress = context?.RemoteIpAddress ?? "-",
                    XReal_IpAddress = context.XRealIpAddress,
                    UserAgent = context.UserAgent ?? "-",
                };
                _adminLogRepo.Add(log);
            });
        }

        public void SecurityLog(LogSeverity severity, params string[] parameters)
        {
            Task.Run(() =>
            {
                var context = HttpContextHelper.Current;
                var data = context.GetNecessaryRequestData();
                var log = new SecurityLog
                {
                    Params = string.Join("|", parameters),
                    RegisterDate = DateTime.Now,
                    CFConnecting_IpAddress = data?.CFConnectingIpAddress,
                    RemoteIpAddress = data?.RemoteIpAddress ?? "-",
                    XReal_IpAddress = data.XRealIpAddress,
                    UserAgent = data.UserAgent ?? "-",
                    HttpStatusCodeResponse = context.Response.StatusCode,
                    QueryString = context.Request.QueryString.ToString(),
                    RequestUrl = context.Request.GetDisplayUrl()
                };
                _securityLogRepo.Add(log);
            });

        }

        public void UserLog(LogSeverity severity, string operationName, int userId, params string[] parameters)
        {
            Task.Run(() =>
            {
                var context = HttpContextHelper.Current.GetNecessaryRequestData();
                var log = new UserLog
                {
                    UserId = userId,
                    OperationName = operationName,
                    Params = string.Join("|", parameters),
                    RegisterDate = DateTime.Now,
                    Severity = (int)severity,
                    CFConnecting_IpAddress = context?.CFConnectingIpAddress,
                    RemoteIpAddress = context?.RemoteIpAddress ?? "-",
                    XReal_IpAddress = context.XRealIpAddress,
                    UserAgent = context.UserAgent ?? "-",
                };
                _userLogRepo.Add(log);
            });
        }
    }
}
