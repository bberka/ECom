using Serilog;

namespace ECom.Foundation.Constants;

public static class EComEvents
{
  public static void OnProcessExit(object? sender, EventArgs e) {
    Log.Information("Process exiting...");
    Log.CloseAndFlush();
  }

  public static void OnUnhandledException(object? sender, UnhandledExceptionEventArgs e) {
    var ex = (Exception)e.ExceptionObject;
    Log.Fatal(ex, "Unexpected exception occurred");
  }
}