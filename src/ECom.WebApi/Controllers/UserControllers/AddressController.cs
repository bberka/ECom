using ECom.Domain.Entities;
using ECom.Domain.Extensions;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace ECom.WebApi.Controllers.UserControllers
{
    public class AddressController : BaseUserController
    {
		private readonly IAddressService _service;
		public AddressController(IAddressService service)
		{
			_service = service;
		}
		[HttpGet]
		public IActionResult ListUserAddreses()
		{
			var userId = User.GetUserId();
			var res = _service.GetUserAddresses(userId);
			logger.Info(userId);
			return Ok(res);
		}

		[HttpPut]
		public IActionResult Add([FromBody] Address address)
		{
			var userId = User.GetUserId();
			address.UserId = userId;
			var res = _service.AddAddress(address);
			if (!res.IsSuccess)
			{
				logger.Warn(userId, res.Rv, res.ErrorCode, res.Parameters, address.ToJsonString());
				return BadRequest(res.ToJsonString());
			}
			logger.Info(userId, address.ToJsonString());
			return Ok(res);

		}
		[HttpPost]
		public IActionResult Update([FromBody] Address address)
		{
			var userId = User.GetUserId();
			address.UserId = userId;
			var res = _service.UpdateAddress(address);
			if (!res.IsSuccess)
			{
				logger.Warn(userId, res.Rv, res.ErrorCode, res.Parameters, address.ToJsonString());
				return BadRequest(res.ToJsonString());
			}
			logger.Info(userId,address.ToJsonString());
			return Ok(res);
		}

		[HttpDelete]
		public IActionResult Delete([FromBody] int id)
		{
			var userId = User.GetUserId();
			var res = _service.DeleteAddress(userId, id);
			if (!res.IsSuccess)
			{
				logger.Warn(userId, res.Rv, res.ErrorCode, res.Parameters, id);
				return BadRequest(res.ToJsonString());
			}
			logger.Info(userId, id);
			return Ok(res);
		}


	}
}
