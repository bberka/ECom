using Microsoft.AspNetCore.Components.Web;

namespace ECom.AdminBlazorServer.Components;

public class CustomErrorBoundary : ErrorBoundary
{
  public new Exception? CurrentException  => base.CurrentException;
}