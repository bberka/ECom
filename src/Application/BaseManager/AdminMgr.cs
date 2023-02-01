using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ECom.Infrastructure.Abstract;
using Microsoft.EntityFrameworkCore;
using EasMe;
using EasMe.Extensions;
using ECom.Domain.Extensions;

namespace ECom.Application.BaseManager
{
	public class AdminMgr : EfEntityRepositoryBase<Admin, EComDbContext>
	{
		private AdminMgr() { }
		public static AdminMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static AdminMgr? Instance;
		public bool HasPermission(int adminId, int permissionId)
		{
			var ctx = new EComDbContext();
			var admin = GetSingle(x => x.Id == adminId && x.IsValid == true && x.IsEmailVerified == true && x.DeletedDate != null);
			if (admin.RoleId is null) throw new BaseException(Response.DbErrorForeignKeyIsInvalid);
			return RoleBindMgr.This.Any(x => x.PermissionId == permissionId && x.RoleId == admin.RoleId && x.IsValid == true);
		}
		public ResultData<Admin> Login(LoginModel model)
		{
			var ctx = new EComDbContext();
			var admin = ctx.Admins.Where(x => x.Username == model.Username).SingleOrDefault();
			if (admin is null)
			{
				return ResultData<Admin>.Error(1, Response.WrongUsernameOrPassword);
			}
			if(admin.IsValid == true)
			{
				return ResultData<Admin>.Error(2, Response.AccountIsNotValid);
			}
			if(admin.DeletedDate != null)
			{
				return ResultData<Admin>.Error(3, Response.AccountDeleted);
			}
			if (OptionMgr.This.GetSingle().IsDebug == false && admin.IsTestAccount == true)
			{
				throw new BaseException(Response.AdminDebugAccountCanNotBeUsed);
			}
			var hashed = model.Password.MD5Hash().ConvertToString();
			if(admin.Password != hashed)
			{
				IncreaseFailedPasswordCount(admin);
				return ResultData<Admin>.Error(4, Response.WrongUsernameOrPassword);
			}
			if (admin.IsEmailVerified == false)
			{
				return ResultData<Admin>.Error(5, Response.EmailIsNotVerified);
			}
			if (admin.TwoFactorType != 0)
			{
				//TODO
			}
			UpdateSuccessLogin(admin);
			return ResultData<Admin>.Success(admin);
		}
		public bool UpdateSuccessLogin(Admin admin)
		{
			var req = HttpContextHelper.Current.GetNecessaryRequestData();
			if (req == null) return false;
			admin.TotalLoginCount++;
			admin.LastLoginDate= DateTime.Now;
			admin.LastLoginIp = req.IpAddress;
			admin.LastLoginUserAgent = req.UserAgent;
			var ctx = new EComDbContext();
			ctx.Update(admin);
			return ctx.SaveChanges() == 1;
		}
		public bool IncreaseFailedPasswordCount(Admin admin) 
		{
			var ctx = new EComDbContext();
			admin.FailedPasswordCount++; 
			ctx.Update(admin);
			return ctx.SaveChanges() == 1;
		}


	}
}
