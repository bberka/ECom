namespace ECom.AdminWebApi.Endpoints.AccountEndpoints;

[EndpointRoute(typeof(Get))]
public class Get : EndpointBaseSync.WithoutRequest.WithResult<AdminDto>
{
  [HttpGet]
  [EndpointSwaggerOperation(typeof(Get), "Gets authenticated admin account")]
  public override AdminDto Handle() {
    var admin = HttpContext.GetAdmin();
    return admin;
  }
}