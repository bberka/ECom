

namespace ECom.WebApi.Controllers.AdminControllers
{
    [ApiController]
    [Route("api/Admin/[controller]/[action]")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
#if DEBUG
            var jwt = new EasJWT(OptionMgr.This.Cache.Get().JwtSecret);
            var adm = new Admin();
            var dic = adm.AsDictionary();
            dic.Add("AdminOnly","");
            var token = jwt.GenerateJwtToken(dic ,DateTime.Now.AddMinutes(10));
#endif
            return Ok(token);
        }
    }
}
