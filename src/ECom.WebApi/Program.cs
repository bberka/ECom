using ECom.Application.Setup;

EComLoggerHelper.Configure(true);


var builder = WebApplication.CreateBuilder(args);

builder.Setup();


var app = builder.Build();

app.Setup();
app.Run();