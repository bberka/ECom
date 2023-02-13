using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{
    [AllowAnonymous]
    public class PaymentController : BaseUserController
    {
        private readonly IOptionService _optionService;

        public PaymentController(IOptionService optionService)
        {
            _optionService = optionService;
        }
        [HttpGet]
        public ActionResult<List<PaymentOption>> List()
        {
            return _optionService.ListPaymentOptions();
        }
    }
}
