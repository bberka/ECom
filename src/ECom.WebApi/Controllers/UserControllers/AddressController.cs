using ECom.Domain.Abstract;
using ECom.Domain.Entities;
using ECom.Domain.Extensions;
using ECom.WebApi.Filters;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace ECom.WebApi.Controllers.UserControllers
{
	[UserAuthFilter]
    public class AddressController : BaseUserController
    {
		private readonly IAddressService _service;
		public AddressController(IAddressService service)
		{
			_service = service;
		}
		[HttpGet]
		public IActionResult List()
		{
			var user = HttpContext.GetUser();
			var res = _service.GetUserAddresses(user.Id);
			return Ok(res);
		}

		[HttpPut]
		public IActionResult Add([FromBody] Address address)
		{
			var user = HttpContext.GetUser();
			var res = _service.AddAddress(address);
			if (!res.IsSuccess)
			{
				logger.Warn(user.Id, res.Rv, res.ErrorCode, res.Parameters, address.ToJsonString());
				return BadRequest(res.ToJsonString());
			}
			logger.Info(user.Id, address.ToJsonString());
			return Ok(res);

		}
		[HttpPost]
		public IActionResult Update([FromBody] Address address)
		{
			var user = HttpContext.GetUser();

			var res = _service.UpdateAddress(address);
			if (!res.IsSuccess)
			{
				logger.Warn(user.Id, res.Rv, res.ErrorCode, res.Parameters, address.ToJsonString());
				return BadRequest(res.ToJsonString());
			}
			logger.Info(user.Id,address.ToJsonString());
			return Ok(res);
		}

		[HttpDelete]
		public IActionResult Delete([FromBody] int id)
		{
			var user = HttpContext.GetUser();

			var res = _service.DeleteAddress(user.Id, id);
			if (!res.IsSuccess)
			{
				logger.Warn(user.Id, res.Rv, res.ErrorCode, res.Parameters, id);
				return BadRequest(res.ToJsonString());
			}
			logger.Info(user.Id, id);
			return Ok(res);
		}


	}
}
