using ECom.Domain.Abstract;
using ECom.Domain.Entities;
using ECom.Domain.Extensions;
using ECom.WebApi.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace ECom.WebApi.Controllers.UserControllers
{

    public class AddressController : BaseUserController
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
		{
            this.addressService = addressService;
        }
		[HttpGet]
		public ActionResult<List<Address>> List()
		{
			var user = HttpContext.GetUser();
			var res = addressService.GetUserAddresses(user.Id);
			return res;
		}

		[HttpPost]
		public ActionResult<Result> Add([FromBody] Address address)
		{
			var userId = HttpContext.GetUserId();
			var res = addressService.AddAddress(userId,address);
			logger.Info(userId, address.ToJsonString());
			return res;
		}
		[HttpPost]
		public ActionResult<Result> Update([FromBody] Address address)
		{
            var userId = HttpContext.GetUserId();
            var res = addressService.UpdateAddress(userId,address);
			logger.Info(userId, address.ToJsonString());
			return res;
		}

		[HttpDelete]
		public ActionResult<Result> Delete([FromBody] int id)
		{
			var user = HttpContext.GetUser();
			var res = addressService.DeleteAddress(user.Id, id);
			logger.Info(user.Id, id);
			return res;
		}


	}
}
