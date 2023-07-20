namespace ECom.AdminBlazorServer.Common;

public static class ExporterService
{
  public enum ExportType
  {
    XLS,
    XML,
    CSV,
    JSON,
    PDF
  }

  public static async Task Export(ExportType type) {
    await Task.Run(() => { });
  }

  private static void ExportToXLS() {
  }
}