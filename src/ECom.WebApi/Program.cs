using ECom.Application.Setup;
using ECom.Application.SetupMiddleware;

EComLoggerHelper.Configure(true);


var builder = WebApplication.CreateBuilder(args);


builder.UseBuilderSetup(typeof(ApplicationDefaultSetup).Assembly);

var app = builder.Build();

app.UseApplicationSetup(typeof(ApplicationDefaultSetup).Assembly);

app.Run();