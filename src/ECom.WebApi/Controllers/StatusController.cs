namespace ECom.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class StatusController : Controller
{
  [HttpGet]
  [Route("/Status")]
  public JsonResult Status() {
    return Json("200!");
  }
}