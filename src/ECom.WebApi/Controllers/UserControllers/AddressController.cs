namespace ECom.WebApi.Controllers.UserControllers
{

	public class AddressController : BaseUserController
    {
        private readonly IAddressService addressService;
        private readonly ILogService _logService;

        public AddressController(IAddressService addressService,ILogService logService)
        {
            this.addressService = addressService;
            _logService = logService;
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
			_logService.UserLog(res,userId,"Address.Add",address.ToJsonString());
			return res;
		}
		[HttpPost]
		public ActionResult<Result> Update([FromBody] Address address)
		{
            var userId = HttpContext.GetUserId();
            var res = addressService.UpdateAddress(userId,address);
			_logService.UserLog(res,userId,"Address.Update",address.ToJsonString());
			return res;
		}

		[HttpDelete]
		public ActionResult<Result> Delete([FromBody] int id)
		{
			var userId = HttpContext.GetUserId();
			var res = addressService.DeleteAddress(userId, id);
            _logService.UserLog(res, userId, "Address.Delete");
			return res;
		}


	}
}
