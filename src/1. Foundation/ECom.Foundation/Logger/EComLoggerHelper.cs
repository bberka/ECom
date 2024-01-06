using ECom.Foundation.Static;
using Serilog;
using Serilog.ConfigHelper;
using Serilog.ConfigHelper.Enricher;
using Serilog.ConfigHelper.Enricher.HttpRequestEnrichers;
using Serilog.Formatting.Compact;

namespace ECom.Foundation.Logger;

public static class EComLoggerHelper
{
  private static readonly string LogPath = Path.Combine("Logs", "Log.json");

  public static void Configure(bool enableConsoleLogging = false) {
    Log.Logger = GetDefaultConfiguration(enableConsoleLogging)
      .CreateLogger();
    AppDomain.CurrentDomain.ProcessExit += DomEvents.OnProcessExit;
    AppDomain.CurrentDomain.UnhandledException += DomEvents.OnUnhandledException;
  }

  private static LoggerConfiguration GetDefaultConfiguration(bool enableConsoleLogging = false) {
    var config = new LoggerConfiguration()
                 #if DEBUG
                 //.MinimumLevel.Verbose()
                 //.Enrich.With(new StackTraceEnricher())
                 #else
               .MinimumLevel.Information()
                 #endif
                 .Enrich.With(new MachineNameEnricher())
                 .Enrich.With(new HostIpAddressEnricher())
                 //.Enrich.With(new MachineGuidEnricher())
                 //.Enrich.With(new MacAddressEnricher())
                 .Enrich.With(new ThreadIdEnricher())
                 .Enrich.With(new HttpRequestIpAddressEnricher("CF-Connecting-IP"))
                 .Enrich.With(new HttpRequestPathEnricher())
                 //.Enrich.With(new HttpRequestIdEnricher())
                 .Enrich.With(new HttpRequestTraceIdentifiedEnricher())
                 .Enrich.With(new HttpRequestMethodEnricher())
                 .Enrich.With(new HttpRequestQueryStringEnricher())
                 .Enrich.With(new HostIpAddressEnricher())
                 .Enrich.With(new HttpRequestClaimEnricher("AuthorizedUserId", "Id"))
                 .Enrich.With(new HttpRequestUserIdentityNameEnricher())
                 .WriteTo.File(
                               new CompactJsonFormatter(),
                               LogPath,
                               rollingInterval: RollingInterval.Day,
                               retainedFileCountLimit: 14);
    if (!enableConsoleLogging) return config;
    var builder = new SerilogTemplateBuilder()
                  .AddTimeStamp()
                  .AddLevel()
                  .AddProperty("ThreadId", true)
                  .AddProperty("IpAddress", true)
                  .AddProperty("RequestPath", true)
                  .AddProperty("RequestMethod", true)
                  .AddProperty("RequestQueryString", true)
                  .AddMessage()
                  .AddException()
                  .Build();
    config.WriteTo.Console(outputTemplate: builder);
    return config;
  }
}