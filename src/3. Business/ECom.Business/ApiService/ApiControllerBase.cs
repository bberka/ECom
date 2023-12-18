namespace ECom.Business.ApiService;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
  [FromServices]
  public ILogService LogService { get; set; }
}